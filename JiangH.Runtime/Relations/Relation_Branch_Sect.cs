using JiangH.RelationMgr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiangH.Runtime.Relations
{
    class Relation_Branch_Sect : AbsRelation<Branch, Sect>
    {
        public Relation_Branch_Sect(Branch branch, Sect sect) : base(branch, sect)
        {

        }

        public override void OnRelationAdd(Branch branch, Sect sect)
        {
            if(branch.estates.Any() || branch.persons.Any())
            {
                throw new Exception();
            }

            branch._sect = sect;

            sect._branches.Add(branch);
        }

        public override void OnRelationChanged(Branch branch, Sect sect, Sect newSect)
        {
            throw new Exception();
        }

        public override void OnRelationRemove(Branch branch, Sect sect)
        {
            throw new Exception();
        }
    }
}
