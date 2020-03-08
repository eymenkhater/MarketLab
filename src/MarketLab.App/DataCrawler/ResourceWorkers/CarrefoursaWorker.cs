using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DataCrawler.Extensions;
using DataCrawler.Models;
using HtmlAgilityPack;

namespace DataCrawler.ResourceWorkers
{
    public static class CarrefoursaWorker
    {
        private static HttpClient _httpClient = new HttpClient();
        private static CultureInfo culture = new CultureInfo("tr-TR", false);
        private const string BASE_URL = "https://www.carrefoursa.com";

        public static void Start()
        {
            var body = HttpExtension.LoadBody(BASE_URL);
            var _doc = new HtmlDocument();
            _doc.LoadHtml(body);

            var categoryNodes = _doc.DocumentNode.SelectNodes("//ul[@class='nav nav-pills navbar-nav pull-md-left']/li/ul/li/a");
            var categoryUrlList = categoryNodes.Where(q => q.Attributes["href"].Value != "/kampanyalar")
                                                .Select(q => $"{BASE_URL}{q.Attributes["href"].Value}").ToList();

            foreach (var url in categoryUrlList)
                GetProductsFromCategoryPage(url);
        }

        public static void GetProductsFromCategoryPage(string url, int page = 1)
        {
            string fullUrl = $"{url}?page={page++}";

            var body = HttpExtension.LoadBody(fullUrl);
            var _doc = new HtmlDocument();
            _doc.LoadHtml(body);

            var productNodes = _doc.DocumentNode.SelectNodes("//div[@class='product_click']");
            var products = new List<ImportProductRequest>();


            Console.WriteLine($"BATCH STARTED FOR : {fullUrl}");

            foreach (var node in productNodes)
            {
                string imageUrl = node.SelectSingleNode("a/span/img").Attributes["data-src"]?.Value;
                var imgArr = imageUrl.Split('/').ToList();
                try
                {
                    imgArr.RemoveAt(3); imgArr.RemoveAt(3); imgArr.RemoveAt(3);
                    imageUrl = string.Join("/", imgArr);
                }
                catch { imageUrl = default; }

                var product = new ImportProductRequest()
                {
                    Brand = new SaveBrandRequest(),
                    ProductResource = new SaveProductResourceRequest(),
                    ProductImages = new List<SaveProductImageRequest>()
                };

                product.Name = culture.TextInfo.ToTitleCase(node.SelectSingleNode("a/span/img").Attributes["title"]?.Value);
                product.ProductResource.IdentifierUrl = BASE_URL + node.SelectSingleNode("a").Attributes["href"]?.Value;
                product.ProductResource.Price = Math.Round(Convert.ToDecimal(node.Attributes["data-monitor-price"]?.Value, culture), 2);
                product.Brand.Name = culture.TextInfo.ToTitleCase(node.SelectSingleNode("input[@name='productBrandNamePost']").Attributes["value"]?.Value.ToLower(culture));
                product.ProductImages.Add(new SaveProductImageRequest()
                {
                    ImagePath = imageUrl
                });

                products.Add(product);
            }


            var bodyData = new StringContent(JsonSerializer.Serialize(products), Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync("http://localhost:5000/products/import/6", bodyData).Result;

            if (response.StatusCode != HttpStatusCode.OK)
                Console.WriteLine(response.StatusCode.ToString());

            Console.WriteLine($"BATCH ENDED FOR : {fullUrl} => TOTAL PRODUCT COUNT {products.Count}");

            int totalPage = _doc.DocumentNode.SelectNodes("//ul[@class='pagination']/li/a")
                                .Where(q => !string.IsNullOrEmpty(q.InnerText))
                                .Select(q => Convert.ToInt32(q.InnerText))
                                .OrderByDescending(x => x).FirstOrDefault();

            if (page <= totalPage)
                GetProductsFromCategoryPage(url, page);
        }
    }
}