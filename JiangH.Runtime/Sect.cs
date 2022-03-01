using JiangH.API;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace JiangH.Runtime
{
    public class Sect : ISect
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; set; }

        public IPerson manager => _manager;

        public ReadOnlyObservableCollection<IPerson> persons { get; }

        public ReadOnlyObservableCollection<IEstate> estates { get; }

        internal ObservableCollection<IPerson> _persons = new ObservableCollection<IPerson>();
        internal ObservableCollection<IEstate> _estates = new ObservableCollection<IEstate>();

        private IPerson _manager { get; set; }

        public Sect(string name)
        {
            this.name = name;

            persons = new ReadOnlyObservableCollection<IPerson>(_persons);
            estates = new ReadOnlyObservableCollection<IEstate>(_estates);
        }

        public void SetManager(IPerson person)
        {
            _manager = person;
        }
    }
}