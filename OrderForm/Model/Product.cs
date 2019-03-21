namespace OrderForm.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Product() {  }

        public Product(int productId, string name, int quantity)
        {
            ProductId = productId;
            Name = name;
            Quantity = quantity;
        }
    }
}