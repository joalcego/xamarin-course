using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Lab3.ViewModel;

namespace Lab3.View
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = CRUDTestViewModel.GetInstance();
        }
    }
}
