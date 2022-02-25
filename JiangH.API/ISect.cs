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

        ReadOnlyObservableCollection<IPerson> persons { get; }

        ReadOnlyObservableCollection<IBranch> branches { get; }

        ReadOnlyObservableCollection<IEstate> estates { get; }
    }
}
