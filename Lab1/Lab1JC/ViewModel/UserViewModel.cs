using System;
using System.Windows.Input;
using Lab1JC.Model;
using Xamarin.Forms;

namespace Lab1JC.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        #region Properties

        private string emailAddress = String.Empty;
        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }
            set
            {
                emailAddress = value;
                OnPropertyChanged("EmailAddress");
            }
        }

        private string password = String.Empty;
        public string Password 
        {
            get 
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Passport");
            }
        }

        public ICommand SignInCommand { get; set; }

        #endregion

        #region Constructors

        public UserViewModel()
        {
            InitProperties();
            InitCommands();
        }

        private void InitProperties()
        {

        }

        private void InitCommands()
        {
            SignInCommand = new Command<UserViewModel>(SignIn);
        }

        #endregion

        #region Methods

        private void SignIn(UserViewModel model)
        {
            if(UserModel.CredentialsAreValid(model.EmailAddress, model.Password)) 
            {
                App.Current.MainPage = new View.MasterPage();
            } else 
            {
                MessagingCenter.Send(this, "InvalidSignin", "Invalid credentials. Please try again.");
            }
        }

        #endregion
    }
}
