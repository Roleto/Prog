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
        public WarehouseVm WareVm { get; set; }
        public RestCollection<Warehouse> Wares { get; set; }
        public RestCollection<Blacksmith> Blacksmiths { get; set; }
        public RestCollection<Generalstore> Generalstores { get; set; }



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
                //Blacksmiths = new RestCollection<Blacksmith>("http://localhost:5025/", "Blacksmith", "hub");
                //Generalstores = new RestCollection<Generalstore>("http://localhost:5025/", "GeneralStore", "hub");
                
                //ModCmd = new RelayCommand(() => this.Modding());
                //DelCmd= new RelayCommand(() => this.Deleting());
                


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

                ChangePageToBlacksmithCmd = new RelayCommand(() => OpenWindow(ContentTxpe.Blacksmith));
                ChangePageToWarehouseCmd = new RelayCommand(() => OpenWindow(ContentTxpe.WareHouse));
                ChangePageToGeneralCmd = new RelayCommand(() => OpenWindow(ContentTxpe.General));
                
                //Pages.Add(ContentTxpe.WareHouse, new WarehousePage("http://localhost:5025/", "Warehouse"));
                //Pages.Add(ContentTxpe.Blacksmith, new BlacksmithPage("http://localhost:5025/", "Blacksmith"));
                //Pages.Add(ContentTxpe.General, new GeneralStorePage("http://localhost:5025/", "GeneralStore"));
                //(Pages[ContentTxpe.WareHouse] as WarehousePage).UpdtatePage(WareVM);
            }
           
        }  
        
        private void OpenWindow(ContentTxpe pageType)
        {
            if (Wares == null)
            {
                Wares = new RestCollection<Warehouse>("http://localhost:5025/", "Warehouse", "hub");
            }
            switch (pageType)
            {
                case ContentTxpe.WareHouse:

                    WharehouseEditorWindow win = new WharehouseEditorWindow();
                    if (win.ShowDialog() == true)
                    {

                    }
                    break;
                case ContentTxpe.General:
                    break;
                case ContentTxpe.Blacksmith:
                    break;
                default:
                    break;
            }
        }
        
    }
}
