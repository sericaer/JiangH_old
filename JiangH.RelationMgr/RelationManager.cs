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
    //public class Relation : INotifyPropertyChanged
    //{

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    public eRelation relationType { get; set; }

    //    public IPoint p1
    //    {
    //        get
    //        {
    //            return _p1;
    //        }
    //        set
    //        {
    //            var prev = _p1;

    //            _p1 = value;

    //            p2?.OnRelationChanged(relationType, prev, _p1);

    //            prev?.OnRelationRemove(relationType, p2);
    //            _p1?.OnRelationAdd(relationType, p2);
    //        }
    //    }

    //    public IPoint p2
    //    {
    //        get
    //        {
    //            return _p2;
    //        }
    //        set
    //        {
    //            var prev = _p2;
    //            _p2 = value;

    //            p1?.OnRelationChanged(relationType, prev, _p2);

    //            prev?.OnRelationRemove(relationType, p1);
    //            _p2?.OnRelationAdd(relationType, p1);
    //        }
    //    }

    //    private IPoint _p1;
    //    private IPoint _p2;

    //    public Relation(eRelation relationType, IPoint point1, IPoint point2)
    //    {
    //        this.relationType = relationType;
    //        this._p1 = point1;
    //        this._p2 = point2;

    //        p1.OnRelationAdd(relationType, point2);
    //        p2.OnRelationAdd(relationType, point1);
    //    }

    //}

    public class RelationManager : IRelationManager
    {
        //private List<Relation> all = new List<Relation>();

        private List<IRelation> all2 = new List<IRelation>();

        //private Dictionary<Relation, (IDisposable, IDisposable)> dict = new Dictionary<Relation, (IDisposable, IDisposable)>(); 
        //public void Change(eRelation relationType, IPoint point1, IPoint prevPoint2, IPoint newPoint2)
        //{
        //    if(prevPoint2 == null)
        //    {
        //        Add(relationType, point1, newPoint2);
        //        return;
        //    }

        //    var elem = all.Single(x => x.relationType == relationType && x.p1 == point1 && x.p2 == prevPoint2);
        //    elem.p2 = newPoint2;
        //}

        //public void Add(eRelation relationType, IPoint point1, IPoint point2)
        //{
        //    if(all.Any(x => x.relationType == relationType && x.p1 == point1 && x.p2 == point2))
        //    {
        //        throw new Exception();
        //    }

        //    var relation = new Relation(relationType, point1, point2);
        //    all.Add(relation);
        //}

        //public void Remove(eRelation relationType, IPoint point1, IPoint point2)
        //{
        //    var elem = all.Single(x => x.relationType == relationType && x.p1 == point1 && x.p2 == point2);
        //    all.Remove(elem);
        //}

        public void Change<T>(IPoint point1, IPoint prevPoint2, IPoint newPoint2) where T : IRelation
        {
            if (prevPoint2 == null)
            {
                Add<T>(point1, newPoint2);
                return;
            }

            var elem = all2.Single(x => x.GetType()==typeof(T) && x.p1 == point1 && x.p2 == prevPoint2);
            elem.p2 = newPoint2;
        }

        private void Add<T>(IPoint point1, IPoint point2) where T : IRelation
        {
            all2.Add(Activator.CreateInstance(typeof(T), point1, point2) as IRelation);
        }
    }

    public abstract class AbsRelation<T1, T2> : IRelation
        where T1 : class, IPoint
        where T2 : class, IPoint
    {
        public IPoint p1 => _p1;
        public IPoint p2
        {
            get
            {
                return _p2;
            }
            set
            {
                if(value != null && !(value is T2))
                {
                    throw new Exception();
                }

                if(_p2 == value)
                {
                    return;
                }

                var prevP2 = _p2;
                _p2 = value as T2;

                OnRelationRemove(_p1, prevP2);
                OnRelationChanged(_p1, prevP2, _p2);
            }
        }

        private T1 _p1;
        private T2 _p2;

        public AbsRelation(T1 p1, T2 p2)
        {
            this._p1 = p1;
            this._p2 = p2;

            OnRelationAdd(p1, p2);
        }

        public abstract void OnRelationAdd(T1 p1, T2 p2);
        public abstract void OnRelationRemove(T1 p1, T2 p2);
        public abstract void OnRelationChanged(T1 p1, T2 p2, T2 newP2);
    }
}
