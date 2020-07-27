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
        public const string NEWS_API_KEY = "0aa6acdc93314fa380708f86053e21fc";
        public const string BASE_URL = "https://newsapi.org/v2/everything?q={0}&from={1}&sortBy=publishedAt&apiKey={2}";

        public static async Task<News> GetNewsAsync(string query)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd h:mm tt");
            News news = new News();
            string url = String.Format(BASE_URL, query, date, NEWS_API_KEY);
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

    }
}
