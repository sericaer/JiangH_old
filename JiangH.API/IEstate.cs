using System;

namespace JiangH.API
{
    public interface IEstate : IEnergyOccupyTarget
    {
        IPerson owner { get; }
    }
}