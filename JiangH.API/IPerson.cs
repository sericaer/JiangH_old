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
        ReadOnlyObservableCollection<IPersonCommand> commands { get; }

        void AddEstate(IEstate estate);
        void RemoveEstate(IEstate estate);
    }
}
