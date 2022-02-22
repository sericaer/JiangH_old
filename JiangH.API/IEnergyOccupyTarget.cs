using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH.API
{
    public interface IEnergyOccupyTarget
    {
        string name { get; set; }

        EnergyOccupyLevel level { get; set; }
    }
}
