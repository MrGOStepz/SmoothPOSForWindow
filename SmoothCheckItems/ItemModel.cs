using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothCheckItems
{
    public class ItemModel
    {
        public int TableNo { get; set; }
        public DateTime CallTime { get; set; }
        public List<ItemDetail> ListEntreeItems = new List<ItemDetail>();
        public List<ItemDetail> ListMainItems = new List<ItemDetail>();
        public List<ItemDetail> ListDessertItems = new List<ItemDetail>();
        public List<ItemDetail> ListBeverageItems = new List<ItemDetail>();
    }

    public class ItemDetail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TypeOfFood TypeFood { get; set; }
        public string ImageFood { get; set; }
        public string ImagePopup { get; set; }
    }

    public enum TypeOfFood
    {
        Entree,
        Main,
        Dessert,
        Beverage
    }
}
