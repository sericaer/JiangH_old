using System;

namespace JiangH.API
{
    public interface IEstate : IEnergyOccupyTarget, IPoint
    {
        IPerson manager { get;  }
        void OnDayInc(int year, int month, int day);
        void SetManager(IPerson person);
    }
}