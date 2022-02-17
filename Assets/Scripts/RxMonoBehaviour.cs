using ReactiveMarbles.PropertyChanged;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reactive.Disposables;
using UnityEngine;
using UnityEngine.UI;

class RxMonoBehaviour : MonoBehaviour
{
    protected DataBind dataBind = new DataBind();

    void OnDestroy()
    {
        dataBind.Clear();
    }
}

class DataBind
{
    private CompositeDisposable comDisposable = new CompositeDisposable();

    public void Clear()
    {
        foreach(var dispose in comDisposable)
        {
            Debug.Log($"Dispose {dispose.GetHashCode().ToString("X2")}");
        }

        comDisposable.Dispose();
    }

    public void BindText<TFrom, TProperty>(TFrom fromObject, Expression<Func<TFrom, TProperty>> fromProperty, Text text)
        where TFrom : class, INotifyPropertyChanged
    {
        var hostObs = fromObject.WhenChanged(fromProperty);
        var dispose = hostObs.Subscribe(x => text.text = x.ToString());
        comDisposable.Add(dispose);

        Debug.Log($"BindText {dispose.GetHashCode().ToString("X2")} {fromProperty.ToString()}");
    }
}
