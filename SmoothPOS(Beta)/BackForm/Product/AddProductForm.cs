using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmoothPOS_Beta_
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
            txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            txtPriceInc.TextChanged += new System.EventHandler(this.txtPriceInc_TextChanged);
            txtTax.TextChanged += new System.EventHandler(this.txtTax_TextChanged);
            InitializeData();
        }

        private void InitializeData()
        {
            //TODO Database Get Last row for Table Product
            int LastRow = 0;
            txtProductID.Text = LastRow.ToString();

            txtTax.Text = Options.Tax.ToString();
            txtPrice.Text = "0";
            txtPriceInc.Text = "0";
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Product product = new Product();

            product.ID = int.Parse(txtProductID.Text);

            try
            {
                //Textbox Name
                if (txtName.Text.Trim() == "")
                {
                    MessageBox.Show("Please fill Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    product.Name = txtName.Text;
                }

                //Textbox Shotcut Name
                product.ShotName = txtSCName.Text.Trim() == "" ? "" : txtSCName.Text;

                //Textbox Desicription
                product.Discription = txtDescription.Text.Trim() == "" ? "" : txtDescription.Text;

                //Textbox Popup
                if(cbPopup.Text == "")
                {
                    product.PopupID = 0;
                }
                else
                {
                    product.PopupID = int.Parse(cbPopup.ValueMember);
                }

                //Textbox PriceInc 
                if (txtPriceInc.Text.Trim() == "")
                {
                    product.Price = 0;
                }
                else
                {
                    float parsedValue;
                    if (!float.TryParse(txtPriceInc.Text, out parsedValue))
                    {
                        MessageBox.Show("Price field is only number!");
                        txtPriceInc.Text = "0";
                        return;
                    }     
                    else
                    {
                        product.Price = parsedValue;
                    }
                }

                if(txtStock.Text == "")
                {
                    product.Stock = 0;
                }
                else
                {
                    int parsedValue;
                    if (!int.TryParse(txtPriceInc.Text, out parsedValue))
                    {
                        MessageBox.Show("Stock field is only number!");
                        txtStock.Text = "";
                        return;
                    }
                    else
                    {
                        product.Price = parsedValue;
                    }
                }


                
            }
            catch(Exception ex)
            {
                ExceptionLog exceptionLog = new ExceptionLog();
                exceptionLog.Message = ex.Message;
            }
        }

        private void txtTax_TextChanged(object sender, EventArgs e)
        {           
            if(txtTax.Text == "")
            {
                return;
            }

            float tax;
            if (!float.TryParse(txtTax.Text, out tax))
            {
                MessageBox.Show("Price field is only number!");
                txtTax.Text = "0.00";
            }

            float price = float.Parse(txtPrice.Text);
            float priceInc = price * (1.0f + (tax / 100.0f));

            txtPriceInc.Text = priceInc.ToString("0.00");
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            //Remove event
            txtPriceInc.TextChanged -= txtPriceInc_TextChanged;

            if(txtPrice.Text == "")
            {
                return;
            }

            float price;
            if (!float.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Price field is only number!");
                txtPrice.Text = "0.00";
            }

            float tax = float.Parse(txtTax.Text);
            float priceInc = price * (1.0f + (tax / 100.0f));

            txtPriceInc.Text = priceInc.ToString("0.00");

            //Add Event
            txtPriceInc.TextChanged += txtPriceInc_TextChanged;
        }

        private void txtPriceInc_TextChanged(object sender, EventArgs e)
        {
            txtPrice.TextChanged -= txtPrice_TextChanged;

            if (txtPriceInc.Text == "")
            {
                return;
            }

            float priceInc;
            if (!float.TryParse(txtPriceInc.Text, out priceInc))
            {
                MessageBox.Show("Price field is only number!");
                txtPriceInc.Text = "0.00";
            }

            float tax = float.Parse(txtTax.Text);
            float priceExc = priceInc / (1.0f + (tax / 100.0f));

            txtPrice.Text = priceExc.ToString("0.00");

            txtPrice.TextChanged += txtPrice_TextChanged;

        }
    }
}
