namespace SmoothPOS_Beta_
{
    partial class UpdatePopupForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRSelect = new System.Windows.Forms.Button();
            this.lsvSubPopup = new System.Windows.Forms.ListView();
            this.btnAddPopup = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbPopupName = new System.Windows.Forms.Label();
            this.gbImage = new System.Windows.Forms.GroupBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPopupPrice = new System.Windows.Forms.TextBox();
            this.txtSupPopupName = new System.Windows.Forms.TextBox();
            this.btnAddPopupItem = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPopName = new System.Windows.Forms.TextBox();
            this.gbPopup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPopup
            // 
            this.gbPopup.Controls.Add(this.groupBox2);
            this.gbPopup.Controls.Add(this.groupBox1);
            this.gbPopup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPopup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPopup.Location = new System.Drawing.Point(0, 0);
            this.gbPopup.Name = "gbPopup";
            this.gbPopup.Size = new System.Drawing.Size(604, 461);
            this.gbPopup.TabIndex = 1;
            this.gbPopup.TabStop = false;
            this.gbPopup.Text = "Add Popup";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRSelect);
            this.groupBox2.Controls.Add(this.lsvSubPopup);
            this.groupBox2.Controls.Add(this.btnAddPopup);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(279, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 438);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Popup List";
            // 
            // btnRSelect
            // 
            this.btnRSelect.Location = new System.Drawing.Point(6, 382);
            this.btnRSelect.Name = "btnRSelect";
            this.btnRSelect.Size = new System.Drawing.Size(150, 50);
            this.btnRSelect.TabIndex = 10;
            this.btnRSelect.Text = "Remove Select Item";
            this.btnRSelect.UseVisualStyleBackColor = true;
            // 
            // lsvSubPopup
            // 
            this.lsvSubPopup.Location = new System.Drawing.Point(6, 20);
            this.lsvSubPopup.Name = "lsvSubPopup";
            this.lsvSubPopup.Size = new System.Drawing.Size(306, 352);
            this.lsvSubPopup.TabIndex = 3;
            this.lsvSubPopup.UseCompatibleStateImageBehavior = false;
            // 
            // btnAddPopup
            // 
            this.btnAddPopup.Location = new System.Drawing.Point(162, 382);
            this.btnAddPopup.Name = "btnAddPopup";
            this.btnAddPopup.Size = new System.Drawing.Size(150, 50);
            this.btnAddPopup.TabIndex = 2;
            this.btnAddPopup.Text = "Add Popup";
            this.btnAddPopup.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 438);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Popup Detail";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbPopupName);
            this.groupBox4.Controls.Add(this.gbImage);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtPopupPrice);
            this.groupBox4.Controls.Add(this.txtSupPopupName);
            this.groupBox4.Controls.Add(this.btnAddPopupItem);
            this.groupBox4.Location = new System.Drawing.Point(9, 83);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(261, 352);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "List Name";
            // 
            // lbPopupName
            // 
            this.lbPopupName.AutoSize = true;
            this.lbPopupName.Location = new System.Drawing.Point(12, 20);
            this.lbPopupName.Name = "lbPopupName";
            this.lbPopupName.Size = new System.Drawing.Size(79, 18);
            this.lbPopupName.TabIndex = 6;
            this.lbPopupName.Text = "List Name:";
            // 
            // gbImage
            // 
            this.gbImage.Controls.Add(this.pbImage);
            this.gbImage.Controls.Add(this.btnUploadImage);
            this.gbImage.Location = new System.Drawing.Point(42, 77);
            this.gbImage.Name = "gbImage";
            this.gbImage.Size = new System.Drawing.Size(182, 219);
            this.gbImage.TabIndex = 7;
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
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Price:";
            // 
            // txtPopupPrice
            // 
            this.txtPopupPrice.Location = new System.Drawing.Point(112, 47);
            this.txtPopupPrice.Name = "txtPopupPrice";
            this.txtPopupPrice.Size = new System.Drawing.Size(123, 24);
            this.txtPopupPrice.TabIndex = 8;
            // 
            // txtSupPopupName
            // 
            this.txtSupPopupName.Location = new System.Drawing.Point(112, 17);
            this.txtSupPopupName.Name = "txtSupPopupName";
            this.txtSupPopupName.Size = new System.Drawing.Size(123, 24);
            this.txtSupPopupName.TabIndex = 5;
            // 
            // btnAddPopupItem
            // 
            this.btnAddPopupItem.Location = new System.Drawing.Point(42, 302);
            this.btnAddPopupItem.Name = "btnAddPopupItem";
            this.btnAddPopupItem.Size = new System.Drawing.Size(182, 40);
            this.btnAddPopupItem.TabIndex = 4;
            this.btnAddPopupItem.Text = "Add Popup Item";
            this.btnAddPopupItem.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtPopName);
            this.groupBox3.Location = new System.Drawing.Point(9, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(261, 51);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Head Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Head Name:";
            // 
            // txtPopName
            // 
            this.txtPopName.Location = new System.Drawing.Point(112, 20);
            this.txtPopName.Name = "txtPopName";
            this.txtPopName.Size = new System.Drawing.Size(123, 24);
            this.txtPopName.TabIndex = 0;
            // 
            // UpdatePopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 461);
            this.Controls.Add(this.gbPopup);
            this.Name = "UpdatePopupForm";
            this.Text = "UpdatePopupForm";
            this.gbPopup.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPopup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRSelect;
        private System.Windows.Forms.ListView lsvSubPopup;
        private System.Windows.Forms.Button btnAddPopup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbPopupName;
        private System.Windows.Forms.GroupBox gbImage;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPopupPrice;
        private System.Windows.Forms.TextBox txtSupPopupName;
        private System.Windows.Forms.Button btnAddPopupItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPopName;
    }
}