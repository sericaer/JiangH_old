using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace JiangH.API
{
    public interface IPerson : INotifyPropertyChanged
    {
        string name { get; set; }

        int money { get; set; }

        ReadOnlyObservableCollection<IEstate> estates { get;}

        IEnergyMgr energyMgr { get; }

        IEnumerable<IPersonCommand> GetCommands();

        void AddEstate(IEstate estate);
        void RemoveEstate(IEstate estate);
    }
}
