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

        int value { get; }

        EnergyOccupyLevel occupyLevel { get; set; }

        IEnergyOccupyTarget target { get; }

        string GetLevelDesc(EnergyOccupyLevel level);
    }
}