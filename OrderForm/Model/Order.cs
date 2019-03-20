using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderForm.Model
{
   public class Order
    {
        public Client Customer        { get; set; }
        public List<Product> Products { get; set; }
    }
}
