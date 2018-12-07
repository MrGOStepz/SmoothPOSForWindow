using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmoothPOS_Beta_
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
            InitializeEvent();
            InitializeData();

            cbPopup.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void InitializeEvent()
        {
            txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            txtPriceInc.TextChanged += new System.EventHandler(this.txtPriceInc_TextChanged);
            txtTax.TextChanged += new System.EventHandler(this.txtTax_TextChanged);
        }

        private void InitializeData()
        {
            //TODO Database Get Last row for Table Product
            int LastRow = 0;
            txtProductID.Text = LastRow.ToString();

            txtTax.Text = Options.Tax.ToString();
            txtPrice.Text = "0";
            txtPriceInc.Text = "0";

            DatabaseHandle dbHandle = new DatabaseHandle();

            string jsonString = dbHandle.ListOfPopup();

            if (jsonString != null)
            {
                List<PopupModel> lstPopupModel = JsonConvert.DeserializeObject<List<PopupModel>>(jsonString);

                for (int i = 0; i < lstPopupModel.Count; i++)
                {
                    cbPopup.Items.Add(new { Name = lstPopupModel[i].Name, PopupID = lstPopupModel[i].PopupID });
                }
                cbPopup.DisplayMember = "Name";
                cbPopup.ValueMember = "PopupID";
            }


            //TODO Database Get list of Priter
            //TODO Database Get list of Ingredients for Product
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductModel product = new ProductModel();

            product.ProductID = int.Parse(txtProductID.Text);

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
                product.ShortName = txtSCName.Text.Trim() == "" ? "" : txtSCName.Text;

                //Textbox Desicription
                product.Description = txtDescription.Text.Trim() == "" ? "" : txtDescription.Text;

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

                //Textbox Stock
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

                //Checkbox Avaliable
                product.Avaliable = cbAvaliable.Checked == true ? 1 : 0;

                string json = JsonConvert.SerializeObject(product);

                DatabaseHandle dbHandle = new DatabaseHandle();

                if(dbHandle.AddProduct(json) > 0)
                {
                    MessageBox.Show("Add Product Complete!");
                }
                else
                {
                    MessageBox.Show("Something Wrong!");
                }

            }
            catch(Exception ex)
            {
                ExceptionLog exceptionLog = new ExceptionLog();
                exceptionLog.Message = ex.Message;
            }
        }

        //private IEnumerable<ListViewSubItem> GetListOfIngredient()
        //{
        //    foreach (ListViewItem itemRow in lvIngredients.Items)
        //    {
        //        for (int i = 0; i < itemRow.SubItems.Count; i++)
        //        {
        //            yield return itemRow.SubItems[i];          
        //        }
        //    }      
        //}
    

        #region Event Text change
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

        #endregion

        private void btnUploadImage_Click(object sender, EventArgs e)
        {           
            var thread = new Thread(ShowOpenDialog);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        private void ShowOpenDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
                pbImage.Image = new Bitmap(ofd.FileName);
            }
            ofd = null;
        }

        private void btnAddPopup_Click(object sender, EventArgs e)
        {
            AddPopupForm appPopupForm = new AddPopupForm();
            appPopupForm.ShowDialog();
        }
    }
}
