using JiangH.API;
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
        public int money { get; set; }
        public ReadOnlyObservableCollection<IEstate> estates { get; private set; }

        public IEnergyMgr energyMgr { get; private set; }

        private ObservableCollection<IEstate> _estates;

        public Person(string name)
        {
            this.name = name;

            _estates = new ObservableCollection<IEstate>();
            estates = new ReadOnlyObservableCollection<IEstate>(_estates);

            energyMgr = new EnergyMgr();
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
                            estate.owner = GSession.inst.player;
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
                            estate.owner = person;
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
    }
}