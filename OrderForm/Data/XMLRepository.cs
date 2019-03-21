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
            var customer = new Client(firstName, lastName, dateofBirth);

            var products = PopulateProductsList(productsFromGrid);

            var order = new Order(customer, products);

            SaveXML(order);
        }

      

        private List<Product> PopulateProductsList(DataGridViewRowCollection grid)
        {
            List<Product> products = new List<Product>();

            foreach (DataGridViewRow row in grid)
            {
                Product selectedProduct = new Product(
                    (int)row.Cells[Constant.ProductSelectionColumnIndex].Value,
                    row.Cells[Constant.ProductSelectionColumnIndex].FormattedValue.ToString(),
                    Convert.ToInt32(row.Cells[Constant.QuantityColumnIndex].Value));
                products.Add(selectedProduct);
            }
            return products;
        }

       

        private void SaveXML(Order order)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(order.GetType());
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog.FileName = "Order_" + DateTime.Now.ToString("dd-MM-yy_HH-mm-ss");
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var file = saveFileDialog.OpenFile();
                xmlSerializer.Serialize(file, order);
                file.Close();
            }
        }
    }
}