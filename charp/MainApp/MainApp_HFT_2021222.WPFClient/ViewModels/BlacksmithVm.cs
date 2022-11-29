using MainApp.Models.DBModels;
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
        public RestCollection<Blacksmith> Blacksmiths { get; set; }

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
