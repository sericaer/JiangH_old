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

        ISect sect { get; set; }

        IPerson owner { get; set; }

        ReadOnlyObservableCollection<IPerson> persons { get; }

        void SetMain();
    }
}
