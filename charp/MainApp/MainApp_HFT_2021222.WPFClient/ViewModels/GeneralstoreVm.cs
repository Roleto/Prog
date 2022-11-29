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
    public class GeneralstoreVm : ObservableRecipient
    {
        private Generalstore selectedGeneralstore;
        public GeneralstoreVm()
        {

        }

        public GeneralstoreVm(string baseurl, string table)
        {
            if (!IsInDesigneMode)
            {
                Generalstores = new RestCollection<Generalstore>(baseurl, table, "hub");
                SelectedBlacksmith = Generalstores.FirstOrDefault();
            }
        }
        public RestCollection<Generalstore> Generalstores { get; set; }

        public Generalstore SelectedBlacksmith
        {
            get { return selectedGeneralstore; }
            set
            {
                if (value != null)
                {
                    selectedGeneralstore = new Generalstore()
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
