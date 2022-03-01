using JiangH.RelationMgr;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH.Runtime.Relations
{
    class Relation_Apprentice_Master : AbsRelation<Person, Person>
    {
        public Relation_Apprentice_Master(Person apprentice, Person master) : base(apprentice, master)
        {

        }

        public override void OnRelationAdd(Person apprentice, Person master)
        {
            apprentice._master = master;
            master._apprentices.Add(apprentice);
        }

        public override void OnRelationChanged(Person apprentice, Person master, Person newMaster)
        {
            throw new NotImplementedException();
        }

        public override void OnRelationRemove(Person apprentice, Person master)
        {
            throw new NotImplementedException();
        }
    }
}
