using JiangH.API;
using JiangH.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;

class PersonDetail : RxMonoBehaviour
{
    public IPerson person;

    public Button btn;

    public ListViewString estates;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(() =>
        {
            var estate = new Estate(DateTime.Now.Second.ToString());
            person.AddEstate(estate);
        });

        Action<IEstate> onAddEstate = (item) =>
        {
            estates.DataSource.Add(item.name);
        };

        Action<IEstate> onRemoveEstate = (item) =>
        {
            estates.DataSource.Remove(item.name);
        };

        dataBind.BindObservableCollection<IEstate>(person.estates, onAddEstate, onRemoveEstate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
