using JiangH.RelationMgr;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH.Runtime.Relations
{
    class Relation_Person_Branch : AbsRelation<Person, Branch>
    {
        public Relation_Person_Branch(Person person, Branch branch) : base(person, branch)
        {

        }

        public override void OnRelationAdd(Person person, Branch branch)
        {
            person._branch = branch;
            branch._persons.Add(person);
        }

        public override void OnRelationChanged(Person person, Branch branch, Branch newBranch)
        {
            person._branch = newBranch;
            branch._persons.Remove(person);
            newBranch._persons.Add(person);
        }

        public override void OnRelationRemove(Person person, Branch branch)
        {
            person._branch = null;
            branch._persons.Remove(person);
        }
    }
}
