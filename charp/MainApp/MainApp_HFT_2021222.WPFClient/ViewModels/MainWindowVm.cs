using MainApp.Models.DBModels;
using MainApp_HFT_2021222.WPFClient.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MainApp_HFT_2021222.WPFClient.ViewModels
{
    public enum ContentTxpe
    {
        WareHouse,
        General,
        Blacksmith
    }
    public class MainWindowVm : ObservableRecipient
    {
        public static bool IsInDesigneMode 
        {
            get 
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public ICommand  OpenWareCmd { get; set; }
        public ICommand  OpenBlacksmithCmd{ get; set; }
        public ICommand  OpenGeneralCmd { get; set; }
        public MainWindowVm()
        {
            if (!IsInDesigneMode)
            {
                OpenBlacksmithCmd = new RelayCommand(() => OpenWindow(ContentTxpe.Blacksmith));
                OpenWareCmd  = new RelayCommand(() => OpenWindow(ContentTxpe.WareHouse));
                OpenGeneralCmd  = new RelayCommand(() => OpenWindow(ContentTxpe.General));
            }
           
        }  
        
        private void OpenWindow(ContentTxpe pageType)
        {
            switch (pageType)
            {
                case ContentTxpe.WareHouse:
                    WharehouseEditorWindow warewin = new WharehouseEditorWindow();
                    warewin.ShowDialog();
                    break;
                case ContentTxpe.General:
                    GeneralstoreEditorWindow generalwin = new GeneralstoreEditorWindow();
                    generalwin.ShowDialog();
                    break;
                case ContentTxpe.Blacksmith:
                    BlacksmithEditorWindow blackwin = new BlacksmithEditorWindow();
                    blackwin.ShowDialog();
                    break;
            }
        }
        
    }
}
