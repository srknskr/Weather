using MarcTron.Plugin;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdMobPage : ContentPage
    {
        public AdMobPage()
        {
            InitializeComponent();
            CrossMTAdmob.Current.OnInterstitialLoaded += (s, args) => {
                CrossMTAdmob.Current.ShowInterstitial();
            };
            CrossMTAdmob.Current.OnRewardedVideoAdLoaded += (s, args) => {
                CrossMTAdmob.Current.ShowRewardedVideo();
            };
        }
        private void Interstitial_Clicked(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.LoadInterstitial("ca-app-pub-3940256099942544/1033173712");
        }
        private void Rewarded_Clicked(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.LoadRewardedVideo("ca-app-pub-3940256099942544/5224354917");
        }
    }
}