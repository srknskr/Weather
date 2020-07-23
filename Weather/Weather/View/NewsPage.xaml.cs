using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.View
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
        {
            InitializeComponent();
            this.BindingContext = new NewsViewModel();
        }
    }
}