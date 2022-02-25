using JiangH.API;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

class EstateInfoTab : RxMonoBehaviourWithData<EstateInfoTab, ReadOnlyObservableCollection<IEstate>>
{
    public List<EstateView> estateList = new List<EstateView>();

    protected override void BindInit()
    {
        estateList.Clear();

        dataBind.BindObservableCollection(assocData, onAddEstate, onRemoveEstate, null);
    }

    private void onRemoveEstate(IEstate obj)
    {
        estateList.RemoveAll(x=>x.obj == obj);
    }

    private void onAddEstate(IEstate obj)
    {
        estateList.Add(new EstateView(obj));
    }


    public class EstateView
    {
        public string name => obj.name;
        public string energyLevel => obj.level.ToString();

        public IEstate obj;

        public EstateView(IEstate obj)
        {
            this.obj = obj;
        }
    }
}
