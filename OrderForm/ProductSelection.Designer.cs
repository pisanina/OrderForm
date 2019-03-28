namespace OrderForm
{
    partial class ProductSelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListOfProducts = new System.Windows.Forms.ComboBox();
            this.Zapisz_Button = new System.Windows.Forms.Button();
            this.Quantity_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ListOfProducts
            // 
            this.ListOfProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListOfProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListOfProducts.FormattingEnabled = true;
            this.ListOfProducts.Location = new System.Drawing.Point(134, 48);
            this.ListOfProducts.Name = "ListOfProducts";
            this.ListOfProducts.Size = new System.Drawing.Size(219, 32);
            this.ListOfProducts.TabIndex = 0;
            // 
            // Zapisz_Button
            // 
            this.Zapisz_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Zapisz_Button.Location = new System.Drawing.Point(359, 162);
            this.Zapisz_Button.Name = "Zapisz_Button";
            this.Zapisz_Button.Size = new System.Drawing.Size(130, 56);
            this.Zapisz_Button.TabIndex = 1;
            this.Zapisz_Button.Text = "Zapisz";
            this.Zapisz_Button.UseVisualStyleBackColor = true;
            this.Zapisz_Button.Click += new System.EventHandler(this.Zapisz_Button_Click);
            // 
            // Quantity_textBox
            // 
            this.Quantity_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity_textBox.Location = new System.Drawing.Point(134, 175);
            this.Quantity_textBox.Name = "Quantity_textBox";
            this.Quantity_textBox.Size = new System.Drawing.Size(100, 29);
            this.Quantity_textBox.TabIndex = 2;
            this.Quantity_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Quantity_textBox_KeyPress);
            this.Quantity_textBox.Validating += new System.ComponentModel.CancelEventHandler(this.Quantity_textBox_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Produkt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ilość";
            // 
            // ProductSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 289);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Quantity_textBox);
            this.Controls.Add(this.Zapisz_Button);
            this.Controls.Add(this.ListOfProducts);
            this.Name = "ProductSelection";
            this.Text = "Wybór Produktu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ListOfProducts;
        private System.Windows.Forms.Button Zapisz_Button;
        private System.Windows.Forms.TextBox Quantity_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}