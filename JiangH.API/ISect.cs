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

        IPerson manager { get; }

        ReadOnlyObservableCollection<IPerson> persons { get; }

        ReadOnlyObservableCollection<IEstate> estates { get; }

        void SetManager(IPerson person);
    }
}
