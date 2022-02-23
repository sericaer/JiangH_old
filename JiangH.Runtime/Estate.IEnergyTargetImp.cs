using JiangH.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace JiangH.Runtime
{
    public partial class Estate : IEstate
    {

        public IEnumerable<(string pdtName, int value)> getLevelEffect(EnergyOccupyLevel level)
        {
            var effectDef = def.getEnergyOccupyLevelEffect(level);

            return effectDef.Where(x=>products.ContainsKey(x.pdtName)).Select(x =>(x.pdtName, x.value * products[x.pdtName].baseValue / 100));
        }
    }
}
