using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace SmoothPOS
{
    public class GenerateTable
    {
        public TabItem TabSection;
        public List<Button> ListOfButton;

        public List<Button> GenerateButton(string jsonFormat)
        {
            List<Button> lstButton = new List<Button>();
            Button btnTemp = new Button();
            TableModal tbDetail = JsonConvert.DeserializeObject<TableModal>(jsonFormat);


            return lstButton;
        }

        public TabItem GenerateTabItem()
        {
            TabItem tabItems = new TabItem();

            return tabItems;
        }

    }

    public class TableModal
    {
        public int SectionID { get; set; }
        public string uniName { get; set; }
        public string Name { get; set; }
        public float MarginTop { get; set; }
        public float MarginRight { get; set; }
        public float MarginButtom { get; set; }
        public float MarginLeft { get; set; }
        public int is_active { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
    }


}
