using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Weather.Connection;
using Weather.Model;
using Weather.View;
using Xamarin.Forms;

namespace Weather.ViewModel
{
    public class PlacesViewModel : INotifyPropertyChanged
    {
        private static Database database = null;

        //public ICommand SelectionCommand => new Command(GoWeather);
        //private async void GoWeather(object obj)
        //{
        //    await Shell.Current.Navigation.PushModalAsync(new WeatherPage());
        //}

        private static Database GetConnection()
        {
            if (database == null)
                database = new Database();
            return database;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private IEnumerable<Places> _places;

        public IEnumerable<Places> Places
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
        private Places _placess;
        public Places Placess
        {
            get { return _placess; }
            set
            {
                _placess = value;
                OnPropertyChanged();
            }
        }
        public PlacesViewModel()
        {
         //   GetConnection().FullDelete();
            Places = GetConnection().GetAll();
        }
        public ICommand SelectionCommand => new Command(GoToWeatherAsync);
        private async void GoToWeatherAsync(object obj)
        {

            if (selectedPlaces != null)
            {
                var viewModel = new WeatherViewModel(selectedPlaces);
                var weatherPage = new WeatherPage { BindingContext = viewModel };
                await Shell.Current.Navigation.PushAsync(weatherPage);
            }
        }




        public ICommand BackCommand => new Command(Back);
        private async void Back()
        {
            //var mainPage = new AddPlacesPage();//this could be content page
            //var rootPage = new NavigationPage(mainPage);
            //App.Navigation = rootPage.Navigation;

           await App.Current.MainPage.Navigation.PopModalAsync();

        }
        public ICommand TapCommand => new Command(Tap);
        private async void Tap()
        {
            //var mainPage = new AddPlacesPage();//this could be content page
            //var rootPage = new NavigationPage(mainPage);
            //App.Navigation = rootPage.Navigation;
            await App.Current.MainPage.Navigation.PushModalAsync(new AddPlacesPage());
        }
        public ICommand DeleteCommand => new Command(Delete);
        private async void Delete()
        {
            GetConnection().Delete(selectedPlaces.Id);
            Places = GetConnection().GetAll();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
