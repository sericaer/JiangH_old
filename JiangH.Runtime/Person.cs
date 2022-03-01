using JiangH.API;
using JiangH.Runtime.Relations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace JiangH.Runtime
{
    public partial class Person : IPerson
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; set; }

        public ISect sect => _sect;

        public int money { get; set; }

        public ReadOnlyObservableCollection<IEstate> estates { get; private set; }

        public IEnergyMgr energyMgr { get; private set; }

        internal ObservableCollection<IEstate> _estates;
        internal Sect _sect { get; set; }

        public Person(string name)
        {
            this.name = name;

            _estates = new ObservableCollection<IEstate>();
            estates = new ReadOnlyObservableCollection<IEstate>(_estates);

            energyMgr = new EnergyMgr(this);

            _estates.CollectionChanged += (sender, e) =>
             {
                 if(e.NewItems != null)
                 {
                     foreach (IEstate elem in e.NewItems)
                     {
                         energyMgr.AddEstateOccupy(elem);
                         _sect._estates.Add(elem);
                     }
                 }

                 if (e.OldItems != null)
                 {
                     foreach (IEstate elem in e.OldItems)
                     {
                         energyMgr.RemoveEstateOccupy(elem);
                         _sect._estates.Remove(elem);
                     }
                 }
             };
        }

        public IEnumerable<IPersonCommand> GetCommands()
        {
            var list = new List<IPersonCommand>();

            for (int i = 0; i < 5; i++)
            {
                var def = new PersonCommandDef();
                def.key = $"Command{i}";

                def.Do = (owner, targets) =>
                {

                };

                def.isValid = (owner) =>
                {
                    return true;
                };

                if (i == 0)
                {
                    def.key = "没收产业";

                    def.getTargets = (owner) =>
                    {
                        var person = owner as IPerson;
                        return person.estates.Select(x => new CommandTarget() { param = x, key = x.name });
                    };

                    def.Do = (owner, targets) =>
                    {
                        var person = owner as IPerson;

                        foreach (var estate in targets.Select(x => x.param as IEstate))
                        {
                            estate.SetManager(GSession.inst.player);
                        }
                    };

                    def.isValid = (owner) =>
                    {
                        return owner != GSession.inst.player;
                    };
                }

                if (i == 1)
                {
                    def.key = "授予产业";

                    def.getTargets = (owner) =>
                    {
                        return GSession.inst.player.estates.Select(x => new CommandTarget() { param = x, key = x.name });
                    };

                    def.Do = (owner, targets) =>
                    {
                        var person = owner as IPerson;

                        foreach (var estate in targets.Select(x => x.param as IEstate))
                        {
                            estate.SetManager(person);
                        }
                    };

                    def.isValid = (owner) =>
                    {
                        return owner != GSession.inst.player;
                    };
                }

                list.Add(new PersonCommand(this, def));
            }

            return list;
        }

        public int GetEnergyOccupyValue(EnergyOccupyLevel occupyLevel, IEnergyOccupyTarget target)
        {
            return ((int)occupyLevel + 1) * 3;
        }

        public void SetSect(ISect sect)
        {
            GSession.inst.relationMgr.Change<Relation_Person_Sect>(this, _sect, sect);
        }
    }
}