namespace OrderForm
{
    partial class NewOrder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.add_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.change_button = new System.Windows.Forms.Button();
            this.SaveToDB_button = new System.Windows.Forms.Button();
            this.SaveToXml_button = new System.Windows.Forms.Button();
            this.Name_textBox = new System.Windows.Forms.TextBox();
            this.LastName_textBox = new System.Windows.Forms.TextBox();
            this.DateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.Products_dataGridView = new System.Windows.Forms.DataGridView();
            this.getProductListBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.listOfProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProductName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Products_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getProductListBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listOfProductsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // add_button
            // 
            resources.ApplyResources(this.add_button, "add_button");
            this.add_button.Name = "add_button";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // delete_button
            // 
            resources.ApplyResources(this.delete_button, "delete_button");
            this.delete_button.Name = "delete_button";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // change_button
            // 
            resources.ApplyResources(this.change_button, "change_button");
            this.change_button.Name = "change_button";
            this.change_button.UseVisualStyleBackColor = true;
            this.change_button.Click += new System.EventHandler(this.change_button_Click);
            // 
            // SaveToDB_button
            // 
            resources.ApplyResources(this.SaveToDB_button, "SaveToDB_button");
            this.SaveToDB_button.Name = "SaveToDB_button";
            this.SaveToDB_button.UseVisualStyleBackColor = true;
            this.SaveToDB_button.Click += new System.EventHandler(this.SaveToDB_button_Click);
            // 
            // SaveToXml_button
            // 
            resources.ApplyResources(this.SaveToXml_button, "SaveToXml_button");
            this.SaveToXml_button.Name = "SaveToXml_button";
            this.SaveToXml_button.UseVisualStyleBackColor = true;
            this.SaveToXml_button.Click += new System.EventHandler(this.SaveToXml_button_Click);
            // 
            // Name_textBox
            // 
            resources.ApplyResources(this.Name_textBox, "Name_textBox");
            this.Name_textBox.Name = "Name_textBox";
            this.Name_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Name_textBox_KeyPress);
            this.Name_textBox.Validating += new System.ComponentModel.CancelEventHandler(this.Name_textBox_Validating);
            // 
            // LastName_textBox
            // 
            resources.ApplyResources(this.LastName_textBox, "LastName_textBox");
            this.LastName_textBox.Name = "LastName_textBox";
            this.LastName_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LastName_textBox_KeyPress);
            this.LastName_textBox.Validating += new System.ComponentModel.CancelEventHandler(this.LastName_textBox_Validating);
            // 
            // DateOfBirth
            // 
            resources.ApplyResources(this.DateOfBirth, "DateOfBirth");
            this.DateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateOfBirth.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.Value = new System.DateTime(1980, 1, 1, 16, 3, 0, 0);
            // 
            // Products_dataGridView
            // 
            this.Products_dataGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Products_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.Products_dataGridView, "Products_dataGridView");
            this.Products_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.Quantity,
            this.Price});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Products_dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.Products_dataGridView.MultiSelect = false;
            this.Products_dataGridView.Name = "Products_dataGridView";
            this.Products_dataGridView.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.Products_dataGridView_CellLeave);
            this.Products_dataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Products_dataGridView_RowsAdded);
            this.Products_dataGridView.Validating += new System.ComponentModel.CancelEventHandler(this.Products_dataGridView_Validating);
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductName.DataPropertyName = "Name";
            resources.ApplyResources(this.ProductName, "ProductName");
            this.ProductName.Name = "ProductName";
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            resources.ApplyResources(this.Quantity, "Quantity");
            this.Quantity.Name = "Quantity";
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            resources.ApplyResources(this.Price, "Price");
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // NewOrder
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Products_dataGridView);
            this.Controls.Add(this.DateOfBirth);
            this.Controls.Add(this.LastName_textBox);
            this.Controls.Add(this.Name_textBox);
            this.Controls.Add(this.SaveToXml_button);
            this.Controls.Add(this.SaveToDB_button);
            this.Controls.Add(this.change_button);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewOrder";
            this.Load += new System.EventHandler(this.NewOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Products_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getProductListBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listOfProductsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button change_button;
        private System.Windows.Forms.Button SaveToDB_button;
        private System.Windows.Forms.Button SaveToXml_button;
        private System.Windows.Forms.TextBox Name_textBox;
        private System.Windows.Forms.TextBox LastName_textBox;
        private System.Windows.Forms.DateTimePicker DateOfBirth;
        private System.Windows.Forms.DataGridView Products_dataGridView;
        private System.Windows.Forms.BindingSource listOfProductsBindingSource;
        private System.Windows.Forms.BindingSource getProductListBindingSource;
        private System.Windows.Forms.BindingSource getProductListBindingSource1;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}

