using JiangH.API;
using JiangH.RelationMgr;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH.Runtime.Relations
{
    public class Relation_Estate_Manager : AbsRelation<Estate, Person>
    {
        public Relation_Estate_Manager(Estate p1, Person p2) : base(p1, p2)
        {

        }

        public override void OnRelationAdd(Estate estate, Person manager)
        {
            estate._manager = manager;
            manager._estates.Add(estate);
        }

        public override void OnRelationRemove(Estate estate, Person manager)
        {
            estate._manager = null ;
            manager._estates.Remove(estate);
        }

        public override void OnRelationChanged(Estate estate, Person manager, Person newManager)
        {
            
            manager._estates.Remove(estate);

            estate._manager = newManager;

            newManager._estates.Add(estate);
        }

    }
}
