using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace JiangH.API
{
    public interface ISect : IPoint, INotifyPropertyChanged
    {
        string name { get; set; }

        IBranch mainBranch { get; set; }

        ObservableCollection<IPerson> persons { get; }

        ObservableCollection<IBranch> branches { get; }
    }
}
