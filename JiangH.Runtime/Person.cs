using JiangH.API;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace JiangH.Runtime
{
    internal class Person : IPerson
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; set; }
        public int money { get; set; }
        public ReadOnlyObservableCollection<IEstate> estates { get; private set; }

        private ObservableCollection<IEstate> _estates;

        public Person(string name)
        {
            this.name = name;

            _estates = new ObservableCollection<IEstate>();

            estates = new ReadOnlyObservableCollection<IEstate>(_estates);

        }
    }
}