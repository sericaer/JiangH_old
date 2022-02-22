using JiangH.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH.Runtime
{
    public class Estate : IEstate
    {
        public string name { get; set; }

        public IPerson owner { get; set; }

        public EnergyOccupyLevel level { get; set; }

        public Estate(string name)
        {
            this.name = name;
        }

        public void OnDayInc(int year, int month, int day)
        {
            if(day == 30)
            {
                owner.money += (int)level+1 * 100;
            }
        }
    }
}
