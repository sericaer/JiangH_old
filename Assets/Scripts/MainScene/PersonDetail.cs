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

    public PersonCommandsTab commandPanel;

    public ListViewString estates;

    void Awake()
    {
        commandPanel.person = person;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        btn.onClick.AddListener(() =>
        {
            var estate = new Estate(DateTime.Now.Second.ToString());
            person.AddEstate(estate);
        });

    }

    internal void SetPerson(IPerson person)
    {
        this.person = person;

        commandPanel.SetPerson(person);

        Action<IEstate> onAddEstate = (item) =>
        {
            estates.DataSource.Add(item.name);
        };

        Action<IEstate> onRemoveEstate = (item) =>
        {
            //estates.DataSource.Remove(item.name);
        };

        Action<IPersonCommand> onAddCommand = (item) =>
        {
            //commands.Add()
        };

        Action<IPersonCommand> onRemoveCommand = (item) =>
        {
            //estates.DataSource.Remove(item.name);
        };


        dataBind.BindObservableCollection<IEstate>(person.estates, onAddEstate, onRemoveEstate);

        //dataBind.BindObservableCollection<IPersonCommand>(person.commands, onAddCommand, onRemoveCommand);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
