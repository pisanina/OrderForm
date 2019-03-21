using OrderForm.Data;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
            _xmlRepo = new XMLRepository();
            _dbRepo = new DBRepository();
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
            var dt =_dbRepo.Read();

            this.ProductName.DisplayMember = "Name";
            this.ProductName.ValueMember = "Id";
            this.ProductName.DataSource = dt;
            _productsList = dt;
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

                    for (int i = 0; i < Products_dataGridView.RowCount-1; i++)
                    {
                        Products_dataGridView.Rows[i].ReadOnly = true;
                        Products_dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                    }
                  
                }
            }
            else
                Products_dataGridView.Rows.Add();
        }

        private void change_button_Click(object sender, EventArgs e)
        {
            if (Products_dataGridView.SelectedRows.Count > 0)
            {
                Products_dataGridView.CurrentRow.ReadOnly = false;
                Products_dataGridView.CurrentRow.DefaultCellStyle.BackColor = Color.White;
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

        private void Products_dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Products_dataGridView.Rows[Products_dataGridView.Rows.Count - 1]
                .Cells[Constant.QuantityColumnIndex].Value = "1";
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
                    .Cells[Constant.PriceColumnIndex].Value = price * GetQuantityForRow(e.RowIndex);
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
                try
                {
                    _xmlRepo.Save(Name_textBox.Text.Trim(),
                            LastName_textBox.Text.Trim(), DateOfBirth.Value, Products_dataGridView.Rows);
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