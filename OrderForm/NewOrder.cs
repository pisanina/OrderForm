using OrderForm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OrderForm
{
    public partial class NewOrder : Form
    {
        public NewOrder()
        {
            InitializeComponent();
            DateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
        }

        private DataTable _productsList;

        private int _productSelectionColumnIndex = 0;
        private int _quantityColumnIndex = 1;
        private int _priceColumnIndex=2;

        private int GetQuantityForRow(int rowIndex)
        {
            int result;

            int.TryParse(Products_dataGridView.Rows[rowIndex]
                    .Cells[_quantityColumnIndex].Value.ToString(), out result);

            return result;
        }

        private void NewOrder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'listOfProducts.GetProductList' table. You can move, or remove it, as needed.
            //this.getProductListTableAdapter.Fill(this.listOfProducts.GetProductList);

            using (SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OrderForm.Properties.Settings.OrderFormConnectionString"].ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlGetProductList = new SqlCommand("GetProductList", sqlConnection);
                sqlGetProductList.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlGetProductList);
                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                this.ProductName.DisplayMember = "Name";
                this.ProductName.ValueMember = "Id";
                this.ProductName.DataSource = dt;
                _productsList = dt;
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if (Products_dataGridView.Rows.Count > 0)
            {
                var cos =  Products_dataGridView.Rows[Products_dataGridView.RowCount-1].Cells[0].Value;

                if (cos is null) { MessageBox.Show("Proszę wybrać produkt"); }
                else
                {
                    Products_dataGridView.Rows.Add();
                    Products_dataGridView.Rows[Products_dataGridView.Rows.Count - 2].ReadOnly = true;
                }
            }
            else
                Products_dataGridView.Rows.Add();
        }

        private void change_button_Click(object sender, EventArgs e)
        {
            if (Products_dataGridView.SelectedRows.Count > 0)
            {
                Products_dataGridView.SelectedRows[0].ReadOnly = false;
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć wiersz do edycji");
            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if (Products_dataGridView.SelectedRows.Count > 0)
            {
                Products_dataGridView.Rows.Remove(Products_dataGridView.SelectedRows[0]);
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć wiersz do usunięcia");
            }
        }

        private void getProductListBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void Products_dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Products_dataGridView.Rows[Products_dataGridView.Rows.Count - 1]
                .Cells[_quantityColumnIndex].Value = "1";
        }

        private void Products_dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Products_dataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Products_dataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            var selectedProductId = Products_dataGridView.Rows[e.RowIndex].Cells[0].Value;

            if (selectedProductId != null)
            {
                var price = _productsList.AsEnumerable()
                .Single(myRow => myRow.Field<int>("Id") == (int)selectedProductId)
                .Field<decimal>("Price");

                Products_dataGridView.Rows[e.RowIndex]
                    .Cells[_priceColumnIndex].Value = price * GetQuantityForRow(e.RowIndex);
            }
        }

        

        private DataTable GetProductsFromGrid()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("ProductId");
            dataTable.Columns.Add("Quantity");

            foreach (DataGridViewRow row in Products_dataGridView.Rows)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["ProductId"] = row.Cells[0].Value;
                dataRow["Quantity"] = row.Cells[1].Value;
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

        private void Products_dataGridView_Validating(object sender, CancelEventArgs e)
        {
            if (Products_dataGridView.Rows.Count == 0)
            {
                e.Cancel = true;
                MessageBox.Show("Proszę dodać produkt");
            }
        }

        private void Name_textBox_Validating(object sender, CancelEventArgs e)
        {
            if (Name_textBox.Text.Length < 2 || Name_textBox.Text.Length > 32)
            {
                e.Cancel = true;
                MessageBox.Show("Wpisane imię powinno zawierać od 2 do 32 znaków");
            }
        }

        private void Name_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char enteredChar = e.KeyChar;
            if (!Char.IsControl(enteredChar) && !Char.IsLetter(enteredChar))
            {
                e.Handled = true;
            }
        }

        private void LastName_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char enteredChar = e.KeyChar;
            if (!Char.IsControl(enteredChar) && !Char.IsLetter(enteredChar))
            {
                e.Handled = true;
            }
        }

        private void LastName_textBox_Validating(object sender, CancelEventArgs e)
        {
            if (Name_textBox.Text.Length < 2 || Name_textBox.Text.Length > 32)
            {
                e.Cancel = true;
                MessageBox.Show("Wpisane nazwisko powinno zawierać od 2 do 32 znaków");
            }
        }

        private void SaveToXml_button_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                Client customer = new Client
                {
                    FirstName = Name_textBox.Text.Trim(),
                    LastName = LastName_textBox.Text.Trim(),
                    BirthDate = DateOfBirth.Value
                };

                List<Product> products = new List<Product>();

                foreach (DataGridViewRow row in Products_dataGridView.Rows)
                {
                    Product selectedProduct = new Product();
                    selectedProduct.ProductId = (int)row.Cells[_productSelectionColumnIndex].Value;
                    selectedProduct.Name = row.Cells[_productSelectionColumnIndex].FormattedValue.ToString();
                    selectedProduct.Quantity = Convert.ToInt32(row.Cells[_quantityColumnIndex].Value);
                    products.Add(selectedProduct);
                }

                Order order = new Order
                {
                    Customer = customer,
                    Products = products
                };
                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(order.GetType());
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.DefaultExt = "xml";
                    saveFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                    saveFileDialog.FileName = "Order_" + DateTime.Now.ToString("dd-MM-yy_HH-mm-ss");
                    saveFileDialog.ShowDialog();
                    //var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Order.xml";
                    // System.IO.FileStream file = System.IO.File.Create(path);
                    var file = saveFileDialog.OpenFile();
                    xmlSerializer.Serialize(file, order);
                    file.Close();
                    MessageBox.Show("Zapisano nowe zamówienie w pliku Xml");
                }
                catch (Exception ex)
                { MessageBox.Show("Wystąpił bład zapisu do XML"); }
            }
        }

        private void SaveToDB_button_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OrderForm.Properties.Settings.OrderFormConnectionString"].ConnectionString))
                    {
                        sqlConnection.Open();
                        SqlCommand sqlSaveToDB = new SqlCommand("NewOrder", sqlConnection);
                        sqlSaveToDB.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlSaveToDB.Parameters.AddWithValue("@FirstName", Name_textBox.Text.Trim()); // Wanna try some sql injection? ;)
                        sqlSaveToDB.Parameters.AddWithValue("@LastName", LastName_textBox.Text.Trim());
                        sqlSaveToDB.Parameters.AddWithValue("@BirthDate", DateOfBirth.Value);
                        sqlSaveToDB.Parameters.AddWithValue("@ListOfProduct", GetProductsFromGrid());
                        sqlSaveToDB.ExecuteNonQuery();
                    }
                    MessageBox.Show("Dodano nowe zamówienie do bazy danych");
                }
                catch (Exception ex)
                { MessageBox.Show("Wystąpił bład zapisu"); }
            }
        }
    }
}