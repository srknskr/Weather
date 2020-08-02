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

            var result = database.Insert(places);
           
            await Shell.Current.Navigation.PushAsync(new PlacesPage());
            DependencyService.Get<IToast>().LongToast("Your Places Added");
        }
    }
}