using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Toast : ContentPage
    {
        public Toast()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IToast>().ShortToast("Lorem ipsum dolor sit amet");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            DependencyService.Get<IToast>().LongToast("Lorem ipsum dolor sit amet");
        }
    }
}