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

        public ObservableCollection<IPerson> persons { get; }

        public ObservableCollection<IBranch> branches { get; }


        public Sect(string name)
        {
            this.name = name;
            persons = new ObservableCollection<IPerson>();
            branches = new ObservableCollection<IBranch>();
        }

        public void OnRelationAdd(eRelation relationType, IPoint peer)
        {
            throw new System.NotImplementedException();
        }

        public void OnRelationChanged(eRelation relationType, IPoint prev, IPoint curr)
        {
            throw new System.NotImplementedException();
        }

        public void OnRelationRemove(eRelation relationType, IPoint peer)
        {
            throw new System.NotImplementedException();
        }
    }
}