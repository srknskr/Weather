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
            var syncfusionLicense =
                Environment.GetEnvironmentVariable("SYNCFUSION_LICENSE_KEY");
            if (!string.IsNullOrWhiteSpace(syncfusionLicense))
            {
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
                    syncfusionLicense);
            }

            InitializeComponent();
            MainPage = new MainPage();
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
