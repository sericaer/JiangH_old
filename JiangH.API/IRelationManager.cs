using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH.API
{
    public  enum eRelation
    {
        EstateOwner
    }

    public interface IPoint
    {
        void OnRelationAdd(eRelation relationType, IPoint peer);
        void OnRelationChanged(eRelation relationType, IPoint prev, IPoint curr);
        void OnRelationRemove(eRelation relationType, IPoint peer);
    }

    public interface IRelationManager
    {
        void Change(eRelation relation, IPoint point1, IPoint prevPoint2, IPoint newPoint2);
    }
}
