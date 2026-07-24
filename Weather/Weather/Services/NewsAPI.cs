using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Weather.Model;

namespace Weather.Services
{
    class NewsAPI
    {
        public const string BASE_URL = "https://newsapi.org/v2/everything?q={0}&from={1}&sortBy=publishedAt&apiKey={2}";

        public static async Task<News> GetNewsAsync(string query)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd h:mm tt");
            News news = new News();
            string url = String.Format(BASE_URL, query, date, GetApiKey());
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<News>(content);
                news = posts;
            }
            return news;
        }

        private static string GetApiKey()
        {
            var apiKey = Environment.GetEnvironmentVariable("NEWS_API_KEY");
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException(
                    "Set NEWS_API_KEY outside source control before using news services.");
            }

            return apiKey;
        }
    }
}
