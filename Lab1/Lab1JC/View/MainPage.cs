using Xamarin.Forms;
using Lab1JC.ViewModel;

namespace Lab1JC
{
    public partial class Lab1JCPage : ContentPage
    {
        public Lab1JCPage()
        {
            InitializeComponent();

            BindingContext = new PersonViewModel();
        }
    }
}
