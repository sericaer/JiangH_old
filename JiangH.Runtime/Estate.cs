using JiangH.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JiangH.Runtime.Relations;

namespace JiangH.Runtime
{
    public partial class Estate : IEstate
    {
        public string name { get; set; }

        private IEstateDef def;

        public IPerson manager => _manager;

        public EnergyOccupyLevel level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;

                var effects = getLevelEffect(_level);
                foreach(var effect in effects)
                {
                    products[effect.pdtName].AddOrUpdateEffect("EnergyOccupyLevel", effect.value);
                }
            }
        }

        private Dictionary<string, IProduct> products = new Dictionary<string, IProduct>();

        private EnergyOccupyLevel _level;
        internal Person _manager { get; set; }

        public Estate(string name, IEstateDef def)
        {
            this.name = name;
            this.def = def;

            var pdt = new Money(100);
            products.Add(pdt.name, pdt);
        }

        public void OnDayInc(int year, int month, int day)
        {
            if(day == 30)
            {
                if(manager == null)
                {
                    return;
                }

                if(products.ContainsKey("money"))
                {
                    manager.money += products["money"].readlValue;
                }
            }
        }

        public void SetManager(IPerson person)
        {
            GSession.inst.relationMgr.Change<Relation_Estate_Manager>(this, manager, person);
        }
    }

    public interface IEstateDef
    {
        IEnumerable<(string pdtName, int value)> getEnergyOccupyLevelEffect(EnergyOccupyLevel level);
    }

    public class Money : IProduct
    {
        public int baseValue { get; private set; }

        public int readlValue { get; private set; }

        public string name => nameof(Money).ToLower();

        private Dictionary<string, int> effect = new Dictionary<string, int>();


        public Money(int baseValue)
        {
            this.baseValue = baseValue;
            UpdateRealValue();
        }

        public void AddOrUpdateEffect(string key, int value)
        {
            effect[key] = value;
            UpdateRealValue();
        }

        private void UpdateRealValue()
        {
            readlValue = baseValue + effect.Sum(x => x.Value);
        }
    }
}
