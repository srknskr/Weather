using MonkeyCache.FileStore;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.Model;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Weather.Services
{
    class WeatherAPI
    {
        public const string OPENWEATHERMAP_API_KEY = "ece317b574b62dbc425b34aedcc2a774";
        public const string BASE_URL = "https://api.openweathermap.org/data/2.5/forecast?q={0}&appid={1}&units=metric";
        public const string BASE_URL2 = "https://api.openweathermap.org/data/2.5/onecall?lat={0}&lon={1}&units={2}&appid={3}";

        public WeatherAPI()
        {
        }


        public static async Task<FiveDayThreeHours> GetFiveDaysAsync(string query)
        {

            try
            {

                FiveDayThreeHours weather = new FiveDayThreeHours();
                string url = String.Format(BASE_URL, query, OPENWEATHERMAP_API_KEY);

                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: url))
                {
                    await Task.Yield();
                    DependencyService.Get<IToast>().LongToast("Please check your internet connection");
                    return Barrel.Current.Get<FiveDayThreeHours>(key: url);
                }

                HttpClient httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var posts = JsonConvert.DeserializeObject<FiveDayThreeHours>(content);
                    weather = posts;
                }

                Barrel.Current.Add(key: url, data: weather, expireIn: TimeSpan.FromDays(1));

                return weather;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
public static async Task<OneCallAPI> GetOneCallAPIAsync(double lat, double lon, string units)
{
    Barrel.ApplicationId = "WeatherCache";

    OneCallAPI weather = new OneCallAPI();
    string url = String.Format(BASE_URL2, lat, lon, units, OPENWEATHERMAP_API_KEY);

    //check connectivity, if not get data from cache
    if (Connectivity.NetworkAccess != NetworkAccess.Internet && !Barrel.Current.IsExpired(key: url))
    {
        await Task.Yield();
        return Barrel.Current.Get<OneCallAPI>(key: url);

    }

    HttpClient httpClient = new HttpClient();
    var response = await httpClient.GetAsync(url);
    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadAsStringAsync();
        var posts = JsonConvert.DeserializeObject<OneCallAPI>(content);
        // Add cache
        Barrel.Current.Add(key: url, data: posts, expireIn: TimeSpan.FromDays(1));
        weather = posts;



    }

    return weather;



}
    }
}
