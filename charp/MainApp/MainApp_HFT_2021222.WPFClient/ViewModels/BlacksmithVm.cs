using MainApp.Models.DBModels;
using MainApp_HFT_2021222.WPFClient.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MainApp_HFT_2021222.WPFClient.ViewModels
{
    public class BlacksmithVm : ObservableRecipient
    {
        private RestCollection<Blacksmith> blacksmiths;
        private Blacksmith selectedBlacksmith;
        public BlacksmithVm()
        {

        }

        public BlacksmithVm(string baseurl, string table)
        {
            if (!IsInDesigneMode)
            {
                Blacksmiths = new RestCollection<Blacksmith>(baseurl, table, "hub");
                SelectedBlacksmith = Blacksmiths.FirstOrDefault();
            }
        }
        public RestCollection<Blacksmith> Blacksmiths 
        {
            get => this.blacksmiths;
            set
            {
                SetProperty(ref this.blacksmiths, value);
            }
        }

        public Blacksmith SelectedBlacksmith
        {
            get { return selectedBlacksmith; }
            set
            {
                if (value != null)
                {
                    selectedBlacksmith = new Blacksmith()
                    {
                        Id = value.Id,
                        Name = value.Name
                    };
                    OnPropertyChanged();
                    //(DelCmd as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public void Add()
        {
            BlacksmithEditorWindow win = new BlacksmithEditorWindow();
            if (win.ShowDialog() == true)
            {
                Blacksmiths.Add(win.DataContext as Blacksmith);
               // OnPropertyChanged(nameof(Blacksmiths));
            }
        }
        public void Remove()
        {
            if (SelectedBlacksmith == null) return;
            Blacksmiths.Delete(SelectedBlacksmith.Id);
        }
        public void Update()
        {
            if (SelectedBlacksmith == null) return;
            BlacksmithEditorWindow win = new BlacksmithEditorWindow(SelectedBlacksmith);
            if (win.ShowDialog() == true)
            {
                Blacksmiths.Update(win.DataContext as Blacksmith);
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
    }
}
