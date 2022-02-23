using JiangH.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH.Runtime
{
    public class MarketDef : IEstateDef
    {
        public IEnumerable<(string pdtName, int value)> getEnergyOccupyLevelEffect(EnergyOccupyLevel level)
        {
            var rslt = new List<(string pdtName, int value)>();

            switch(level)
            {
                case EnergyOccupyLevel.VeryLow:
                    break;
                case EnergyOccupyLevel.Low:
                    rslt.Add(("money", 10));
                    break;
                case EnergyOccupyLevel.Midder:
                    rslt.Add(("money", 50));
                    break;
                case EnergyOccupyLevel.High:
                    rslt.Add(("money", 80));
                    break;
                case EnergyOccupyLevel.VeryHigh:
                    rslt.Add(("money", 100));
                    break;
                default:
                    throw new Exception();
            }

            return rslt;
        }
    }
}
