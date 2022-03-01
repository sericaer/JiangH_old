using JiangH.RelationMgr;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH.Runtime.Relations
{
    class Relation_Person_Person : AbsRelation<Person, Person>
    {
        public Relation_Person_Person(Person p1, Person p2) : base(p1, p2)
        {

        }

        public override void OnRelationAdd(Person p1, Person p2)
        {
            p1._master = p2;
            p2._apprentices.Add(p1);
        }

        public override void OnRelationChanged(Person p1, Person p2, Person newP2)
        {
            throw new NotImplementedException();
        }

        public override void OnRelationRemove(Person p1, Person p2)
        {
            throw new NotImplementedException();
        }
    }
}
