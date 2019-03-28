using OrderForm.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class ProductSelection : Form
    {

        public string SelectedProductName;
        public int SelectedProductId;
        public int SelectedQuantity;


        public ProductSelection(DataTable products)
        {
            InitializeComponent();

            this.ListOfProducts.DisplayMember = "Name";
            this.ListOfProducts.ValueMember = "Id";
            this.ListOfProducts.DataSource = products;
        }

        public ProductSelection(int productId, int quantity, DataTable products) : this(products)
        {
            Quantity_textBox.Text = quantity.ToString();
            ListOfProducts.SelectedValue = productId;

        }

        private void Zapisz_Button_Click(object sender, EventArgs e)
        {
            SelectedProductName = this.ListOfProducts.Text;
            SelectedProductId = Convert.ToInt32(this.ListOfProducts.SelectedValue);
            SelectedQuantity = Convert.ToInt32((this.Quantity_textBox.Text));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Quantity_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char enteredChar = e.KeyChar;
            if (!IsNumber(enteredChar))
            {
                e.Handled = true;
            }
        }
            private bool IsNumber(char enteredChar)
            {
                return Char.IsControl(enteredChar) || Char.IsDigit(enteredChar);
            }

        private void Quantity_textBox_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(Quantity_textBox.Text) == 0)
            {
                e.Cancel = true;
                MessageBox.Show("Proszę podać ilość większą niż zero");
            }
        }
    }
}
