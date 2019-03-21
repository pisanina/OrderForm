using OrderForm.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OrderForm.Data
{
    internal class XMLRepository : IWriteRepository
    {
        public void Save(string firstName, string lastName, DateTime dateofBirth
           , DataGridViewRowCollection productsFromGrid)
        {
            var customer = PopulateCustomer(firstName, lastName, dateofBirth);

            var products = PopulateProductsList(productsFromGrid);

            var order =PopulateOrder(customer, products);

            SaveXML(order);
        }

        private Client PopulateCustomer(string firstName, string lastName, DateTime birthDate)
        {
            Client customer = new Client
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate
            };
            return customer;
        }

        private List<Product> PopulateProductsList(DataGridViewRowCollection grid)
        {
            List<Product> products = new List<Product>();

            foreach (DataGridViewRow row in grid)
            {
                Product selectedProduct = new Product();
                selectedProduct.ProductId = (int)row.Cells[Constant.ProductSelectionColumnIndex].Value;
                selectedProduct.Name = row.Cells[Constant.ProductSelectionColumnIndex].FormattedValue.ToString();
                selectedProduct.Quantity = Convert.ToInt32(row.Cells[Constant.QuantityColumnIndex].Value);
                products.Add(selectedProduct);
            }
            return products;
        }

        private Order PopulateOrder(Client customer, List<Product> products)
        {
            Order order = new Order
            {
                Customer = customer,
                Products = products
            };
            return order;
        }

        private void SaveXML(Order order)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(order.GetType());
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog.FileName = "Order_" + DateTime.Now.ToString("dd-MM-yy_HH-mm-ss");
            saveFileDialog.ShowDialog();

            var file = saveFileDialog.OpenFile();
            xmlSerializer.Serialize(file, order);
            file.Close();
        }
    }
}