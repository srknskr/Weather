using System;
using Weather.View;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk3NDk0QDMxMzgyZTMyMmUzMEY4b3pZZUtOcldJWHNIMFZhMithVlA3ZlBISWJBbVZNSEcrdjNnb2lXaFk9");
            InitializeComponent();
            MainPage = new AppShell();
          //MainPage = new ProgressBarPage();
        }

        protected override void OnStart()
        {
            VersionTracking.Track();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
