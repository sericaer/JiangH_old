using JiangH.API;
using JiangH.RelationMgr;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH.Runtime.Relations
{
    public class Relation_Estate_Person : AbsRelation<Estate, Person>
    {
        public Relation_Estate_Person(Estate p1, Person p2) : base(p1, p2)
        {

        }

        public override void OnRelationAdd(Estate estate, Person manager)
        {
            estate._manager = manager;
            manager._estates.Add(estate);

            var branch = manager.branch as Branch;
            if(branch == null)
            {
                return;
            }

            branch._estates.Add(estate);
            var sect = branch.sect as Sect;
            if(sect == null)
            {
                return;
            }

            sect._estates.Add(estate);
        }

        public override void OnRelationRemove(Estate estate, Person manager)
        {
            estate._manager = null ;
            manager._estates.Remove(estate);

            var branch = manager.branch as Branch;
            if (branch == null)
            {
                throw new Exception();
            }

            branch._estates.Remove(estate);
            var sect = branch.sect as Sect;
            if (sect == null)
            {
                throw new Exception();
            }

            sect._estates.Remove(estate);
        }

        public override void OnRelationChanged(Estate estate, Person manager, Person newManager)
        {
            
            manager._estates.Remove(estate);

            estate._manager = newManager;

            newManager._estates.Add(estate);

            var branch = newManager.branch as Branch;
            if (branch == null)
            {
                throw new Exception();
            }

            branch._estates.Add(estate);
            var sect = branch.sect as Sect;
            if (sect == null)
            {
                throw new Exception();
            }

            sect._estates.Add(estate);
        }

    }
}
