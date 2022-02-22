using JiangH.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH.Runtime
{
    public partial class Person : IPerson
    {
        public void OnRelationAdd(eRelation relationType, IPoint peer)
        {
            switch (relationType)
            {
                case eRelation.EstateOwner:
                    {
                        var estate = peer as IEstate;
                        if (estate == null)
                        {
                            throw new Exception();
                        }

                        _estates.Add(peer as IEstate);
                        energyMgr.AddEstateOccupy(estate);
                    }
                    break;
                default:
                    throw new Exception();
            }
        }

        public void OnRelationChanged(eRelation relationType, IPoint prev, IPoint curr)
        {
            switch (relationType)
            {
                case eRelation.EstateOwner:
                    throw new NotImplementedException();
                default:
                    throw new Exception();
            }
        }

        public void OnRelationRemove(eRelation relationType, IPoint peer)
        {
            switch (relationType)
            {
                case eRelation.EstateOwner:
                    {
                        var estate = peer as IEstate;
                        if (estate == null)
                        {
                            throw new Exception();
                        }

                        _estates.Remove(peer as IEstate);
                        energyMgr.RemoveEstateOccupy(estate);
                    }
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
