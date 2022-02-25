using ReactiveMarbles.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reactive.Disposables;
using UnityEngine;
using UnityEngine.UI;

abstract class RxMonoBehaviourWithData<T1, T2> : RxMonoBehaviour
{
    public T2 assocData;

    protected abstract void BindInit();

    void Start()
    {
        BindInit();
    }
}

abstract class RxMonoBehaviour : MonoBehaviour
{
    protected DataBind dataBind = new DataBind();

    void OnDestroy()
    {

        Debug.Log($"OnDestroy RxMonoBehaviour {this.GetType()} {this.GetHashCode().ToString("X2")}");

        dataBind.Clear();
    }
}


class DataBind
{
    private CompositeDisposable comDisposable = new CompositeDisposable();

    private Dictionary<INotifyCollectionChanged, List<NotifyCollectionChangedEventHandler>> dictCollectionHandler = new Dictionary<INotifyCollectionChanged, List<NotifyCollectionChangedEventHandler>>();

    public void Clear()
    {
        foreach(var pair in dictCollectionHandler)
        {
            foreach(var handler in pair.Value)
            {
                pair.Key.CollectionChanged -= handler;
            }
        }

        foreach(var dispose in comDisposable)
        {
            Debug.Log($"Dispose {dispose.GetHashCode().ToString("X2")}");
        }

        comDisposable.Dispose();
    }

    public void BindText<TFrom, TProperty>(TFrom fromObject, Expression<Func<TFrom, TProperty>> fromProperty, Text text)
        where TFrom : class, INotifyPropertyChanged
    {
        //var getter = fromProperty.Compile();
        //text.text = getter(fromObject).ToString();

        var hostObs = fromObject.WhenChanged(fromProperty);
        var dispose = hostObs.Subscribe(x => text.text = x.ToString());
        comDisposable.Add(dispose);

        Debug.Log($"BindText {dispose.GetHashCode().ToString("X2")} {fromProperty.ToString()}");
    }

    public void BindAction<TFrom, TProperty>(TFrom fromObject, Expression<Func<TFrom, TProperty>> fromProperty, Action<TProperty> action)
        where TFrom : class, INotifyPropertyChanged
    {
        //var getter = fromProperty.Compile();
        //action(getter(fromObject));

        var hostObs = fromObject.WhenChanged(fromProperty);
        var dispose = hostObs.Subscribe(action);
        comDisposable.Add(dispose);

        Debug.Log($"BindText {dispose.GetHashCode().ToString("X2")} {fromProperty.ToString()}");
    }

    public void BindObservableCollection<TCollectionItem>(ObservableCollection<TCollectionItem> collection, Action<TCollectionItem> onAdd, Action<TCollectionItem> onRemove, Action<TCollectionItem, TCollectionItem> onReplace)
    {
        foreach (var item in collection)
        {
            onAdd(item);
        }

        BindObservableCollection((INotifyCollectionChanged)collection, onAdd, onRemove, onReplace);
    }

    public void BindObservableCollection<TCollectionItem>(ReadOnlyObservableCollection<TCollectionItem> collection, Action<TCollectionItem> onAdd, Action<TCollectionItem> onRemove, Action<TCollectionItem, TCollectionItem> onReplace)
    {
        foreach(var item in collection)
        {
            onAdd(item);
        }

        BindObservableCollection((INotifyCollectionChanged)collection, onAdd, onRemove, onReplace);
    }

    public void BindObservableCollection<TCollectionItem>(INotifyCollectionChanged collection, Action<TCollectionItem> onAdd, Action<TCollectionItem> onRemove, Action<TCollectionItem, TCollectionItem> onReplace)
    {
        NotifyCollectionChangedEventHandler onCollectionChanged = (sender, e) =>
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        foreach (TCollectionItem data in e.NewItems)
                        {
                            onAdd(data);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    {
                        foreach (TCollectionItem data in e.OldItems)
                        {
                            onRemove(data);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    {

                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
        };

        collection.CollectionChanged += onCollectionChanged;

        if(!dictCollectionHandler.ContainsKey(collection))
        {
            dictCollectionHandler.Add(collection, new List<NotifyCollectionChangedEventHandler>());
        }

        dictCollectionHandler[collection].Add(onCollectionChanged);
    }
}
