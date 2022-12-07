using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MainApp_HFT_2021222.WPFClient.ViewModels
{
    public interface ITableVM
    {
        public Page VmPage { get; set; }
        void Add();
        void Remove();

        void Uppdate();
    }
}
