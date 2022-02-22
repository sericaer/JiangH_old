using System;

namespace JiangH.API
{
    public interface IEstate : IEnergyOccupyTarget
    {
        IPerson owner { get; set; }
        void OnDayInc(int year, int month, int day);
    }
}