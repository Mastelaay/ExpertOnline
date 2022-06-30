using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertsCart
{
    public static class Shop
    {
        /* Products and Price mappings */
        public static Dictionary<Type, decimal> AvailableProducts = new Dictionary<Type, decimal>() {
            {typeof(Producsts.AxeDeo), 99.99m},
            {typeof (Producsts.DoveSoap), 39.99m}
        };


        /* Factory method which returns a Product with its actual price */
        public static Product GetProduct(Type product)
        {
            if (Shop.AvailableProducts.TryGetValue(product, out decimal price))
            {
                return (Product)Activator.CreateInstance(product, new Object[] { price });
            }
            else
            {
                throw new ArgumentOutOfRangeException("Product does not exist ");
            }
        }

        /* This CalculatePrice method only calculates the price of products depending on the count of a type and uses a tax scenarios if exist */
        public static decimal CalculatePrice(List<Product> items, bool tax)
        {
            decimal sum = 0m;
            decimal taxAmount = 0m;

            foreach (Type product in Shop.AvailableProducts.Keys)
            {

                var products = items.Where(p => p.GetType() == product).ToList();
                var count = products.Count();

                if (count > 0)
                {
                    sum += count * products[0].Price;
                }
            }

            if (tax)
            {
                decimal totalTax = CalculateTax(sum);
                taxAmount = totalTax + sum;
                return taxAmount;
            }

            return decimal.Round(sum, 2, MidpointRounding.AwayFromZero);
        }

        public static decimal CalculateTax(decimal totalPrice)
        {
            decimal taxRate = Convert.ToDecimal(12.5m);
            var calcTax = totalPrice * taxRate / 100m;
            return decimal.Round(calcTax, 2, MidpointRounding.AwayFromZero); ;

        }
    }
}
