using System;
namespace Lab1JC.Model
{
    public class SaleModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public ProductModel Product { get; set; }

        public double TotalPrice
        {
            get {
                return Amount * Product.Price;
            }
        }
    }
}
