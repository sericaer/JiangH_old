using JiangH.API;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

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

            for(int i=0; i<5; i++)
            {
                _comands.Add(new PersonCommand() { key = $"CMD{i}" });
            }
        }

        public void AddEstate(IEstate estate)
        {
            _estates.Add(estate);
        }
    }
}