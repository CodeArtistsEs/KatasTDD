using System;
using Xunit;

namespace KatasTDD.Kata2
{
    public class MercadonaShoppingCartTests : IDisposable
    {
        private Cart _cart;
        private CartItem _cartItem;
        private CartItem _cartItem2;

        //Setup
        public MercadonaShoppingCartTests()
        {
            _cart = new Cart();
            _cartItem = new CartItem(2, "Test", 1.00m); 
            _cartItem2 = new CartItem(3, "Test2", 2.00m);  
        }

        [Fact]
        public void CartCanContainZeroItem()
        {
            Assert.Equal(0, _cart.Items.Count);
        }

        [Fact]
        public void CartCanAddItem()
        {
            _cart.AddItem(_cartItem);

            Assert.Contains(_cartItem,_cart.Items);
        }

        [Fact]
        public void CartContainsNoDuplicateItems()
        {
            _cart.AddItem(_cartItem);
            _cart.AddItem(_cartItem);

            Assert.Equal(_cart.Items.Count, 1);
        }

        [Fact]
        public void CartCanRemoveItem()
        {
            _cart.AddItem(_cartItem);
            _cart.RemoveItem(_cartItem);

            Assert.Equal(_cart.Items.Count, 0);
        }

        [Fact]
        public void TotalEqualsSumOfItemPrices()
        {
            _cart.AddItem(_cartItem);
            _cart.AddItem(_cartItem2);

            var actual = _cart.GetCartTotal();

            Assert.Equal(actual, 8);
        }

        //Teardown
        public void Dispose()
        {
         
        }
    }
}
