using System.Collections.ObjectModel;
using System.ComponentModel;

namespace JiangH.API
{
    public interface IEnergyMgr : INotifyPropertyChanged
    {
        int energyValue { get; }

        int totalEstateOccupied { get; }

        ReadOnlyObservableCollection<IEnergyOccupy> estateOccupys { get; }

        void AddEstateOccupy(IEstate estate);
        void RemoveEstateOccupy(IEstate estate);
    }
}