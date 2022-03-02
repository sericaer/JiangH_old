using System.Collections.Generic;
using System.ComponentModel;

namespace JiangH.API
{
    public interface IAttitude : INotifyPropertyChanged
    {
        IEnumerable<(object label, int value)> elements { get; }

        int total { get; }

        IPerson peer { get; }

        void Add(object key, int value);
    }
}
