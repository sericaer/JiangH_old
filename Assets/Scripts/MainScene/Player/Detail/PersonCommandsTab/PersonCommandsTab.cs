using JiangH.API;
using JiangH.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UIWidgets;
using UnityEngine;

class PersonCommandsTab : RxMonoBehaviourWithData<PersonCommandsTab, IEnumerable<IPersonCommand>>
{
    public ListViewPersonCommand commandListView;

    public Transform commandDetailBackground;
    public GameObject prefabCommandDetail;

    protected override void BindInit()
    {
        foreach (var command in assocData)
        {
            commandListView.Add(command);
        }

        commandListView.OnSelectCommand = OnSelectCommand;
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
            var items = commandListView.GetComponentsInChildren<ListViewPersonCommandItem>();
            var selected = items.Single(x => x.command == cmd);
            selected.toggle.isOn = false;

            if(doFlag)
            {
                cmd.Do(targets);
            }
        };
    }
}
