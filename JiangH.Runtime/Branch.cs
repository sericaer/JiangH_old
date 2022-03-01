using JiangH.API;
using JiangH.Runtime.Relations;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace JiangH.Runtime
{
    internal class Branch : IBranch
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; set; }

        public ISect sect => _sect;

        public IPerson manager => _manager;

        public ReadOnlyObservableCollection<IPerson> persons { get; }

        public ReadOnlyObservableCollection<IEstate> estates { get; }

        internal Sect _sect { get; set; }
        internal IPerson _manager { get; set; }

        internal ObservableCollection<IPerson> _persons = new ObservableCollection<IPerson>();
        internal ObservableCollection<IEstate> _estates = new ObservableCollection<IEstate>();


        public Branch(string name, ISect sect)
        {
            this.name = name;

            persons = new ReadOnlyObservableCollection<IPerson>(_persons);
            estates = new ReadOnlyObservableCollection<IEstate>(_estates);

            this.SetSect(sect);

            _persons.CollectionChanged += (sender, e) =>
            {
                if(e.NewItems != null)
                {
                    foreach (IPerson elem in e.NewItems)
                    {
                        _sect._persons.Add(elem);
                    }
                }

                if(e.OldItems != null)
                {
                    foreach (IPerson elem in e.OldItems)
                    {
                        _sect._persons.Remove(elem);
                    }
                }

            };

            _estates.CollectionChanged += (sender, e) =>
            {
                if (e.NewItems != null)
                {
                    foreach (IEstate elem in e.NewItems)
                    {
                        _sect._estates.Add(elem);
                    }
                }

                if(e.OldItems != null)
                {
                    foreach (IEstate elem in e.OldItems)
                    {
                        _sect._estates.Remove(elem);
                    }
                }

            };

        }


        public void SetMain()
        {
            //throw new NotImplementedException();
        }

        public void SetSect(ISect sect)
        {
            GSession.inst.relationMgr.Change<Relation_Branch_Sect>(this, _sect, sect);
        }

        public void SetManager(IPerson person)
        {
            //throw new NotImplementedException();
        }
    }
}