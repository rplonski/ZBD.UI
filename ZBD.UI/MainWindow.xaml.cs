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

        

        }

        private void btnSearchClick(object sender, RoutedEventArgs e)
        {
            var busData = BusDataService.GetBusDataByName(tbSearch.Text);
            tbName.Text = busData.Name;
            tbModel.Text = busData.Model;
            tbSeats.Text = busData.Seats.ToString();



        }
    }
}
