using System;
using System.Collections.ObjectModel;
using Lab1JC.Model;
using System.Windows.Input;
using Xamarin.Forms;
namespace Lab1JC.ViewModel
{
    public class SaleViewModel : BaseViewModel
    {
        #region Properties
        //private SaleViewModel currentSale;
        private ObservableCollection<ProductModel> productList;
        public ObservableCollection<ProductModel> ProductList
        {
            get
            {
                return productList;
            }
            set
            {
                productList = value;
                OnPropertyChanged("ProductList");
            }
        }

        public ICommand AddSaleCommand { get; set; }

        #endregion

        #region Constructors

        public SaleViewModel()
        {
            InitProperties();
            InitCommands();
        }

        private void InitProperties()
        {
            ProductList = ProductModel.FindProducts();
        }

        private void InitCommands()
        {
            AddSaleCommand = new Command(AddSale);
        }

        #endregion

        #region Methods

        private void AddSale()
        {
            //Console.WriteLine("test");
            int a = 0;
            a++;
        }

        #endregion
    }
}
