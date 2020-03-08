using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using DataCrawler.Extensions;
using DataCrawler.Models;
using HtmlAgilityPack;

namespace DataCrawler.ResourceWorkers
{
    public static class A101Worker
    {
        private static HttpClient _httpClient = new HttpClient();
        private static CultureInfo culture = new CultureInfo("tr-TR", false);
        private const string BASE_URL = "https://www.a101.com.tr";

        public static void Start()
        {
            var body = HttpExtension.LoadBody(BASE_URL);
            var _doc = new HtmlDocument();
            _doc.LoadHtml(body);

            var categoryNodes = _doc.DocumentNode.SelectNodes("//ul[@class='desktop-menu']/li/a");
            var categoryUrlList = categoryNodes.Select(q => $"{BASE_URL}{q.Attributes["href"].Value}").ToList();



            foreach (var categoryUrl in categoryUrlList)
            {
                GetProductsFromCategoryPage(categoryUrl);
            }

        }

        public static void GetProductsFromCategoryPage(string categoryUrl)
        {
            var body = HttpExtension.LoadBody(BASE_URL);
            var _doc = new HtmlDocument();
            body = HttpExtension.LoadBody(categoryUrl);
            _doc.LoadHtml(body);

            var brandList = _doc.DocumentNode.SelectNodes("//*[@name='attributes_integration_brand']")
                                                .Select(q => new KeyValuePair<string, string>(
                                                    q.NextSibling.NextSibling.InnerText,
                                                    $"{categoryUrl}?attributes_integration_brand={q.Attributes["value"].Value}"
                                                )).ToList();

            var products = new List<ImportProductRequest>();

            Console.WriteLine($"BATCH STARTED FOR : {categoryUrl}");

            foreach (var brandKV in brandList)
            {
                string url = brandKV.Value;
                string fullUrl = url;

                body = HttpExtension.LoadBody(fullUrl);
                _doc = new HtmlDocument();
                _doc.LoadHtml(body);

                var productNodes = _doc.DocumentNode.SelectNodes("//div[@class='product-card js-product-wrapper']");
                var brand = new SaveBrandRequest() { Name = culture.TextInfo.ToTitleCase(brandKV.Key.ToLower()) };
                Console.WriteLine($"{brand.Name} => CRAWLING STARTED: {fullUrl}");

                foreach (var node in productNodes)
                {
                    string imageUrl = node.SelectSingleNode("div/a[1]/div/img").Attributes["src"]?.Value;

                    try
                    {
                        var regex = new Regex("_.*/*");
                        imageUrl = regex.Replace(imageUrl, ".jpg");
                    }
                    catch { imageUrl = default; }

                    var product = new ImportProductRequest()
                    {
                        Brand = new SaveBrandRequest(),
                        ProductResource = new SaveProductResourceRequest(),
                        ProductImages = new List<SaveProductImageRequest>()
                    };

                    decimal price = default;
                    var priceText = node.SelectSingleNode("a/div/div/span[2]")?.InnerText;
                    if (!string.IsNullOrEmpty(priceText))
                    {
                        priceText = priceText.Trim().Replace("TL", "");
                        price = Math.Round(Convert.ToDecimal(priceText, culture), 2);
                    }
                    product.Name = culture.TextInfo.ToTitleCase(node.SelectSingleNode("a").Attributes["title"]?.Value);
                    product.ProductResource.IdentifierUrl = BASE_URL + node.SelectSingleNode("a").Attributes["href"]?.Value;
                    product.ProductResource.Price = price;
                    product.Brand = brand;
                    product.ProductImages.Add(new SaveProductImageRequest()
                    {
                        ImagePath = imageUrl
                    });

                    products.Add(product);
                }

                Console.WriteLine($"{brand.Name} => CRAWLING ENDED: {fullUrl} COUNT:{productNodes.Count}");
            }


            var bodyData = new StringContent(JsonSerializer.Serialize(products), Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync("http://localhost:5000/products/import/3", bodyData).Result;

            if (response.StatusCode != HttpStatusCode.OK)
                Console.WriteLine(response.StatusCode.ToString());

            Console.WriteLine($"BATCH ENDED FOR : {categoryUrl} => TOTAL PRODUCT COUNT {products.Count}");
        }
    }
}