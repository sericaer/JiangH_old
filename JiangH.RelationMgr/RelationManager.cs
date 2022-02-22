using JiangH.API;
using ReactiveMarbles.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace JiangH.RelationMgr
{
    public class Relation : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public eRelation relationType { get; set; }

        public IPoint p1
        {
            get
            {
                return _p1;
            }
            set
            {
                var prev = _p1;

                _p1 = value;

                p2?.OnRelationChanged(relationType, prev, _p1);

                prev?.OnRelationRemove(relationType, p2);
                _p1?.OnRelationAdd(relationType, p2);
            }
        }

        public IPoint p2
        {
            get
            {
                return _p2;
            }
            set
            {
                var prev = _p2;
                _p2 = value;

                p1?.OnRelationChanged(relationType, prev, _p2);

                prev?.OnRelationRemove(relationType, p1);
                _p2?.OnRelationAdd(relationType, p1);
            }
        }

        private IPoint _p1;
        private IPoint _p2;

        public Relation(eRelation relationType, IPoint point1, IPoint point2)
        {
            this.relationType = relationType;
            this._p1 = point1;
            this._p2 = point2;

            p1.OnRelationAdd(relationType, point2);
            p2.OnRelationAdd(relationType, point1);
        }

    }

    public class RelationManager : IRelationManager
    {
        private List<Relation> all = new List<Relation>();

        private Dictionary<Relation, (IDisposable, IDisposable)> dict = new Dictionary<Relation, (IDisposable, IDisposable)>(); 
        public void Change(eRelation relationType, IPoint point1, IPoint prevPoint2, IPoint newPoint2)
        {
            if(prevPoint2 == null)
            {
                Add(relationType, point1, newPoint2);
                return;
            }

            var elem = all.Single(x => x.relationType == relationType && x.p1 == point1 && x.p2 == prevPoint2);
            elem.p2 = newPoint2;
        }

        public void Add(eRelation relationType, IPoint point1, IPoint point2)
        {
            var relation = new Relation(relationType, point1, point2);
            all.Add(relation);
        }

        public void Remove(eRelation relationType, IPoint point1, IPoint point2)
        {
            var elem = all.Single(x => x.relationType == relationType && x.p1 == point1 && x.p2 == point2);
            all.Remove(elem);
        }
    }
}
