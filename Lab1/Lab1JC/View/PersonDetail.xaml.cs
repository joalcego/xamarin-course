using System;
using System.Collections.Generic;
using Lab1JC.ViewModel;
using Xamarin.Forms;

namespace Lab1JC.View
{
    public partial class PersonDetail : ContentPage
    {
        public PersonDetail()
        {
            InitializeComponent();
            BindingContext = PersonViewModel.GetInstance();
        }
    }
}
