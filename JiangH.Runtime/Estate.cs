using JiangH.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH.Runtime
{
    public class Estate : IEstate
    {
        public string name { get; set; }

        public IPerson owner
        {
            get
            {
                return _owner;
            }
            set
            {
                if(_owner == value)
                {
                    return;
                }

                var prevOwner = _owner;
                _owner = value;

                GSession.inst.relationMgr.Change(eRelation.EstateOwner, this, prevOwner, _owner);
            }
        }

        public EnergyOccupyLevel level { get; set; }

        private IPerson _owner;

        public Estate(string name)
        {
            this.name = name;
        }

        public void OnDayInc(int year, int month, int day)
        {
            if(day == 30)
            {
                owner.money += (int)level+1 * 100;
            }
        }

        public void OnRelationAdd(eRelation relationType, IPoint peer)
        {
            switch(relationType)
            {
                case eRelation.EstateOwner:
                    _owner = peer as IPerson;
                    break;
                default:
                    break;
            }
        }

        public void OnRelationChanged(eRelation relationType, IPoint prev, IPoint curr)
        {
            switch (relationType)
            {
                case eRelation.EstateOwner:
                    _owner = curr as IPerson;
                    break;
                default:
                    break;
            }
        }

        public void OnRelationRemove(eRelation relationType, IPoint peer)
        {
            switch (relationType)
            {
                case eRelation.EstateOwner:
                    _owner = null;
                    break;
                default:
                    break;
            }
        }
    }
}
