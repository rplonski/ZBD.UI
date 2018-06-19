using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using ZBD.UI.Services;

namespace ZBD.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HideBusView();
        

        }

        private void btnSearchClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var busData = BusDataService.GetBusDataByName(tbSearch.Text);
                if(busData != null)
                {
                    ShowBusView();
                    tbName.Text = busData.Name;
                    tbModel.Text = busData.Model;
                    tbSeats.Text = busData.Seats.ToString();
                }
                else
                {
                    HideBusView();
                    lblNoResult.Visibility = Visibility.Visible;
                }
            }
            catch(Exception ex)
            {
                // TODO: Show dialog box
            }
           



        }

        private void ShowBusView()
        {
            tbName.Visibility = Visibility.Visible;
            tbModel.Visibility = Visibility.Visible;
            tbSeats.Visibility = Visibility.Visible;

            lblModel.Visibility = Visibility.Visible;
            lblName.Visibility = Visibility.Visible;
            lblSeats.Visibility = Visibility.Visible;

            btnShowPassengers.Visibility = Visibility.Visible;
            lblNoResult.Visibility = Visibility.Hidden;
        }

        private void HideBusView()
        {
            tbName.Visibility = Visibility.Hidden;
            tbModel.Visibility = Visibility.Hidden;
            tbSeats.Visibility = Visibility.Hidden;

            lblModel.Visibility = Visibility.Hidden;
            lblName.Visibility = Visibility.Hidden;
            lblSeats.Visibility = Visibility.Hidden;

            btnShowPassengers.Visibility = Visibility.Hidden;
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnSearchClick(sender, e);
            }
        }

        private void btnShowPassengers_Click(object sender, RoutedEventArgs e)
        {
            PassengersWindow passengersWindow = new PassengersWindow();
            passengersWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BusDataService.GenerateAndInsertRandomData();
        }
    }
}
