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
        private Page currentPage;
        private ContentTxpe currentPageType;
        public Dictionary<ContentTxpe,Page> Pages { get; set; }



        public Page CurrentPage 
        {
            get => this.currentPage;
            set
            {
                SetProperty(ref this.currentPage, value);
            }
        }
        public static bool IsInDesigneMode 
        {
            get 
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public ICommand  AddCmd{ get; set; }
        public ICommand  DelCmd{ get; set; }
        public ICommand  ModCmd{ get; set; }
        public ICommand  ChangePageToWarehouseCmd{ get; set; }
        public ICommand  ChangePageToBlacksmithCmd{ get; set; }
        public ICommand  ChangePageToGeneralCmd{ get; set; }
        public MainWindowVm()
        {
            if (!IsInDesigneMode)
            {

                //http://localhost:5025/Warehouse
                //WareHouses = new RestCollection<WareHouse>("http://localhost:5025/", "Warehouse", "hub");
                AddCmd = new RelayCommand(() => this.Adding());

                //    ModCmd = new RelayCommand(() =>
                //    {
                //        WareHouses.Update(SelectedWareHouse);
                //    });

                //    DelCmd = new RelayCommand(() =>
                //    {
                //        WareHouses.Delete(SelectedWareHouse.Id);
                //    },
                //    () => { return SelectedWareHouse != null; });
                //SelectedWareHouse = new WareHouse(); 

                ChangePageToBlacksmithCmd = new RelayCommand(() => ChangePage(ContentTxpe.Blacksmith));
                ChangePageToWarehouseCmd = new RelayCommand(() => ChangePage(ContentTxpe.WareHouse));
                ChangePageToGeneralCmd = new RelayCommand(() => ChangePage(ContentTxpe.General));
                Pages = new Dictionary<ContentTxpe, Page>();
                Pages.Add(ContentTxpe.WareHouse, new WarehousePage("http://localhost:5025/", nameof(WareHouse)));
                Pages.Add(ContentTxpe.Blacksmith, new BlacksmithPage("http://localhost:5025/", nameof(Blacksmith)));
                Pages.Add(ContentTxpe.General, new GeneralStorePage("http://localhost:5025/", nameof(Generalstore)));
                CurrentPage = Pages[ContentTxpe.WareHouse];
                this.currentPageType = ContentTxpe.WareHouse;
            }
           
        }

        private void ChangePage(ContentTxpe pageType)
        {
            CurrentPage = Pages[pageType];
            this.currentPageType = pageType;
        }
        private void Adding()
        {
            switch (this.currentPageType)
            {
                case ContentTxpe.WareHouse:
                    break;
                case ContentTxpe.General:
                    break;
                case ContentTxpe.Blacksmith:
                    (CurrentPage.DataContext as BlacksmithVm).Add(); 
                    break;
                default:
                    break;
            }
        }
    }
}
