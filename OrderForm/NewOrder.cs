using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class NewOrder : Form
    {
        public NewOrder()
        {
            InitializeComponent();
            DateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // if(!(dataGridView1.Rows.Count-1 == e.RowIndex))
            dataGridView1.Rows[e.RowIndex].ReadOnly = true;
        }

        private void NewOrder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'listOfProducts.GetProductList' table. You can move, or remove it, as needed.
            this.getProductListTableAdapter.Fill(this.listOfProducts.GetProductList);
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void change_button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.SelectedRows[0].ReadOnly = false;
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć wiersz do edycji");
            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć wiersz do usunięcia");
            }
        }

        private void Name_textBox_Validating(object sender, CancelEventArgs e)
        {
            if (Name_textBox.Text.Length < 2 || Name_textBox.Text.Length > 32)
            { MessageBox.Show("Wpisane imię powinno zawierać od 2 do 32 znaków"); }
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
            { MessageBox.Show("Wpisane nazwisko powinno zawierać od 2 do 32 znaków"); }
        }
    }
}