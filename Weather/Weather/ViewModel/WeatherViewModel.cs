using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Weather.Model;
using Weather.Services;

namespace Weather.ViewModel
{
    public class WeatherViewModel
    {
        private IList<FiveDayThreeHours> _weatherList;
        public IList<FiveDayThreeHours> WeatherList
        {
            get
            {
                if (_weatherList == null)
                    _weatherList = new ObservableCollection<FiveDayThreeHours>();
                return _weatherList;
            }
            set
            {
                _weatherList = value;
            }
        }
        public WeatherViewModel()
        {
            Task.Run(APIAsync);
        }
        private async Task APIAsync()
        {
            var weather = await WeatherAPI.GetFiveDaysAsync("London");
            WeatherList.Add(weather);
        }
    }
}
