namespace SmoothPOS_Beta_
{
    partial class RemovePrinterForm
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
            this.lvPrinter = new System.Windows.Forms.ListView();
            this.btnRemovePrinter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvPrinter
            // 
            this.lvPrinter.Location = new System.Drawing.Point(194, 45);
            this.lvPrinter.Name = "lvPrinter";
            this.lvPrinter.Size = new System.Drawing.Size(121, 97);
            this.lvPrinter.TabIndex = 0;
            this.lvPrinter.UseCompatibleStateImageBehavior = false;
            // 
            // btnRemovePrinter
            // 
            this.btnRemovePrinter.Location = new System.Drawing.Point(203, 167);
            this.btnRemovePrinter.Name = "btnRemovePrinter";
            this.btnRemovePrinter.Size = new System.Drawing.Size(75, 23);
            this.btnRemovePrinter.TabIndex = 1;
            this.btnRemovePrinter.Text = "button1";
            this.btnRemovePrinter.UseVisualStyleBackColor = true;
            this.btnRemovePrinter.Click += new System.EventHandler(this.btnRemovePrinter_Click);
            // 
            // RemovePrinterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRemovePrinter);
            this.Controls.Add(this.lvPrinter);
            this.Name = "RemovePrinterForm";
            this.Text = "RemovePrinterForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvPrinter;
        private System.Windows.Forms.Button btnRemovePrinter;
    }
}