using Newtonsoft.Json;
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
    public partial class SearchPopupForm : Form
    {
        public SearchPopupForm()
        {
            InitializeComponent();
            dgvProduct.MultiSelect = false;
            dgvProduct.ReadOnly = true;
            dgvProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DatabaseHandle dbHandle = new DatabaseHandle();
            string jsonString = dbHandle.ListOfPopupFilter(txtSearch.Text);

            List<PopupModel> lstPopupModel = JsonConvert.DeserializeObject<List<PopupModel>>(jsonString);

            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));

            List<string> lstName = lstPopupModel.Select(x => x.Name).ToList();
            List<int> lstID = lstPopupModel.Select(x => x.PopupID).ToList();

            for (int i = 0; i < lstName.Count; i++)
            {
                table.Rows.Add(lstID[i], lstName[i]);
            }

            dgvProduct.DataSource = table;
        }

        private void SearchPopupForm_Load(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void RefreshTable()
        {
            DatabaseHandle dbHandle = new DatabaseHandle();
            string JSON = dbHandle.ListOfPopup();

            List<PopupModel> lstPopupModel = JsonConvert.DeserializeObject<List<PopupModel>>(JSON);

            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));

            List<string> lstName = lstPopupModel.Select(x => x.Name).ToList();
            List<int> lstID = lstPopupModel.Select(x => x.PopupID).ToList();

            for (int i = 0; i < lstName.Count; i++)
            {
                table.Rows.Add(lstID[i], lstName[i]);
            }

            dgvProduct.DataSource = table;
        }

        private void btnQuickDelete_Click(object sender, EventArgs e)
        {
            DatabaseHandle dbHandle = new DatabaseHandle();
            if (dgvProduct.SelectedRows.Count > 0)
            {
                int popupID = (int)dgvProduct.SelectedRows[0].Cells[0].Value;
                string titleName = dgvProduct.SelectedRows[0].Cells[1].Value.ToString();

                //1 is NONE Popup cann't delete it.
                if (popupID != 1)
                {
                    if (MessageBox.Show("Do you want to delete " + titleName + " Popup!", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if(dbHandle.RemovePopup(popupID) > 0)
                        {
                            RefreshTable();
                            MessageBox.Show("Delete Complete!");
                        }
                        else
                        {
                            MessageBox.Show("Something wrong!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Cann't Delete NONE Popup!");
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }
    }
}
