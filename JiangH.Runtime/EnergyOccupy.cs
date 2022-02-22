using JiangH.API;
using PropertyChanged;
using System.ComponentModel;

namespace JiangH.Runtime
{
    internal class EnergyOccupy : IEnergyOccupy
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string name => target.name;
        public EnergyOccupyLevel occupyLevel
        {
            get
            {
                return _occupyLevel;
            }
            set
            {
                _occupyLevel = value;
                target.level = _occupyLevel;
            }
        }

        public int value => (int)(occupyLevel+1) * 3;

        public IEnergyOccupyTarget target { get; private set; }

        private EnergyOccupyLevel _occupyLevel;

        public EnergyOccupy(IEnergyOccupyTarget target)
        {
            this.target = target;
            this.occupyLevel = EnergyOccupyLevel.VeryLow;


        }
    }
}