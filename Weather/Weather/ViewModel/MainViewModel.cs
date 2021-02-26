using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Weather.Model;
using Weather.Services;
using Weather.View;
using Xamarin.Forms;

namespace Weather.ViewModel
{
    public class MainViewModel
    {
        public ICommand GoPlacesCommand => new Command(GoPlaces);
        private async void GoPlaces()
        {
            var viewModel = new PlacesViewModel();
            var placesPage = new PlacesPage { BindingContext = viewModel };
            await App.Current.MainPage.Navigation.PushModalAsync(placesPage);
        }


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
            var weather = await WeatherAPI.GetOneCallAPIAsync(20, 20, "metric");
            WeatherList.Add(weather);
        }

        public MainViewModel()
        {
            Task.Run(APIAsync);
        }

    }
}
