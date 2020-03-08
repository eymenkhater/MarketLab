using System;
using System.Net;
using System.Net.Http;
namespace DataCrawler.Extensions
{
    public static class HttpExtension
    {
        private static HttpClient _httpClient = new HttpClient();
        public static string LoadBody(string url)
        {
            var response = _httpClient.GetAsync(url).Result;

            if (response.StatusCode != HttpStatusCode.OK)
                throw new ArgumentException(response.StatusCode.ToString());

            var body = response.Content.ReadAsStringAsync().Result;

            return body;
        }
    }
}