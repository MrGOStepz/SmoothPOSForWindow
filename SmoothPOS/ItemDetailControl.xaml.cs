using System;
using System.Collections.Generic;
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
    /// Interaction logic for ItemDetailControl.xaml
    /// </summary>
    public partial class ItemDetailControl : UserControl
    {
        public Button ButtonIncrease;
        public Button ButtonDecrease;
        public Button ButtonComment;
        public Label LabelName;
        public Label LabelPopup;
        public StackPanel StackPanelComment;

        public ItemDetailControl()
        {
            InitializeComponent();
            ButtonIncrease = btnIncrease;
            ButtonDecrease = btnDecrease;
            ButtonComment = btnComment;
            LabelName = lbName;
            LabelPopup = lbPopup;
            StackPanelComment = spComment;
        }
    }
}
