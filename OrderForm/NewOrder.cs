using OrderForm.Data;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class NewOrder : Form
    {
        private IWriteRepository _xmlRepo;
        private IReadWriteRepository _dbRepo;

        public NewOrder()
        {
            InitializeComponent();

            _xmlRepo = DataFactory.CreateDataMethod<IWriteRepository>();
            _dbRepo = DataFactory.CreateDataMethod<IReadWriteRepository>();

            DateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
        }

        private DataTable _productsList;

        private int GetQuantityForRow(int rowIndex)
        {
            int result;

            int.TryParse(Products_dataGridView.Rows[rowIndex]
                    .Cells[Constant.QuantityColumnIndex].Value.ToString(), out result);

            return result;
        }

        private void NewOrder_Load(object sender, EventArgs e)
        {
            DataTable dt;
            try
            {
                dt = _dbRepo.Read();
            }
            catch
            {
                MessageBox.Show("Błąd połączenia z bazą danych!");
                return;
            }

            _productsList = dt;
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            ProductSelection Select = new ProductSelection(_productsList);

            if (Select.ShowDialog() == DialogResult.OK)
            {
                Products_dataGridView.Rows.Add();

                int currentRow = Products_dataGridView.Rows.Count-1;
                PopulatingGrid(Select, currentRow);
            }
        }

        private void PopulatingGrid(ProductSelection Select, int currentRow)
        {
            Products_dataGridView.Rows[currentRow]
                                        .Cells[Constant.ProductNameColumnIndex].Value = Select.SelectedProductName;

            Products_dataGridView.Rows[currentRow].Cells[Constant.ProductIDColumnIndex].Value = Select.SelectedProductId;
            Products_dataGridView.Rows[currentRow].Cells[Constant.QuantityColumnIndex].Value = Select.SelectedQuantity;

            var price = _productsList.AsEnumerable()
                .Single(myRow => myRow.Field<int>("Id") == (int)Select.SelectedProductId)
                .Field<decimal>("Price");

            Products_dataGridView.Rows[currentRow]
                .Cells[Constant.PriceColumnIndex].Value = (price * GetQuantityForRow(currentRow)).ToString("0.00");
        }

        private void change_button_Click(object sender, EventArgs e)
        {
            if (Products_dataGridView.SelectedRows.Count > 0)
            {
                int productId = Convert.ToInt32(Products_dataGridView.CurrentRow.Cells[Constant.ProductIDColumnIndex].Value);
                int quantity = Convert.ToInt32(Products_dataGridView.CurrentRow.Cells[Constant.QuantityColumnIndex].Value);
                ProductSelection Select = new ProductSelection(productId, quantity, _productsList);

                if (Select.ShowDialog() == DialogResult.OK)
                {
                    PopulatingGrid(Select, Products_dataGridView.CurrentRow.Index);
                }
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
                Products_dataGridView.Rows.Remove(Products_dataGridView.CurrentRow);
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć wiersz do usunięcia");
            }
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
            if (!IsAlphaCharacter(enteredChar))
            {
                e.Handled = true;
            }
        }

        private void LastName_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char enteredChar = e.KeyChar;
            if (!IsAlphaCharacter(enteredChar))
            {
                e.Handled = true;
            }
        }

        private bool IsAlphaCharacter(char enteredChar)
        {
            return Char.IsControl(enteredChar) || Char.IsLetter(enteredChar);
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
            if (ValidateChildren())
            {
                try
                {
                    _xmlRepo.Save(Name_textBox.Text.Trim(), LastName_textBox.Text.Trim(),
                                        DateOfBirth.Value, Products_dataGridView.Rows);
                }
                catch (Exception ex)
                { MessageBox.Show("Wystąpił bład zapisu do XML"); }
            }
        }

        private void SaveToDB_button_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    _dbRepo.Save(Name_textBox.Text.Trim(),
                            LastName_textBox.Text.Trim(), DateOfBirth.Value, Products_dataGridView.Rows);

                    MessageBox.Show("Dodano nowe zamówienie do bazy danych");
                }
                catch (SqlException exSql)
                {
                    if (exSql.ToString().Contains("CH_Product_Availability"))
                    {
                        MessageBox.Show("Przekroczone stany magazynowe");
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił bład zapisu");
                }
            }
        }
    }
}