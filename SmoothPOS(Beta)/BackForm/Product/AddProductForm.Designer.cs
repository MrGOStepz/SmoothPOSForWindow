namespace SmoothPOS_Beta_
{
    partial class AddProductForm
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
            this.lbName = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.gbPrinter = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.gbImage = new System.Windows.Forms.GroupBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbAvaliable = new System.Windows.Forms.CheckBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.cbPopup = new System.Windows.Forms.ComboBox();
            this.btnAddPopup = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.gbIngredients = new System.Windows.Forms.GroupBox();
            this.lvIngredients = new System.Windows.Forms.ListView();
            this.btnIngredients = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPriceInc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSCName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbName.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbPrinter.SuspendLayout();
            this.gbImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbDetail.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbIngredients.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.Controls.Add(this.panel2);
            this.lbName.Controls.Add(this.panel1);
            this.lbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbName.Location = new System.Drawing.Point(0, 0);
            this.lbName.Margin = new System.Windows.Forms.Padding(4);
            this.lbName.Name = "lbName";
            this.lbName.Padding = new System.Windows.Forms.Padding(4);
            this.lbName.Size = new System.Drawing.Size(684, 461);
            this.lbName.TabIndex = 0;
            this.lbName.TabStop = false;
            this.lbName.Text = "Add Product";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddProduct);
            this.panel2.Controls.Add(this.gbPrinter);
            this.panel2.Controls.Add(this.gbImage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(498, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 436);
            this.panel2.TabIndex = 7;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.AutoSize = true;
            this.btnAddProduct.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddProduct.Location = new System.Drawing.Point(0, 375);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(182, 61);
            this.btnAddProduct.TabIndex = 12;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // gbPrinter
            // 
            this.gbPrinter.Controls.Add(this.checkedListBox1);
            this.gbPrinter.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPrinter.Location = new System.Drawing.Point(0, 219);
            this.gbPrinter.Name = "gbPrinter";
            this.gbPrinter.Size = new System.Drawing.Size(182, 150);
            this.gbPrinter.TabIndex = 6;
            this.gbPrinter.TabStop = false;
            this.gbPrinter.Text = "Printer";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(3, 20);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.ScrollAlwaysVisible = true;
            this.checkedListBox1.Size = new System.Drawing.Size(176, 127);
            this.checkedListBox1.TabIndex = 11;
            // 
            // gbImage
            // 
            this.gbImage.Controls.Add(this.pbImage);
            this.gbImage.Controls.Add(this.btnUploadImage);
            this.gbImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbImage.Location = new System.Drawing.Point(0, 0);
            this.gbImage.Name = "gbImage";
            this.gbImage.Size = new System.Drawing.Size(182, 219);
            this.gbImage.TabIndex = 5;
            this.gbImage.TabStop = false;
            this.gbImage.Text = "Image";
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(15, 23);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(150, 150);
            this.pbImage.TabIndex = 7;
            this.pbImage.TabStop = false;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnUploadImage.Location = new System.Drawing.Point(3, 186);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(176, 30);
            this.btnUploadImage.TabIndex = 10;
            this.btnUploadImage.Text = "Upload Image";
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbDetail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(4, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 436);
            this.panel1.TabIndex = 6;
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.groupBox3);
            this.gbDetail.Controls.Add(this.cbPopup);
            this.gbDetail.Controls.Add(this.btnAddPopup);
            this.gbDetail.Controls.Add(this.label7);
            this.gbDetail.Controls.Add(this.gbIngredients);
            this.gbDetail.Controls.Add(this.groupBox1);
            this.gbDetail.Controls.Add(this.txtProductID);
            this.gbDetail.Controls.Add(this.label3);
            this.gbDetail.Controls.Add(this.txtSCName);
            this.gbDetail.Controls.Add(this.label2);
            this.gbDetail.Controls.Add(this.txtDescription);
            this.gbDetail.Controls.Add(this.lbDescription);
            this.gbDetail.Controls.Add(this.txtName);
            this.gbDetail.Controls.Add(this.label1);
            this.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDetail.Location = new System.Drawing.Point(0, 0);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(488, 436);
            this.gbDetail.TabIndex = 6;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "Product Detail";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cbAvaliable);
            this.groupBox3.Controls.Add(this.txtStock);
            this.groupBox3.Location = new System.Drawing.Point(132, 338);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(144, 90);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Avaliable";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 18);
            this.label8.TabIndex = 20;
            this.label8.Text = "Stock:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "Avaliable:";
            // 
            // cbAvaliable
            // 
            this.cbAvaliable.AutoSize = true;
            this.cbAvaliable.Checked = true;
            this.cbAvaliable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAvaliable.Location = new System.Drawing.Point(81, 57);
            this.cbAvaliable.Name = "cbAvaliable";
            this.cbAvaliable.Size = new System.Drawing.Size(15, 14);
            this.cbAvaliable.TabIndex = 8;
            this.cbAvaliable.UseVisualStyleBackColor = true;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(80, 20);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(50, 24);
            this.txtStock.TabIndex = 7;
            // 
            // cbPopup
            // 
            this.cbPopup.FormattingEnabled = true;
            this.cbPopup.Location = new System.Drawing.Point(111, 213);
            this.cbPopup.Name = "cbPopup";
            this.cbPopup.Size = new System.Drawing.Size(121, 26);
            this.cbPopup.TabIndex = 4;
            // 
            // btnAddPopup
            // 
            this.btnAddPopup.Location = new System.Drawing.Point(236, 213);
            this.btnAddPopup.Name = "btnAddPopup";
            this.btnAddPopup.Size = new System.Drawing.Size(25, 25);
            this.btnAddPopup.TabIndex = 18;
            this.btnAddPopup.Text = "+";
            this.btnAddPopup.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "Popup:";
            // 
            // gbIngredients
            // 
            this.gbIngredients.Controls.Add(this.lvIngredients);
            this.gbIngredients.Controls.Add(this.btnIngredients);
            this.gbIngredients.Location = new System.Drawing.Point(282, 17);
            this.gbIngredients.Name = "gbIngredients";
            this.gbIngredients.Size = new System.Drawing.Size(200, 413);
            this.gbIngredients.TabIndex = 13;
            this.gbIngredients.TabStop = false;
            this.gbIngredients.Text = "Ingredients";
            // 
            // lvIngredients
            // 
            this.lvIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvIngredients.Location = new System.Drawing.Point(3, 20);
            this.lvIngredients.Name = "lvIngredients";
            this.lvIngredients.Size = new System.Drawing.Size(194, 358);
            this.lvIngredients.TabIndex = 1;
            this.lvIngredients.UseCompatibleStateImageBehavior = false;
            // 
            // btnIngredients
            // 
            this.btnIngredients.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnIngredients.Location = new System.Drawing.Point(3, 378);
            this.btnIngredients.Name = "btnIngredients";
            this.btnIngredients.Size = new System.Drawing.Size(194, 32);
            this.btnIngredients.TabIndex = 9;
            this.btnIngredients.Text = "Ingredients";
            this.btnIngredients.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPriceInc);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTax);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(8, 296);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 130);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Price";
            // 
            // txtPriceInc
            // 
            this.txtPriceInc.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtPriceInc.Location = new System.Drawing.Point(54, 93);
            this.txtPriceInc.Name = "txtPriceInc";
            this.txtPriceInc.Size = new System.Drawing.Size(50, 24);
            this.txtPriceInc.TabIndex = 15;
            this.txtPriceInc.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 18);
            this.label9.TabIndex = 16;
            this.label9.Text = "Price:";
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtPrice.Location = new System.Drawing.Point(54, 57);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(50, 24);
            this.txtPrice.TabIndex = 6;
            this.txtPrice.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Price:";
            // 
            // txtTax
            // 
            this.txtTax.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTax.Location = new System.Drawing.Point(54, 23);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(50, 24);
            this.txtTax.TabIndex = 5;
            this.txtTax.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tax:";
            // 
            // txtProductID
            // 
            this.txtProductID.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtProductID.Enabled = false;
            this.txtProductID.Location = new System.Drawing.Point(112, 17);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(150, 24);
            this.txtProductID.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "ID:";
            // 
            // txtSCName
            // 
            this.txtSCName.Location = new System.Drawing.Point(112, 77);
            this.txtSCName.Name = "txtSCName";
            this.txtSCName.Size = new System.Drawing.Size(150, 24);
            this.txtSCName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Shotcut Name:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(112, 107);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(150, 100);
            this.txtDescription.TabIndex = 3;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(24, 110);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(87, 18);
            this.lbDescription.TabIndex = 6;
            this.lbDescription.Text = "Description:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(112, 47);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(150, 24);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name:";
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.lbName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Product";
            this.lbName.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbPrinter.ResumeLayout(false);
            this.gbImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbIngredients.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox lbName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbPrinter;
        private System.Windows.Forms.GroupBox gbImage;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSCName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ComboBox cbPopup;
        private System.Windows.Forms.Button btnAddPopup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbAvaliable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbIngredients;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.ListView lvIngredients;
        private System.Windows.Forms.Button btnIngredients;
        private System.Windows.Forms.TextBox txtPriceInc;
        private System.Windows.Forms.Label label9;
    }
}