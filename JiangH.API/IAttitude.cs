using System.ComponentModel;

namespace JiangH.API
{
    public interface IAttitude : INotifyPropertyChanged
    {
        int total { get; }

        IPerson peer { get; }

        void Add(object key, int value);
    }
}
