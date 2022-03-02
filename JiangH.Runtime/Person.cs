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

        public IPerson master => _master;

        public IPerson manager => _manager;

        public int money { get; set; }

        public ReadOnlyObservableCollection<IEstate> estates { get; private set; }

        public ReadOnlyObservableCollection<IPerson> apprentices { get; private set; }

        public ReadOnlyObservableCollection<IPerson> subordinates { get; private set; }

        public IEnergyMgr energyMgr { get; private set; }

        public IAttitudeMgr attitudeMgr { get; private set; }

        internal ObservableCollection<IEstate> _estates = new ObservableCollection<IEstate>();
        internal ObservableCollection<IPerson> _apprentices = new ObservableCollection<IPerson>();
        internal ObservableCollection<IPerson> _subordinates = new ObservableCollection<IPerson>();

        internal Sect _sect { get; set; }
        internal IPerson _master { get; set; }
        internal Person _manager { get; set; }

        public Person(string name)
        {
            this.name = name;

            estates = new ReadOnlyObservableCollection<IEstate>(_estates);
            apprentices = new ReadOnlyObservableCollection<IPerson>(_apprentices);
            subordinates = new ReadOnlyObservableCollection<IPerson>(_subordinates);

            energyMgr = new EnergyMgr(this);
            attitudeMgr = new AttitudeMgr(this);

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

                    def.getTargets = (person) =>
                    {
                        return person.estates.Select(x => new CommandTarget() { param = x, key = x.name });
                    };

                    def.Do = (person, targets) =>
                    {
                        foreach (var estate in targets.Select(x => x.param as IEstate))
                        {
                            estate.SetManager(GSession.inst.player);

                            person.attitudeMgr.Add(-20, GSession.inst.player, def.key + estate.name);
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

                    def.Do = (person, targets) =>
                    {
                        foreach (var estate in targets.Select(x => x.param as IEstate))
                        {
                            estate.SetManager(person);

                            person.attitudeMgr.Add(15, GSession.inst.player, def.key + estate.name);
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

        public void SetMaster(IPerson person)
        {
            if (person.sect == null || this.sect != null)
            {
                throw new Exception();
            }

            GSession.inst.relationMgr.Change<Relation_Person_Sect>(this, _sect, person.sect);
            GSession.inst.relationMgr.Change<Relation_Apprentice_Master>(this, _master, person);
        }
    }
}