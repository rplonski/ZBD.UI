﻿using System;
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
                    tbLocalization.Text = busData.Localization;
                    tbWidth.Text = busData.Width.ToString();
                    tbLength.Text = busData.Length.ToString();
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
            tbLocalization.Visibility = Visibility.Visible;
            tbLength.Visibility = Visibility.Visible;
            tbWidth.Visibility = Visibility.Visible;

            lblModel.Visibility = Visibility.Visible;
            lblName.Visibility = Visibility.Visible;
            lblSeats.Visibility = Visibility.Visible;
            lblLocalization.Visibility = Visibility.Visible;
            lblLength.Visibility = Visibility.Visible;
            lblWidth.Visibility = Visibility.Visible;

            btnShowPassengers.Visibility = Visibility.Visible;
            lblNoResult.Visibility = Visibility.Hidden;
        }

        private void HideBusView()
        {
            tbName.Visibility = Visibility.Hidden;
            tbModel.Visibility = Visibility.Hidden;
            tbSeats.Visibility = Visibility.Hidden;
            tbLocalization.Visibility = Visibility.Hidden;
            tbLength.Visibility = Visibility.Hidden;
            tbWidth.Visibility = Visibility.Hidden;

            lblModel.Visibility = Visibility.Hidden;
            lblName.Visibility = Visibility.Hidden;
            lblSeats.Visibility = Visibility.Hidden;
            lblLocalization.Visibility = Visibility.Hidden;
            lblLength.Visibility = Visibility.Hidden;
            lblWidth.Visibility = Visibility.Hidden;

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
            var busData = BusDataService.GetBusDataByName(tbName.Text);

            

            PassengersWindow passengersWindow = new PassengersWindow(busData.Passengers);
            passengersWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //  BusDataService.GenerateAndInsertRandomData
            BusDataService.UpdateData();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            BusDataService.ClearData();
        }

        private void btnInitializeData_Click(object sender, RoutedEventArgs e)
        {
            BusDataService.GenerateAndInsertRandomData();
        }
    }
}
