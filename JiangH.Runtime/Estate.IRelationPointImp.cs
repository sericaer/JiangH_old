using JiangH.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH.Runtime
{
    public partial class Estate : IEstate
    {
        public void OnRelationAdd(eRelation relationType, IPoint peer)
        {
            switch (relationType)
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
