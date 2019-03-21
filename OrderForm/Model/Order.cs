using System.Collections.Generic;

namespace OrderForm.Model
{
    public class Order
    {
        public Client Customer { get; set; }
        public List<Product> Products { get; set; }

        public Order() {  }

        public Order(Client customer, List<Product> products)
        {
            Customer = customer;
            Products = products;
        }
    }
    
   
}