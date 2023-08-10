using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace InventoryManager.Views {
    /// <summary>
    /// Interaction logic for AddView.xaml
    /// </summary>
    public partial class AddView:UserControl
    {

        public AddView()
        {
            InitializeComponent();
        }

        private void DecimalTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            bool approvedDecimalPoint = false;


            if (e.Text == ".")
            {
                if (!((TextBox)sender).Text.Contains("."))
                    approvedDecimalPoint = true;
            }

            if (!(char.IsDigit(e.Text, e.Text.Length - 1) || approvedDecimalPoint))
            {
                e.Handled = true;
            }

            if (Regex.IsMatch(((TextBox)sender).Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }


    }
       
}
