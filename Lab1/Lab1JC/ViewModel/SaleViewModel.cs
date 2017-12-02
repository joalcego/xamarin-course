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
        private ProductModel product;
        public ProductModel Product
        {
            get
            {
                return product;
            }
            set
            {
                product = value;
                OnPropertyChanged("Product");
            }
        }

        private int amount;
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }

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
            var sale = new SaleModel()
            {
                Product = this.Product,
                Amount = this.Amount
            };

            PersonViewModel.GetInstance().CurrentPerson.Sales.Add(sale);
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopAsync();
        }

        #endregion
    }
}
