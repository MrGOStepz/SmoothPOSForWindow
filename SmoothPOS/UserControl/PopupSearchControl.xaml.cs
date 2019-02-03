using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmoothPOS
{
    /// <summary>
    /// Interaction logic for PopupSearchControl.xaml
    /// </summary>
    public partial class PopupSearchControl : UserControl
    {
        public PopupSearchControl()
        {
            InitializeComponent();
            Loaded += PopupSearchControl_Loaded;
        }

        private void PopupSearchControl_Loaded(object sender, RoutedEventArgs e)
        {
            DatabaseHandle dbHandle = new DatabaseHandle();

            DataTable dt = new DataTable();
            string json = dbHandle.ListOfPopup();

            List<PopupModel> lstPopupModel = JsonConvert.DeserializeObject<List<PopupModel>>(json);

            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));

            List<string> lstName = lstPopupModel.Select(x => x.Name).ToList();
            List<int> lstID = lstPopupModel.Select(x => x.PopupID).ToList();

            for (int i = 0; i < lstName.Count; i++)
            {
                table.Rows.Add(lstID[i], lstName[i]);
            }

            dgvPopup.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = table });
            dgvPopup.IsReadOnly = true;

        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
