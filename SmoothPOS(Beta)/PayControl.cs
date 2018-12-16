using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SmoothPOS_Beta_
{
    public partial class PayControl : UserControl
    {
        private string _previousPayTextbox;
        private string _previousDiscountTextbox;
        private TextBox _lastTextbox;
    
        public PayControl()
        {
            InitializeComponent();
        }

        private void PayControl_Load(object sender, EventArgs e)
        {
            _lastTextbox = txtPCPay;
            txtPCPay.LostFocus += TxtPCPay_LostFocus;
            txtPCDiscount.LostFocus += TxtPCDiscount_LostFocus;
        }

        private void TxtPCDiscount_LostFocus(object sender, EventArgs e)
        {
            _lastTextbox = (TextBox)sender;
        }

        private void TxtPCPay_LostFocus(object sender, EventArgs e)
        {
            _lastTextbox = (TextBox)sender;
        }

        private void Number_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            _previousPayTextbox = txtPCPay.Text;
            _previousDiscountTextbox = txtPCDiscount.Text;

            if (_lastTextbox.Name == "txtPCPay")
            {
                switch (button.Name)
                {
                    case "btn1":
                        txtPCPay.Text += "1";
                        break;
                    case "btn2":
                        txtPCPay.Text += "2";
                        break;
                    case "btn3":
                        txtPCPay.Text += "3";
                        break;
                    case "btn4":
                        txtPCPay.Text += "4";
                        break;
                    case "btn5":
                        txtPCPay.Text += "5";
                        break;
                    case "btn6":
                        txtPCPay.Text += "6";
                        break;
                    case "btn7":
                        txtPCPay.Text += "7";
                        break;
                    case "btn8":
                        txtPCPay.Text += "8";
                        break;
                    case "btn9":
                        txtPCPay.Text += "9";
                        break;
                    case "btn0":
                        txtPCPay.Text += "0";
                        break;
                    case "btnPoint":
                        txtPCPay.Text += ".";
                        break;
                    case "btnPCDelete":
                        try
                        {
                            txtPCPay.Text = txtPCPay.Text.Remove(txtPCPay.Text.Length - 1);
                        }
                        catch (Exception)
                        {

                            txtPCPay.Text = "";
                        }
                        break;

                    default:
                        break;
                }
            }
            else
            {
                switch (button.Name)
                {
                    case "btn1":
                        txtPCDiscount.Text += "1";
                        break;
                    case "btn2":
                        txtPCDiscount.Text += "2";
                        break;
                    case "btn3":
                        txtPCDiscount.Text += "3";
                        break;
                    case "btn4":
                        txtPCDiscount.Text += "4";
                        break;
                    case "btn5":
                        txtPCDiscount.Text += "5";
                        break;
                    case "btn6":
                        txtPCDiscount.Text += "6";
                        break;
                    case "btn7":
                        txtPCDiscount.Text += "7";
                        break;
                    case "btn8":
                        txtPCDiscount.Text += "8";
                        break;
                    case "btn9":
                        txtPCDiscount.Text += "9";
                        break;
                    case "btn0":
                        txtPCDiscount.Text += "0";
                        break;
                    case "btnPoint":
                        txtPCDiscount.Text += ".";
                        break;
                    case "btnPCDelete":
                        try
                        {
                            txtPCDiscount.Text = txtPCDiscount.Text.Remove(txtPCDiscount.Text.Length - 1);
                        }
                        catch (Exception)
                        {

                            txtPCDiscount.Text = "";
                        }
                        break;

                    default:
                        break;
                }
            }
        }


        private void txtPCPay_TextChanged(object sender, EventArgs e)
        {
            if(FormatFloatCheck(txtPCPay.Text) == false)
            {
                txtPCPay.Text = _previousPayTextbox;
            }
        }

        private void txtPCDiscount_TextChanged(object sender, EventArgs e)
        {
            if (FormatFloatCheck(txtPCDiscount.Text) == false)
            {
                txtPCDiscount.Text = _previousDiscountTextbox;
            }
        }

        private bool FormatFloatCheck(string text)
        {
            Regex r = new Regex(@"^-{0,1}\d+\.{0,1}\d*$"); // This is the main part, can be altered to match any desired form or limitations
            Match m = r.Match(text);

            if (m.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
