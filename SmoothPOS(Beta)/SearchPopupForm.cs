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
    }
}
