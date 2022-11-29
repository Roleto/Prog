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


     

        public WareHouse SelectedBlacksmith
        {
            get { return selectedBlacksmith; }
            set
            {
                if (value != null)
                {
                    selectedBlacksmith = new WareHouse()
                    {
                        Id = value.Id,
                        Name = value.Name
                    };
                    OnPropertyChanged();
                    (DelCmd as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public WareHouse SelectedGeneralstore
        {
            get { return selectedGeneralstore; }
            set
            {
                if (value != null)
                {
                    selectedGeneralstore = new WareHouse()
                    {
                        Id = value.Id,
                        Name = value.Name
                    };
                    OnPropertyChanged();
                    (DelCmd as RelayCommand).NotifyCanExecuteChanged();
                }
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
                //    AddCmd = new RelayCommand(() =>
                //    {
                //        WareHouses.Add(new WareHouse() { Name = SelectedWareHouse.Name });
                //    });

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

                CurrentPage = new WarehousePage("http://localhost:5025/", "Warehouse");
            }
           
        }

        private void ChangePage(ContentTxpe pageType)
        {
                    CurrentPage = Pages[pageType];
        }
    }
}
