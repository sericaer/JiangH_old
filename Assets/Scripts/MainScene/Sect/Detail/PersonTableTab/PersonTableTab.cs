using JiangH.API;
using System.Collections;
using System.Collections.ObjectModel;
using UnityEngine;

class PersonTableTab : RxMonoBehaviourWithData<PersonTableTab, ReadOnlyObservableCollection<IPerson>>
{
    public PersonTable table;

    protected override void BindInit()
    {
        
    }

    // Use this for initialization
    void Start()
    {
        table.SetPersons(assocData);
    }

    // Update is called once per frame
    void Update()
    {

    }
}