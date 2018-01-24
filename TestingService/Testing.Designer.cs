namespace TestingService
{
    partial class Testing
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
            this.gbAddNewEmployee = new System.Windows.Forms.GroupBox();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lbFirstName = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvListOfEmployee = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbAddNewEmployee.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOfEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAddNewEmployee
            // 
            this.gbAddNewEmployee.Controls.Add(this.btnAddEmployee);
            this.gbAddNewEmployee.Controls.Add(this.txtPassword);
            this.gbAddNewEmployee.Controls.Add(this.label4);
            this.gbAddNewEmployee.Controls.Add(this.txtEmail);
            this.gbAddNewEmployee.Controls.Add(this.label3);
            this.gbAddNewEmployee.Controls.Add(this.txtPhone);
            this.gbAddNewEmployee.Controls.Add(this.label2);
            this.gbAddNewEmployee.Controls.Add(this.txtLastName);
            this.gbAddNewEmployee.Controls.Add(this.label1);
            this.gbAddNewEmployee.Controls.Add(this.txtFirstName);
            this.gbAddNewEmployee.Controls.Add(this.lbFirstName);
            this.gbAddNewEmployee.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbAddNewEmployee.Location = new System.Drawing.Point(3, 3);
            this.gbAddNewEmployee.Name = "gbAddNewEmployee";
            this.gbAddNewEmployee.Size = new System.Drawing.Size(288, 547);
            this.gbAddNewEmployee.TabIndex = 0;
            this.gbAddNewEmployee.TabStop = false;
            this.gbAddNewEmployee.Text = "Add Employee";
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(10, 493);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(272, 48);
            this.btnAddEmployee.TabIndex = 10;
            this.btnAddEmployee.Text = "Add";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(76, 121);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(206, 20);
            this.txtPassword.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(76, 95);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(206, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Email :";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(76, 69);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(206, 20);
            this.txtPhone.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Phone :";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(76, 43);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(206, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Last Name :";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(76, 17);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(206, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // lbFirstName
            // 
            this.lbFirstName.AutoSize = true;
            this.lbFirstName.Location = new System.Drawing.Point(7, 20);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(63, 13);
            this.lbFirstName.TabIndex = 0;
            this.lbFirstName.Text = "First Name :";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(825, 579);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvListOfEmployee);
            this.tabPage1.Controls.Add(this.gbAddNewEmployee);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(817, 553);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employee";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvListOfEmployee
            // 
            this.dgvListOfEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListOfEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListOfEmployee.Location = new System.Drawing.Point(291, 3);
            this.dgvListOfEmployee.Name = "dgvListOfEmployee";
            this.dgvListOfEmployee.Size = new System.Drawing.Size(523, 547);
            this.dgvListOfEmployee.TabIndex = 1;
            this.dgvListOfEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListOfEmployee_CellContentClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(817, 553);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Other";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Testing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 579);
            this.Controls.Add(this.tabControl1);
            this.Name = "Testing";
            this.Text = "Testing";
            this.Load += new System.EventHandler(this.Testing_Load);
            this.gbAddNewEmployee.ResumeLayout(false);
            this.gbAddNewEmployee.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOfEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAddNewEmployee;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvListOfEmployee;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lbFirstName;
        private System.Windows.Forms.Button btnAddEmployee;
    }
}