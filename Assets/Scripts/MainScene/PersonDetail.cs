using JiangH.API;
using JiangH.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;

class PersonDetail : RxMonoBehaviourWithData<PersonDetail, IPerson>
{
    public Button btn;

    public PersonCommandsTab commandsTab;

    public EnergyOccupyTab enerygOccupyTab;

    public EstateInfoTab estateInfoTab;

    public ListViewString estates;


    protected override void BindInit()
    {
        btn.onClick.AddListener(() =>
        {
            var estate = new Estate(DateTime.Now.Second.ToString(), new MarketDef());
            estate.SetManager(assocData);
        });

        commandsTab.assocData = assocData.GetCommands();
        enerygOccupyTab.assocData = assocData.energyMgr;
        estateInfoTab.assocData = assocData.estates;

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


        dataBind.BindObservableCollection<IEstate>(assocData.estates, onAddEstate, onRemoveEstate, null);
    }
}
