using JiangH.API;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace JiangH.Runtime
{
    public class Person : IPerson
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; set; }
        public int money { get; set; }
        public ReadOnlyObservableCollection<IEstate> estates { get; private set; }

        public ReadOnlyObservableCollection<IPersonCommand> commands { get; private set; }

        private ObservableCollection<IEstate> _estates;
        private ObservableCollection<IPersonCommand> _comands;

        public Person(string name)
        {
            this.name = name;

            _estates = new ObservableCollection<IEstate>();
            estates = new ReadOnlyObservableCollection<IEstate>(_estates);

            _comands = new ObservableCollection<IPersonCommand>();
            commands = new ReadOnlyObservableCollection<IPersonCommand>(_comands);


            for (int i=0; i<5; i++)
            {
                var def = new PersonCommandDef();
                def.key = $"Command{i}";

                def.Do = (owner, targets) =>
                {

                };

                if (i==0)
                {
                    def.getTargets = (owner) =>
                    {
                        var person = owner as IPerson;
                        return person.estates.Select(x => new CommandTarget() { param = x, key = x.name });
                    };

                    def.Do = (owner, targets) =>
                    {
                        var person = owner as IPerson;

                        foreach(var estates in targets.Select(x=>x.param as IEstate))
                        person.RemoveEstate(estates);
                    };
                }

                _comands.Add(new PersonCommand(this, def));
            }
        }

        public void AddEstate(IEstate estate)
        {
            _estates.Add(estate);
        }

        public void RemoveEstate(IEstate estate)
        {
            _estates.Remove(estate);
        }
    }
}