using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Lab1JC.ViewModel;

namespace Lab1JC.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = PersonViewModel.GetInstance();
        }
    }
}
