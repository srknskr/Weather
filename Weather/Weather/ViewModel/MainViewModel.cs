using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Weather.Model;
using Weather.Services;

namespace Weather.ViewModel
{
    public class MainViewModel
    {
        private IList<OneCallAPI> _weatherList;
        public IList<OneCallAPI> WeatherList
        {
            get
            {
                if (_weatherList == null)
                    _weatherList = new ObservableCollection<OneCallAPI>();
                return _weatherList;
            }
            set
            {
                _weatherList = value;
            }
        }

        private async Task APIAsync()
        {
            var weather = await WeatherAPI.GetOneCallAPIAsync(56, 45, "metric");
            //    var weather = await WeatherAPI.GetFiveDaysAsync("Istanbul");
            WeatherList.Add(weather);


        }

        public MainViewModel()
        {
            Task.Run(APIAsync);
        }
    }
}
