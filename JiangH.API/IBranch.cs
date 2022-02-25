using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace JiangH.API
{
    public interface IBranch : IPoint, INotifyPropertyChanged
    {
        string name { get; set; }

        ISect sect { get;}

        IPerson manager { get; }

        ReadOnlyObservableCollection<IPerson> persons { get; }
        ReadOnlyObservableCollection<IEstate> estates { get; }

        void SetMain();
        void SetSect(ISect sect);
        void SetManager(IPerson person);
    }
}
