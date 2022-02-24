using JiangH.API;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace JiangH.Runtime
{
    internal class Branch : IBranch
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; set; }

        public ISect sect { get; set; }

        public IPerson owner { get; set; }

        public ReadOnlyObservableCollection<IPerson> persons { get; }

        public ObservableCollection<IPerson> _persons = new ObservableCollection<IPerson>();
        public Branch(string name, ISect sect)
        {
            this.name = name;
            this.sect = sect;

            persons = new ReadOnlyObservableCollection<IPerson>(_persons);
        }

        public void OnRelationAdd(eRelation relationType, IPoint peer)
        {
            throw new System.NotImplementedException();
        }

        public void OnRelationChanged(eRelation relationType, IPoint prev, IPoint curr)
        {
            throw new System.NotImplementedException();
        }

        public void SetMain()
        {
            throw new NotImplementedException();
        }

        public void OnRelationRemove(eRelation relationType, IPoint peer)
        {
            throw new System.NotImplementedException();
        }
    }
}