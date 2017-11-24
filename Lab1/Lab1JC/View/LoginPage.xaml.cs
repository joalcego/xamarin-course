using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Lab1JC.ViewModel;

namespace Lab1JC.View
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new UserViewModel();
            MessagingCenter.Subscribe<UserViewModel, string>(this, "InvalidSignin", (sender, args) =>
            {
                DisplayAlert("Problem signing in!", args, "Ok");
            });
        }
    }
}
