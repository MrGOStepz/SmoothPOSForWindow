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
    /// Interaction logic for TableControl.xaml
    /// </summary>
    public partial class TableControl : UserControl
    {
        double m_MouseX;
        double m_MouseY;

        public TableControl()
        {
            InitializeComponent();

            btnTest.PreviewMouseUp += Button_MouseUp;
            btnTest.PreviewMouseLeftButtonDown += Button_MouseLeftButtonUp;
            btnTest.PreviewMouseMove += Button_MouseMove;

            btnTest2.PreviewMouseUp += Button_MouseUp;
            btnTest2.PreviewMouseLeftButtonDown += Button_MouseLeftButtonUp;
            btnTest2.PreviewMouseMove += Button_MouseMove;
        }

        private void BtnEditTable_Click(object sender, RoutedEventArgs e)
        {
            if(btnEditTable.Tag.ToString() == "1")
            {
                btnEditTable.Content = "Edit Done";
                btnEditTable.Tag = "0";
                btnAddTable.Visibility = Visibility.Visible;
                btnRemoveTable.Visibility = Visibility.Visible;
            }
            else
            {
                btnEditTable.Content = "Edit Table";
                btnEditTable.Tag = "1";
                btnAddTable.Visibility = Visibility.Hidden;
                btnRemoveTable.Visibility = Visibility.Hidden;
            }
            
        }

        private void BtnAddTable_Click(object sender, RoutedEventArgs e)
        {         
            TableDialog tbDialog = new TableDialog();
            Button btnCreate = new Button();
            Thickness margin = new Thickness();

            string tableName = "table_00";

            tbDialog.ShowDialog();
            
            tableName = "table_" + tbDialog.ReturnValue;
            margin.Left = 10;
            margin.Top = 10;
            btnCreate.Name = tableName;
            btnCreate.Content = tbDialog.ReturnValue;
            btnCreate.Width = 50;
            btnCreate.Height = 50;
            btnCreate.Margin = margin;

            btnCreate.PreviewMouseUp += Button_MouseUp;
            btnCreate.PreviewMouseLeftButtonDown += Button_MouseLeftButtonUp;
            btnCreate.PreviewMouseMove += Button_MouseMove;
            btnCreate.MouseLeftButtonUp += Button_MouseLeftButtonUp;
            btnCreate.MouseMove += Button_MouseMove;
            btnCreate.MouseUp += Button_MouseUp;

            sectionFront.Children.Add(btnCreate);

        }

        private void BtnMergeTable_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRemoveTable_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Get the Position of Window so that it will set margin from this window
            m_MouseX = e.GetPosition(this).X;
            m_MouseY = e.GetPosition(this).Y;

            Button btnTemp = sender as Button;
            Console.WriteLine(btnTemp.Name);
                     
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Button btn = sender as Button;
                // Capture the mouse for border
                e.MouseDevice.Capture(btn);
                Thickness _margin = new Thickness();
                int _tempX = Convert.ToInt32(e.GetPosition(this).X);
                int _tempY = Convert.ToInt32(e.GetPosition(this).Y);
                _margin = btn.Margin;
                // when While moving _tempX get greater than m_MouseX relative to usercontrol 
                if (m_MouseX > _tempX)
                {
                    // add the difference of both to Left
                    _margin.Left += (_tempX - m_MouseX);
                    // subtract the difference of both to Left
                    _margin.Right -= (_tempX - m_MouseX);
                }
                else
                {
                    _margin.Left -= (m_MouseX - _tempX);
                    _margin.Right -= (_tempX - m_MouseX);
                }

                if (m_MouseY > _tempY)
                {
                    _margin.Top += (_tempY - m_MouseY);
                    _margin.Bottom -= (_tempY - m_MouseY);
                }
                else
                {
                    _margin.Top -= (m_MouseY - _tempY);
                    _margin.Bottom -= (_tempY - m_MouseY);
                }

                btn.Margin = _margin;
                m_MouseX = _tempX;
                m_MouseY = _tempY;
            }
        }

        private void Button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            e.MouseDevice.Capture(null);
        }
    }
}
