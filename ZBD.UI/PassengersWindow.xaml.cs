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
using System.Windows.Shapes;
using ZBD.UI.Models;

namespace ZBD.UI
{
    /// <summary>
    /// Interaction logic for PassengersWindow.xaml
    /// </summary>
    public partial class PassengersWindow : Window
    {
        public PassengersWindow(IList<Passenger> passengers)
        {
            InitializeComponent();

            for(int i = 0; i < passengers.Count; i++)
            {
                var tbName = (TextBox)this.FindName("tbName" + (i+1).ToString());
                var tbSurname = (TextBox)this.FindName("tbSurname" + (i + 1).ToString());
                var tbAge = (TextBox)this.FindName("tbAge" + (i + 1).ToString());

                tbName.Text = passengers[i].Name;
                tbSurname.Text = passengers[i].Surname;
                tbAge.Text = passengers[i].Age.ToString();

            }

        }
    }
}
