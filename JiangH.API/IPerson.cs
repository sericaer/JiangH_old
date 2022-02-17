using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace JiangH.API
{
    public interface IPerson : INotifyPropertyChanged
    {
        string name { get; set; }

        int money { get; set; }

        ReadOnlyObservableCollection<IEstate> estates { get;}
    }
}
