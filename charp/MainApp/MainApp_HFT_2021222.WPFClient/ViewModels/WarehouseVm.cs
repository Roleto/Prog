using MainApp.Models.DBModels;
using MainApp_HFT_2021222.WPFClient.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MainApp_HFT_2021222.WPFClient.ViewModels
{
    public class WarehouseVm : ObservableRecipient
    {
        private Warehouse selectedWareHouse;
        private Warehouse editedWareHouse;
        private RestCollection<Warehouse> wareHouses;

        public WarehouseVm()
        {
            if (!IsInDesigneMode)
            {
                WareHouses = new RestCollection<Warehouse>("http://localhost:5025/", "Warehouse", "hub");
                selectedWareHouse = WareHouses.FirstOrDefault();
                AddCmd = new RelayCommand(() => this.Add());
            }

        }
        //new
        public WarehouseVm(RestCollection<Warehouse> wareHouses)
        {
            if (!IsInDesigneMode)
            {
                WareHouses = wareHouses;
                selectedWareHouse = wareHouses.First();
                AddCmd = new RelayCommand(() => this.Add());
            }
        }
        //new

        public WarehouseVm(string baseurl, string table)
        {
            if (!IsInDesigneMode)
            {
                var wares = new RestCollection<Warehouse>(baseurl, table, "hub");
                SelectedWareHouse = WareHouses.FirstOrDefault();
            }
        }
        public RestCollection<Warehouse> WareHouses { get => wareHouses; set => wareHouses = value; }

        public Warehouse SelectedWareHouse // itt valami baj van
        {
            get { return selectedWareHouse; }
            set
            {
                if (value != null)
                {
                    selectedWareHouse = new Warehouse(value.Id, value.Name, value.MaterialType, value.Price, value.Quantity);
                    EditeddWareHouse = value;
                    //{
                    //    Id = value.Id,
                    //    Name = value.Name,
                    //    MaterialType = value.MaterialType,
                    //    Price = value.Price,
                    //    Quantity = value.Quantity                   
                    //};
                    //editedWareHouse = new WareHouse()
                    //{
                    //    Id = value.Id,
                    //    Name = value.Name,
                    //    MaterialType = value.MaterialType,
                    //    Price = value.Price,
                    //    Quantity = value.Quantity
                    //};
                    OnPropertyChanged();
                    //(DelCmd as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public Warehouse EditeddWareHouse
        {
            get { return editedWareHouse; }
            set
            {
                if (value != null)
                {
                    editedWareHouse = new Warehouse(value.Id, value.Name, value.MaterialType, value.Price, value.Quantity);
                    //editedWareHouse = new WareHouse()
                    //{
                    //    Id = value.Id,
                    //    Name = value.Name,
                    //    MaterialType = value.MaterialType,
                    //    Price = value.Price,
                    //    Quantity = value.Quantity
                    //};
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

        public ICommand AddCmd { get; set; }
        public ICommand DelCmd { get; set; }
        public ICommand ModCmd { get; set; }


        public void Add()
        {
                WareHouses.Add(SelectedWareHouse);
        }

        public void Remove()
        {
            if (SelectedWareHouse == null) return;
             WareHouses.Delete(SelectedWareHouse.Id);
        }

        public void Uppdate()
        {
            //if (SelectedWareHouse == null) return;
            //WharehouseEditorWindow win = new WharehouseEditorWindow(SelectedWareHouse);
            //if (win.ShowDialog() == true)
            //{
            //    WareHouses.Update(win.DataContext as WareHouse);
            //}
        }
    }
}
