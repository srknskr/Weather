using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Weather.Connection;
using Weather.Model;
using Weather.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlacesPage : ContentPage
    {
        public PlacesPage()
        {
            InitializeComponent();
            BindingContext = new PlacesViewModel();
        }
        private void SavePlace(object sender, EventArgs e)
        {
            Places places = new Places();
            //places.CityName = cityName.Text;
            //places.CityKey = cityKey.Text;

            Database database = new Database();
            var result = database.Insert(places);
            if (result > 0)
            {
                DisplayAlert(places.CityName, "Added", "OK");
                database.GetAll();
            }
            else
            {
                DisplayAlert("Hata Oluştu", "Öğrenci Eklenemedi!", "Ok");
            }
            database.GetAll();
            BindingContext = new PlacesViewModel();

        }



        private async void lstItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selected = (Places)e.SelectedItem;
            var accepted = await DisplayAlert(selected.CityName, "Silinsin mi?", "Evet", "Vazgeç");
            if (accepted)
            {
                Database _client = new Database();
                _client.Delete(selected.Id);
            }
            BindingContext = new PlacesViewModel();
        }

        //private async void ImageButton_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new AddPlacesPage());
        //}

        
    }
}