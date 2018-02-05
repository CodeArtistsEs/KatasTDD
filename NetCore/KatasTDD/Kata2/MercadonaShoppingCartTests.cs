using System;
using Xunit;

namespace KatasTDD.Kata2
{
    public class MercadonaShoppingCartTests : IDisposable
    {
        private Cart _cart;
        private CartItem _cartItem;
        private CartItem _cartItem2;
        private CartItem _cartItem3;

        //Setup
        public MercadonaShoppingCartTests()
        {
            this._cart = new Cart();
            _cartItem = new CartItem(2, "Test", 1.00m); 
            _cartItem2 = new CartItem(3, "Test2", 2.00m);
            _cartItem3 = new CartItem(3, "Test3", 2.50m);
            // total: 8
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

        [Fact]
        public void CartHasTotalDiscountZeroByDefault()
        {
            _cart.AddItem(_cartItem); // 2
            _cart.AddItem(_cartItem2); // 6

            var total = _cart.GetCartTotal();
            _cart.ApplyDiscount();


            Assert.Equal(_cart.Total, 8);

        }

        [Fact]
        public void CartHasTotalDiscount()
        {
            _cart.AddItem(_cartItem); // 2
            _cart.AddItem(_cartItem2); // 6

            var total = _cart.GetCartTotal();
            _cart.AddDiscount(25.00m);
            _cart.ApplyDiscount();


            Assert.Equal(_cart.Total, 6);
        }

        [Fact]
        public void ItemHasNameAndValueAsTostring()
        {
            var toStringResult = _cartItem3.ToString();

            Assert.Equal("The item Test3 has a total value of 7.50", toStringResult);
        }

        [Fact]
        public void ItemCanHavePercentageDiscount()
        {
            _cartItem.ApplyDiscount(100);
            decimal totalAferDiscount = _cartItem.GetItemPrice();
            
            Assert.Equal(0,totalAferDiscount);

        }

        //Teardown
        public void Dispose()
        {
         
        }
    }
}
