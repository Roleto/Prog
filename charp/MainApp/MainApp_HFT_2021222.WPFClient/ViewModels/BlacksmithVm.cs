using MainApp.Models.DBModels;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace MainApp_HFT_2021222.WPFClient.ViewModels
{
    public class BlacksmithVm : ObservableRecipient
    {
        private Blacksmith selectedBlacksmith;
        private Blacksmith editedBlacksmith;
        private RestCollection<Blacksmith> blacksmits;

        public BlacksmithVm()
        {
            if (!IsInDesigneMode)
            {
                Blacksmiths = new RestCollection<Blacksmith>("http://localhost:5025/", "Blacksmith", "hub");
                selectedBlacksmith = Blacksmiths.FirstOrDefault();
                AddCmd = new RelayCommand(() => this.Add());
                ModCmd = new RelayCommand(() => this.Uppdate());
                DelCmd = new RelayCommand(() => this.Remove());
            }

        }
        public RestCollection<Blacksmith> Blacksmiths { get => blacksmits; set => blacksmits = value; }

        public Blacksmith SelectedBlacksmith
        {
            get { return selectedBlacksmith; }
            set
            {
                if (value != null)
                {
                    selectedBlacksmith = new Blacksmith(value.Id, value.MaterialId, value.Name, value.Damaged, value.BasePrice, value.Quality);
                    EditeddBlacksmith = value;
                    OnPropertyChanged();
                }
            }
        }

        public Blacksmith EditeddBlacksmith
        {
            get { return editedBlacksmith; }
            set
            {
                if (value != null)
                {
                    editedBlacksmith = new Blacksmith(value.Id, value.MaterialId, value.Name, value.Damaged, value.BasePrice, value.Quality);
                    OnPropertyChanged();
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
            Blacksmiths.Add(EditeddBlacksmith);
            EditeddBlacksmith = new Blacksmith();
        }

        public void Remove()
        {
            if (SelectedBlacksmith == null) return;
            Blacksmiths.Delete(SelectedBlacksmith.Id);
        }

        public void Uppdate()
        {
            if (EditeddBlacksmith == null) return;
            Blacksmiths.Update(EditeddBlacksmith);
            EditeddBlacksmith = new Blacksmith();
        }

    }
}
