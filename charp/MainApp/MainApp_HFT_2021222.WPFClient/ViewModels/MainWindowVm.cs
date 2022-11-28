using MainApp.Models.DBModels;
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
using System.Windows.Input;

namespace MainApp_HFT_2021222.WPFClient.ViewModels
{
    public class MainWindowVm : ObservableRecipient
    {
        private WareHouse selectedWareHouse;
        public RestCollection<WareHouse> WareHouses { get; set; }

        public static bool IsInDesigneMode 
        {
            get 
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
                
        }


        public WareHouse SelectedWareHouse
        {
            get { return selectedWareHouse; }
            set 
            { 
                if(value != null)
                {
                    selectedWareHouse = new WareHouse()
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
        public MainWindowVm()
        {
            if (!IsInDesigneMode)
            {
                //'http://localhost:5025/Warehouse'
                WareHouses = new RestCollection<WareHouse>("http://localhost:5025/", "Warehouse", "hub");
                AddCmd = new RelayCommand(() =>
                {
                    WareHouses.Add(new WareHouse() { Name = SelectedWareHouse.Name });
                });

                ModCmd = new RelayCommand(() =>
                {
                    WareHouses.Update(SelectedWareHouse);
                });

                DelCmd = new RelayCommand(() =>
                {
                    WareHouses.Delete(SelectedWareHouse.Id);
                },
                () => { return SelectedWareHouse != null; });
            SelectedWareHouse = new WareHouse(); 
            }
           
        }
    }
}
