using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MainApp_HFT_2021222.WPFClient.ViewModels
{
    public class EditorVM : ObservableRecipient
    {
        public EditorVM()
        {

        }
        public EditorVM(ITableVM vm)
        {
            Vm = vm;

        }

        public ITableVM Vm { get; set; }
        public Page CurrentPage{ get; set; }

    }
}
