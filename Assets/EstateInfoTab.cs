using JiangH.API;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

class EstateInfoTab : RxMonoBehaviour
{
    public List<EstateView> estateList = new List<EstateView>();

    private ReadOnlyObservableCollection<IEstate> estates;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void SetEstates(ReadOnlyObservableCollection<IEstate> estates)
    {
        if(this.estates == estates)
        {
            return;
        }

        estateList.Clear();

        this.estates = estates;

        dataBind.BindObservableCollection(estates, onAddEstate, onRemoveEstate, null);
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
