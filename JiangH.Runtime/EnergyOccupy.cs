using JiangH.API;
using PropertyChanged;
using System.ComponentModel;
using System.Linq;

namespace JiangH.Runtime
{
    internal class EnergyOccupy : IEnergyOccupy
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name => target.name;

        public int energyValue { get; private set; }

        [DoNotCheckEquality]
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

                energyValue = owner.GetEnergyOccupyValue(_occupyLevel, target);
            }
        }

        public IEnergyOccupyTarget target { get; private set; }

        private EnergyOccupyLevel _occupyLevel;

        private readonly IPerson owner;

        public EnergyOccupy(IEnergyOccupyTarget target, IPerson owner)
        {
            this.owner = owner;
            this.target = target;

            occupyLevel = EnergyOccupyLevel.VeryLow;
        }

        public string GetLevelDesc(EnergyOccupyLevel level)
        {
            var ownerEffectDesc = $"energyValue -{owner.GetEnergyOccupyValue(level, target)}";
            var targetEffectDesc = string.Join("\n", target.getLevelEffect(level).Select(x=>$"{x.pdtName} {x.value}"));

            return $"{ownerEffectDesc}\n\n{targetEffectDesc}";
        }
    }
}