using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.Model;

namespace Weather.Services
{
    class WeatherAPI
    {
        public const string OPENWEATHERMAP_API_KEY = "ece317b574b62dbc425b34aedcc2a774";
        public const string BASE_URL = "https://api.openweathermap.org/data/2.5/forecast?q={0}&appid={1}&units=metric";
        public const string BASE_URL2 = "https://api.openweathermap.org/data/2.5/onecall?lat={0}&lon={1}&units={2}&appid={3}";
        public static async Task<FiveDayThreeHours> GetFiveDaysAsync(string query)
        {
            FiveDayThreeHours weather = new FiveDayThreeHours();
            string url = String.Format(BASE_URL, query, OPENWEATHERMAP_API_KEY);
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<FiveDayThreeHours>(content);
                weather = posts;
            }
            return weather;
        }
        public static async Task<OneCallAPI> GetOneCallAPIAsync(double lat, double lon, string units)
        {
            OneCallAPI weather = new OneCallAPI();
            string url = String.Format(BASE_URL2, lat, lon, units, OPENWEATHERMAP_API_KEY);
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<OneCallAPI>(content);
                weather = posts;
            }
            return weather;
        }
    }
}
