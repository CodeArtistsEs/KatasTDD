namespace KatasTDD.Kata2
{
    internal class CartItem
    {
        public int Quantity { get; set; }
        public string Description { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalPrice { get; private set; }

        public CartItem(int quantity, string description, decimal unitPrice)
        {
            Quantity = quantity;
            Description = description;
            UnitPrice = unitPrice;
        }

        public decimal GetItemPrice()
        {
            TotalPrice = (Quantity * UnitPrice);
            var dicountPercentage = Discount / 100;
            TotalPrice = TotalPrice - (TotalPrice * dicountPercentage);

            return TotalPrice < 0m ? 0m : TotalPrice;
        }

        public void ApplyDiscount(decimal discountAmount)
        {
            Discount = discountAmount;
        }

        public override string ToString()
        {
            var unitPriceAsString = (UnitPrice * Quantity).ToString("#.00");
            return "The item " + Description + " has a total value of " + unitPriceAsString;
        }
    }
}