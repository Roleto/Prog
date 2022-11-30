using MainApp.Models.DBModels;
using MainApp_HFT_2021222.WPFClient.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MainApp_HFT_2021222.WPFClient.ViewModels
{
    public class WarehouseVm : ObservableRecipient
    {
        private WareHouse selectedWareHouse;
        public WarehouseVm()
        {

        }

        public WarehouseVm(string baseurl, string table)
        {
            if (!IsInDesigneMode)
            {
                WareHouses = new RestCollection<WareHouse>(baseurl, table, "hub");
                SelectedWareHouse = WareHouses.FirstOrDefault();
            }
        }
        public RestCollection<WareHouse> WareHouses { get; set; }

        public WareHouse SelectedWareHouse
        {
            get { return selectedWareHouse; }
            set
            {
                if (value != null)
                {
                    selectedWareHouse = new WareHouse()
                    {
                        Id = value.Id,
                        Name = value.Name
                    };
                    OnPropertyChanged();
                    //(DelCmd as RelayCommand).NotifyCanExecuteChanged();
                }
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

        public void Add()
        {
            WharehouseEditorWindow win = new WharehouseEditorWindow();
            if (win.ShowDialog() == true)
            {
                WareHouses.Add(win.DataContext as WareHouse);
            }
        }
        public void Remove()
        {
            if (SelectedWareHouse == null) return;
            WareHouses.Delete(SelectedWareHouse.Id);
        }
        public void Update()
        {
            if (SelectedWareHouse == null) return;
            WharehouseEditorWindow win = new WharehouseEditorWindow(SelectedWareHouse);
            if (win.ShowDialog() == true)
            {
                WareHouses.Update(win.DataContext as WareHouse);
            }
        }
    }
}
