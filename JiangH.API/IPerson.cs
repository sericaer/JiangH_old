using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace JiangH.API
{
    public interface IPerson : INotifyPropertyChanged, IPoint
    {
        string name { get; set; }

        ISect sect { get; }
        
        int money { get; set; }

        ReadOnlyObservableCollection<IEstate> estates { get;}

        IEnergyMgr energyMgr { get; }

        IEnumerable<IPersonCommand> GetCommands();

        int GetEnergyOccupyValue(EnergyOccupyLevel occupyLevel, IEnergyOccupyTarget target);
        void SetSect(ISect sect);
    }
}
