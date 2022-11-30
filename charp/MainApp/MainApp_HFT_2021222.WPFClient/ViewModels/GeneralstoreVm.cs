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
                SelectedGeneralstore = Generalstores.FirstOrDefault();
            }
        }
        public RestCollection<Generalstore> Generalstores { get; set; }

        public Generalstore SelectedGeneralstore
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
        public void Add()
        {
            GeneralstoreEditorWindow win = new GeneralstoreEditorWindow();
            if (win.ShowDialog() == true)
            {
                Generalstores.Add(win.DataContext as Generalstore);
            }
        }
        public void Remove()
        {
            if (SelectedGeneralstore == null) return;
            Generalstores.Delete(SelectedGeneralstore.Id);
        }
        public void Update()
        {
            if (SelectedGeneralstore == null) return;
            GeneralstoreEditorWindow win = new GeneralstoreEditorWindow(SelectedGeneralstore);
            if (win.ShowDialog() == true)
            {
                Generalstores.Update(win.DataContext as Generalstore);
            }
        }
    }
}
