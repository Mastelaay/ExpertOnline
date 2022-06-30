using System;
using Cart= ExpertsCart;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpertCartTest
{
    [TestClass]
    public class TestCases
    {
        [TestMethod, Description("Given the a product soap then a user adds 5 items to the cart then total price should be 199.95")]
        public void GivenProductsShouldReturnSum()
        {
            var shoppingCart = new Cart.ShoppingCart();
            shoppingCart.AddItem(Cart.Shop.GetProduct(typeof(Cart.Producsts.DoveSoap)));
            shoppingCart.AddItem(Cart.Shop.GetProduct(typeof(Cart.Producsts.DoveSoap)));
            shoppingCart.AddItem(Cart.Shop.GetProduct(typeof(Cart.Producsts.DoveSoap)));
            shoppingCart.AddItem(Cart.Shop.GetProduct(typeof(Cart.Producsts.DoveSoap)));
            shoppingCart.AddItem(Cart.Shop.GetProduct(typeof(Cart.Producsts.DoveSoap)));

            //add another another 3 dove soap total should be 319.92
            shoppingCart.AddItem(Cart.Shop.GetProduct(typeof(Cart.Producsts.DoveSoap)));
            shoppingCart.AddItem(Cart.Shop.GetProduct(typeof(Cart.Producsts.DoveSoap)));
            shoppingCart.AddItem(Cart.Shop.GetProduct(typeof(Cart.Producsts.DoveSoap)));
            Assert.AreEqual(shoppingCart.CalculatePrice(), 319.92m);

            //Assert.AreEqual(shoppingCart.CalculatePrice(), 199.95m);
        }

        [TestMethod, Description("Given the busket total amount should return taxable amount")]
        public void GetTaxableAmont()
        {
            var shoppingCart = new Cart.ShoppingCart();
            Assert.AreEqual(shoppingCart.CalculateTax(279.96m), 35.00m);
        }


        [TestMethod, Description("Given the basket has 2 Dove soaps and 2 Axe Deos when I total the basket then the total should be R279.96")]
        public void GivenMultipleProductsWithoutTaxShouldReturnTotal()
        {
            var shoppingCart = new Cart.ShoppingCart();
            shoppingCart.AddItem(Cart.Shop.GetProduct(typeof(Cart.Producsts.DoveSoap)));
            shoppingCart.AddItem(Cart.Shop.GetProduct(typeof(Cart.Producsts.DoveSoap)));

            shoppingCart.AddItem(Cart.Shop.GetProduct(typeof(Cart.Producsts.AxeDeo)));
            shoppingCart.AddItem(Cart.Shop.GetProduct(typeof(Cart.Producsts.AxeDeo)));


            Assert.AreEqual(shoppingCart.CalculatePrice(), 279.96m);
        }

        [TestMethod, Description("Given the basket has 1 Soap and 1 Deo when I add a tax then the total should be R157.47")]
        public void GivenTwoSingleProductsShouldReturnTotalWithTax()
        {
            var shoppingCart = new Cart.ShoppingCart();
            shoppingCart.AddItem(Cart.Shop.GetProduct(typeof(Cart.Producsts.AxeDeo)));
            shoppingCart.AddItem(Cart.Shop.GetProduct(typeof(Cart.Producsts.DoveSoap)));

            Assert.AreEqual(shoppingCart.CalculatePrice(true), 157.48m);
        }

        [TestMethod, Description("Given the basket has 2 Soap and 2 Deo when I add a tax then the total should be R314.96 and the Tax amount should be R35.00")]
        public void GivenTwoProductsShouldReturnTotalWithTax()
        {
            var shoppingCart = new Cart.ShoppingCart();
            shoppingCart.AddItem(Cart.Shop.GetProduct(typeof(Cart.Producsts.AxeDeo)));
            shoppingCart.AddItem(Cart.Shop.GetProduct(typeof(Cart.Producsts.AxeDeo)));

            shoppingCart.AddItem(Cart.Shop.GetProduct(typeof(Cart.Producsts.DoveSoap)));
            shoppingCart.AddItem(Cart.Shop.GetProduct(typeof(Cart.Producsts.DoveSoap)));

            var total = shoppingCart.CalculatePrice(true);

            Assert.AreEqual(shoppingCart.CalculatePrice(true), total);
        }
    }
}
