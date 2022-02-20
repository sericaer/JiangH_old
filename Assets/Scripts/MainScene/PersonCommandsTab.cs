using JiangH.API;
using JiangH.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UIWidgets;
using UnityEngine;

class PersonCommandsTab : RxMonoBehaviour
{
    public IPerson person;

    public ListViewPersonCommand commands;

    public Transform commandDetailBackground;
    public GameObject prefabCommandDetail;

    internal void SetPerson(IPerson person)
    {
        this.person = person;

        commands.OnSelectCommand = OnSelectCommand;

        dataBind.BindObservableCollection<IPersonCommand>(person.commands, OnAddCommand, OnRemoveCommand);
    }

    private void OnAddCommand(IPersonCommand command)
    {
        commands.DataSource.Add(command);
    }

    private void OnRemoveCommand(IPersonCommand command)
    {
        commands.DataSource.Remove(command);

        var detail = commandDetailBackground.GetComponentInChildren<PersonCommandDetailPanel>();
        if (detail != null && detail.command != command)
        {
            Destroy(detail);
        }
    }

    private void OnSelectCommand(IPersonCommand command)
    {
        foreach (Transform child in commandDetailBackground.transform)
        {
            Destroy(child.gameObject);
        }

        var instance = (GameObject)Instantiate(prefabCommandDetail, commandDetailBackground);
        var detailPanel = instance.GetComponent<PersonCommandDetailPanel>();
        detailPanel.command = command;
        
        detailPanel.onPanelExit = (doFlag, cmd, targets) =>
        {
            var items = commands.GetComponentsInChildren<ListViewPersonCommandItem>();
            var selected = items.Single(x => x.command == cmd);
            selected.toggle.isOn = false;

            if(doFlag)
            {
                cmd.Do(targets);
            }
        };
    }
}
