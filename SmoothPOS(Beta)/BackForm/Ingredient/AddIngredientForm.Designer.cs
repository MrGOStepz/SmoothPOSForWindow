namespace SmoothPOS_Beta_
{
    partial class AddIngredientForm
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
            this.gbPopup = new System.Windows.Forms.GroupBox();
            this.btnAddIngredient = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.gbImage = new System.Windows.Forms.GroupBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.gbPopup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPopup
            // 
            this.gbPopup.Controls.Add(this.groupBox1);
            this.gbPopup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPopup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPopup.Location = new System.Drawing.Point(0, 0);
            this.gbPopup.Name = "gbPopup";
            this.gbPopup.Size = new System.Drawing.Size(209, 361);
            this.gbPopup.TabIndex = 1;
            this.gbPopup.TabStop = false;
            this.gbPopup.Text = "Add Ingredient";
            // 
            // btnAddIngredient
            // 
            this.btnAddIngredient.Location = new System.Drawing.Point(9, 275);
            this.btnAddIngredient.Name = "btnAddIngredient";
            this.btnAddIngredient.Size = new System.Drawing.Size(179, 50);
            this.btnAddIngredient.TabIndex = 2;
            this.btnAddIngredient.Text = "Add Ingredient";
            this.btnAddIngredient.UseVisualStyleBackColor = true;
            this.btnAddIngredient.Click += new System.EventHandler(this.btnAddIngredient_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbImage);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.btnAddIngredient);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 338);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingredient Detail";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(67, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 24);
            this.txtName.TabIndex = 0;
            // 
            // gbImage
            // 
            this.gbImage.Controls.Add(this.pbImage);
            this.gbImage.Controls.Add(this.btnUploadImage);
            this.gbImage.Location = new System.Drawing.Point(9, 50);
            this.gbImage.Name = "gbImage";
            this.gbImage.Size = new System.Drawing.Size(182, 219);
            this.gbImage.TabIndex = 8;
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
            // AddIngredientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 361);
            this.Controls.Add(this.gbPopup);
            this.Name = "AddIngredientForm";
            this.Text = "AddIngredientForm";
            this.gbPopup.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPopup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbImage;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnAddIngredient;
    }
}