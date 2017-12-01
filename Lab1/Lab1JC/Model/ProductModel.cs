using System;
using System.Collections.ObjectModel;
namespace Lab1JC.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public static ObservableCollection<ProductModel> FindProducts()
        {
            return new ObservableCollection<ProductModel>()
            {
                new ProductModel() {
                    Id = 1,
                    Description = "Lavadora",
                    Price = 400000
                },
                new ProductModel() {
                    Id = 2,
                    Description = "Cocina",
                    Price = 275000
                },
                new ProductModel() {
                    Id = 3,
                    Description = "Coffee Maker",
                    Price = 28900
                }
            };
        }
    }
}
