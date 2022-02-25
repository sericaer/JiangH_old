using JiangH.API;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace JiangH.Runtime
{
    internal class Sect : ISect
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; set; }

        public IBranch mainBranch { get; set; }

        public ReadOnlyObservableCollection<IPerson> persons { get; }

        public ReadOnlyObservableCollection<IBranch> branches { get; }

        public ReadOnlyObservableCollection<IEstate> estates { get; }

        internal ObservableCollection<IPerson> _persons = new ObservableCollection<IPerson>();
        internal ObservableCollection<IBranch> _branches = new ObservableCollection<IBranch>();
        internal ObservableCollection<IEstate> _estates = new ObservableCollection<IEstate>();

        public Sect(string name)
        {
            this.name = name;

            persons = new ReadOnlyObservableCollection<IPerson>(_persons);
            branches = new ReadOnlyObservableCollection<IBranch>(_branches);
            estates = new ReadOnlyObservableCollection<IEstate>(_estates);
        }
    }
}