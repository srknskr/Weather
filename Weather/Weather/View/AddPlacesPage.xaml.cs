﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Connection;
using Weather.Model;
using Weather.ViewModel;
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
            BindingContext = new AddPlacesViewModel();
        }           
    }
}