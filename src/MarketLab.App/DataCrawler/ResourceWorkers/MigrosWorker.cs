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
    public static class MigrosWorker
    {
        private static HttpClient _httpClient = new HttpClient();
        private const string BASE_URL = "https://www.migros.com.tr";

        public static void Start()
        {
            var body = HttpExtension.LoadBody(BASE_URL);
            var _doc = new HtmlDocument();
            _doc.LoadHtml(body);

            var categoryNodes = _doc.DocumentNode.SelectNodes("//li[@class='category-list-item category-title']/a");
            var categoryUrlList = categoryNodes.Select(q => $"{BASE_URL}{q.Attributes["href"].Value}").ToList();

            foreach (var url in categoryUrlList)
            {
                GetProductsFromCategoryPage(url);
            }
        }

        public static void GetProductsFromCategoryPage(string url, int page = 1)
        {
            var body = HttpExtension.LoadBody($"{url}?sayfa={page++}");
            var _doc = new HtmlDocument();
            _doc.LoadHtml(body);

            var productNodes = _doc.DocumentNode.SelectNodes("//a[@class='product-link']");
            var myTI = new CultureInfo("tr-TR", false).TextInfo;
            var products = new List<ImportProductRequest>();


            foreach (var node in productNodes)
            {
                var imageNode = node.ChildNodes.FirstOrDefault();
                var product = new ImportProductRequest()
                {
                    Brand = new SaveBrandRequest(),
                    ProductResource = new SaveProductResourceRequest(),
                    ProductImages = new List<SaveProductImageRequest>()
                };

                product.Name = imageNode.Attributes["alt"]?.Value;
                product.ProductResource.IdentifierUrl = BASE_URL + node.Attributes["href"]?.Value;
                product.ProductResource.Price = Decimal.Parse(node.Attributes["data-monitor-price"].Value?.Replace(",", "."));
                product.Brand.Name = myTI.ToTitleCase(node.Attributes["data-monitor-brand"]?.Value);
                product.ProductImages.Add(new SaveProductImageRequest()
                {
                    ImagePath = imageNode.Attributes["data-src"]?.Value
                });

                products.Add(product);
            }

            var bodyData = new StringContent(JsonSerializer.Serialize(products), Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync("http://localhost:5000/products/import/5", bodyData).Result;

            if (response.StatusCode != HttpStatusCode.OK)
                Console.WriteLine(response.StatusCode.ToString());

            int totalPage = _doc.DocumentNode.SelectNodes("//ul[@class='pagination']/li/a")
                                                .Select(q => Convert.ToInt32(q.Attributes["data-page"].Value))
                                                .OrderByDescending(x => x).FirstOrDefault();

            if (page <= totalPage)
                GetProductsFromCategoryPage(url, page);
        }
    }
}