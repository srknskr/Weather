using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Connection;
using Weather.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPlacesPage : ContentPage
    {
        
        public AddPlacesPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Database database = new Database();

            Places places = new Places();
            places.CityName = cityName.Text;
            places.CityKey = cityKey.Text;

            var result = database.Insert(places);

            if (result > 0)
            {
                DisplayAlert(places.CityName, "Added", "OK");
                database.GetAll();
                await Navigation.PushModalAsync(new PlacesPage());

            }
            else
            {
                DisplayAlert("Error", "Don't Added!", "Ok");
            }
            database.GetAll();
        }
           
            
    }
}