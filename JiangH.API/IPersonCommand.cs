using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace JiangH.API
{
    public interface IPersonCommand : INotifyPropertyChanged
    {
        string key { get; set; }

        Func<bool> isValid { get; }

        IEnumerable<ICommandTarget> targets { get; }

        void Do(IEnumerable<ICommandTarget> targets);
    }
}
