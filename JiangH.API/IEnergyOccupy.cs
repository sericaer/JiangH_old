using System.ComponentModel;

namespace JiangH.API
{
    public enum EnergyOccupyLevel
    {
        VeryLow,
        Low,
        Midder,
        High,
        VeryHigh
    }

    public interface IEnergyOccupy : INotifyPropertyChanged
    {
        string name { get; }

        EnergyOccupyLevel occupyLevel { get; set; }

        int value { get; }

        IEnergyOccupyTarget target { get; }
    }
}