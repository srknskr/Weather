using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Weather.Connection;
using Weather.Model;
using Weather.View;
using Xamarin.Forms;

namespace Weather.ViewModel
{
    public class AddPlacesViewModel : INotifyPropertyChanged
    {
        private string _cityName;
        public string CityName
        {
            get { return _cityName; }
            set
            {
                _cityName = value;
                OnPropertyChanged();
            }
        } 
        private string _cityKey;
        public string CityKey
        {
            get { return _cityKey; }
            set
            {
                _cityKey = value;
                OnPropertyChanged();
            }
        }
        private double _cityLat;
        public double CityLat
        {
            get { return _cityLat; }
            set
            {
                _cityLat = value;
                OnPropertyChanged();
            }
        }
        private double _cityLon;
        public double CityLon
        {
            get { return _cityLon; }
            set
            {
                _cityLon = value;
                OnPropertyChanged();
            }
        }

        private Places places = new Places();
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public AddPlacesViewModel()
        {
        }

        public ICommand TapCommand => new Command(Tap);
        private async void Tap()
        {
            Database database = new Database();
            places.CityKey = CityKey;
            places.CityName = CityName;
            places.CityLat = CityLat;
            places.CityLon = CityLon;

            database.Insert(places);
            await App.Current.MainPage.Navigation.PushModalAsync(new PlacesPage());
            DependencyService.Get<IToast>().LongToast("Your Places Added");
        }
        public ICommand BackCommand => new Command(Back);
        private async void Back()
        {
            //var mainPage = new AddPlacesPage();//this could be content page
            //var rootPage = new NavigationPage(mainPage);
            //App.Navigation = rootPage.Navigation;
            await App.Current.MainPage.Navigation.PopModalAsync();  
        }
    }
}