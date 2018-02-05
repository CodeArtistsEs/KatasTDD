using System.Collections.Generic;

namespace KatasTDD.Kata2
{
    internal class Cart
    {
        public List<CartItem> Items { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
            Total = 0;
            Discount = 0;
        }

        public void AddItem(CartItem item)
        {
            if (Items.Contains(item))
                return;

            Items.Add(item);
        }

        public void RemoveItem(CartItem item)
        {
            Items.Remove(item);
        }

        public decimal GetCartTotal()
        {
            
            foreach (var item in Items)
            {
                Total += item.GetItemPrice();
            }

            return Total;
        }

        public void ApplyDiscount()
        {
            Total = Total - (Total * (Discount / 100));
        }

        public void AddDiscount(decimal discount)
        {
            Discount = discount;
        }
    }
}