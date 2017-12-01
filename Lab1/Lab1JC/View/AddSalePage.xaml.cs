using System;
using System.Collections.Generic;
using Lab1JC.ViewModel;

using Xamarin.Forms;

namespace Lab1JC.View
{
    public partial class AddSalePage : ContentPage
    {
        public AddSalePage()
        {
            InitializeComponent();
            BindingContext = new SaleViewModel();
        }
    }
}
