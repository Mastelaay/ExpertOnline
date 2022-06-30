using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertsCart
{
    public class ShoppingCart
    {
        
        private List<Product> items = new List<Product>();
        public void AddItem(Product item)
        {
            items.Add(item);
        }
        public decimal CalculatePrice(bool tax = false)
        {
            return Shop.CalculatePrice(this.items, tax);
        }

        public decimal CalculateTax(decimal price)
        {
            return Shop.CalculateTax(price);
        }
    }
}
