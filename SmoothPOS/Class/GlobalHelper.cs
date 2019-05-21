using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS
{
    public static class GlobalHelper
    {
        public static EmployeeModel CurrentEmployee = new EmployeeModel();
        public static List<EmployeeModel> EmployeeDetail = new List<EmployeeModel>();
        public static List<TableModal> TableDetail = new List<TableModal>();
        public static List<IngredientModel> IngredientDetail = new List<IngredientModel>();
        public static List<LocationMenuModel> LocationMenuDetail = new List<LocationMenuModel>();
        public static List<LocationTabModel> LocationTabDetail = new List<LocationTabModel>();
        public static List<PopupModel> PopupDetail = new List<PopupModel>();
        public static List<ProductModel> ProductDetail = new List<ProductModel>();
        public static List<SectionModel> SectionDetail = new List<SectionModel>();
    }

    public enum ServiceStatus
    {
        Running,
        Stopped,
        Paused,
        Stoping,
        Starting,
        Changing
    }
}
