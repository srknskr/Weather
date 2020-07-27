using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Weather.Connection;
using Weather.Model;
using Weather.Services;

namespace Weather.ViewModel
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private static Database database = null;

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
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;


        private Places selectedPlaces;
        public Places SelectedPlaces
        {
            get { return selectedPlaces; }
            set
            {
                selectedPlaces = value;
                OnPropertyChanged();
            }
        }
        private List<Main> weekList { get; set; }
        public List<Main> WeekList
        {
            get
            {
                return weekList;
            }

            set
            {
                if (value != weekList)
                {
                    weekList = value;
                    OnPropertyChanged();
                }
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private List<Places> _places;

        public List<Places> Places
        {
            get
            {
                return _places;
            }

            set
            {
                _places = value;
                OnPropertyChanged();
            }
        }
        private static Database GetConnection()
        {
            if (database == null)
                database = new Database();
            return database;
        }
        public WeatherViewModel(Places selectedPlaces)
        {

            this.selectedPlaces = selectedPlaces;
            Task.Run(SelectedCityAsync);
        }
        public WeatherViewModel()
        {
            Places = GetConnection().GetFirst();
            Task.Run(APIAsync);

        }
        private async Task APIAsync()
        {
          //  var weather = await WeatherAPI.GetFiveDaysAsync(selectedPlaces.CityName);
            var weather = await WeatherAPI.GetFiveDaysAsync(Places[0].CityName);
            WeatherList.Add(weather);

            List<Main> week = new List<Main>();
            for (int i = 1; i < 7; i++)
            {
                week.Add(new Main
                {
                    temp = weather.list[i].main.temp,
                    feels_like = weather.list[i].main.feels_like
                }) ;
            }
            WeekList = week;
        }
        private async Task SelectedCityAsync()
        {
            var weather = await WeatherAPI.GetFiveDaysAsync(selectedPlaces.CityName);
            WeatherList.Add(weather);
        }

    }
}
