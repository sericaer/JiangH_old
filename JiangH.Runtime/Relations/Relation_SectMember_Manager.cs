using JiangH.RelationMgr;

namespace JiangH.Runtime.Relations
{
    public class Relation_SectMember_Manager : AbsRelation<Person, Person>
    {
        public Relation_SectMember_Manager(Person member, Person manager) : base(member, manager)
        {

        }

        public override void OnRelationAdd(Person member, Person manager)
        {
            member._manager = manager;
            manager._subordinates.Add(member);

            member.attitudeMgr.Add(10, manager, this);
            manager.attitudeMgr.Add(1, member, this);
        }

        public override void OnRelationChanged(Person member, Person manager, Person newManager)
        {
            throw new System.NotImplementedException();
        }

        public override void OnRelationRemove(Person member, Person manager)
        {
            throw new System.NotImplementedException();
        }
    }
}