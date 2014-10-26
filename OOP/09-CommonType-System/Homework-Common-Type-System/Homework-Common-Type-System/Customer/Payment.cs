namespace Customer
{
    // Define a class Payment which holds a product name and price.
    class Payment
    {
        public string ProductName { get; private set; }

        public decimal Price { get; private set; }

        public Payment(string productName, decimal price)
        {
            ProductName = productName;
            Price = price;
        }
    }
}
