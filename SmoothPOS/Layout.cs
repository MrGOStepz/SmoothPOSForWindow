using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS
{
    public class ItemLayout
    {
        private int tabID;
        private int row;
        private int column;
        private int colorID;

        ItemLayout()
        {
            tabID = 0;
            row = 0;
            column = 0;
            colorID = 0;
        }

        public int Color
        {
            get { return colorID; }
            set { colorID = value; }
        }


        public int Column
        {
            get { return column; }
            set { column = value; }
        }


        public int Row
        {
            get { return row; }
            set { row = value; }
        }


        public int TabID
        {
            get { return tabID; }
            set { tabID = value; }
        }

    }
}
