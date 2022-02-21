using JiangH.API;
using PropertyChanged;
using System.ComponentModel;

namespace JiangH.Runtime
{
    internal class EnergyOccupy : IEnergyOccupy
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string name => target.name;
        public EnergyOccupyLevel occupyLevel { get; set; }

        public int value => (int)(occupyLevel+1) * 3;

        public IEnergyOccupyTarget target { get; private set; }

        public EnergyOccupy(IEnergyOccupyTarget target)
        {
            this.target = target;
            this.occupyLevel = EnergyOccupyLevel.VeryLow;
        }
    }
}