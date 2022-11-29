﻿using MainApp_HFT_2021222.WPFClient.ViewModels;
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

namespace MainApp_HFT_2021222.WPFClient.Windows
{
    /// <summary>
    /// Interaction logic for BlacksmithPage.xaml
    /// </summary>
    public partial class BlacksmithPage : Page
    {
        public BlacksmithPage()
        {
            InitializeComponent();
        }
        public BlacksmithPage(string baseurl, string table)
        {
            InitializeComponent();
            this.DataContext = new BlacksmithVm(baseurl, table);
        }
    }
}
