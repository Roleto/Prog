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
using System.Windows.Input;

namespace MainApp_HFT_2021222.WPFClient.ViewModels
{
    public class GeneralstoreVm : ObservableRecipient
    {
        private Generalstore selectedgenral;
        private Generalstore editedgeneral;
        private RestCollection<Generalstore> generals;

        public GeneralstoreVm()
        {
            if (!IsInDesigneMode)
            {
                Generalstores = new RestCollection<Generalstore>("http://localhost:5025/", "GeneralStore", "hub");
                selectedgenral = Generalstores.FirstOrDefault();
                AddCmd = new RelayCommand(() => this.Add());
                ModCmd = new RelayCommand(() => this.Uppdate());
                DelCmd = new RelayCommand(() => this.Remove());
            }

        }
        //new
        public GeneralstoreVm(RestCollection<Generalstore> wareHouses)
        {
            if (!IsInDesigneMode)
            {
                Generalstores = wareHouses;
                selectedgenral = wareHouses.First();
                AddCmd = new RelayCommand(() => this.Add());
            }
        }
        //new

        public GeneralstoreVm(string baseurl, string table)
        {
            if (!IsInDesigneMode)
            {
                var wares = new RestCollection<Generalstore>(baseurl, table, "hub");
                SelectedGeneral = Generalstores.FirstOrDefault();
            }
        }
        public RestCollection<Generalstore> Generalstores { get => generals; set => generals = value; }

        public Generalstore SelectedGeneral
        {
            get { return selectedgenral; }
            set
            {
                if (value != null)
                {
                    selectedgenral = new Generalstore(value.Id, value.MaterialId, value.Name, value.Price, value.Quality);
                    EditedGeneral = value;
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

        public Generalstore EditedGeneral
        {
            get { return editedgeneral; }
            set
            {
                if (value != null)
                {
                    editedgeneral = new Generalstore(value.Id, value.MaterialId, value.Name, value.Price, value.Quality);
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
            Generalstores.Add(EditedGeneral);
            EditedGeneral = new Generalstore();
        }

        public void Remove()
        {
            if (SelectedGeneral == null) return;
            Generalstores.Delete(SelectedGeneral.Id);
        }

        public void Uppdate()
        {
            if (EditedGeneral == null) return;
            Generalstores.Update(EditedGeneral);
            EditedGeneral = new Generalstore();
        }
    }
}
