using JiangH.RelationMgr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiangH.Runtime.Relations
{
    class Relation_Person_Sect : AbsRelation<Person, Sect>
    {
        public Relation_Person_Sect(Person person, Sect sect) : base(person, sect)
        {

        }

        public override void OnRelationAdd(Person person, Sect sect)
        {
            person._sect = sect;

            sect._persons.Add(person);
        }

        public override void OnRelationChanged(Person branch, Sect sect, Sect newSect)
        {
            throw new Exception();
        }

        public override void OnRelationRemove(Person branch, Sect sect)
        {
            throw new Exception();
        }
    }
}
