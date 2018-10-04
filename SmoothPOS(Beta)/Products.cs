using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS_Beta_
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShotName { get; set; }
        public string Discription { get; set; }
        public int PopupID { get; set; }
        public float Price { get; set; }
        public List<Ingredients> ListOfIngredient { get; set; }
        public Image ProductImage { get; set; }
        public List<Printer> ListOfPrinter { get; set; }
        public int Stock { get; set; }
        public bool Avaliable { get; set; }
    }
}
