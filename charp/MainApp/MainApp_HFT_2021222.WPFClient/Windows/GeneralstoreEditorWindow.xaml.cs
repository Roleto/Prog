using MainApp.Models.DBModels;
using MainApp_HFT_2021222.WPFClient.ViewModels;
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

namespace MainApp_HFT_2021222.WPFClient.Windows
{
    /// <summary>
    /// Interaction logic for GeneralstoreEditorWindow.xaml
    /// </summary>
    public partial class GeneralstoreEditorWindow : Window
    {
        public GeneralstoreEditorWindow()
        {
            InitializeComponent();
            this.DataContext = new GeneralstoreVm();
        }
        public GeneralstoreEditorWindow(Generalstore generalstore)
        {
            InitializeComponent();
          //  this.DataContext = generalstore;

        }

        private void OkCick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        private void FalseCick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
