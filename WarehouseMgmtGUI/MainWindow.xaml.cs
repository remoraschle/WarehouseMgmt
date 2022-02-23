﻿using System;
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
using WarehouseMgmtDB;

namespace WarehouseMgmtGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //EntityManager entityManager = new EntityManager();
            //entityManager.AddArticle();
        }

        private void btnCustomerNew_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            customer.Show();
        }

        private void btnCustomerEdit_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            customer.Show();
        }
    }
}
