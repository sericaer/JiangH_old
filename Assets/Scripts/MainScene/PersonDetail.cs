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

    public PersonCommandsTab commandsTab;

    public EnergyOccupyTab enerygOccupyTab;

    public EstateInfoTab estateInfoTab;

    public ListViewString estates;


    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(() =>
        {
            var estate = new Estate(DateTime.Now.Second.ToString(), new MarketDef());
            estate.SetManager(person);
        });
    }

    internal void SetPerson(IPerson person)
    {
        this.person = person;

        commandsTab.SetCommands(person.GetCommands());

        enerygOccupyTab.SetEnergyMgr(person.energyMgr);
        estateInfoTab.SetEstates(person.estates);

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


        dataBind.BindObservableCollection<IEstate>(person.estates, onAddEstate, onRemoveEstate, null);

        //dataBind.BindObservableCollection<IPersonCommand>(person.commands, onAddCommand, onRemoveCommand);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
