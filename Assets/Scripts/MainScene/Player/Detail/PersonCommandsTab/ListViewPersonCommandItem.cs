using JiangH.API;
using System;
using System.Collections;
using System.Collections.Generic;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;

public class ListViewPersonCommandItem : ListViewItem, IViewData<IPersonCommand>
{
    public Text label;
    public Toggle toggle;

    public IPersonCommand command;

    public void SetData(IPersonCommand item)
    {
        command = item;

        label.text = item.key;

        toggle.onValueChanged.RemoveAllListeners();
        toggle.onValueChanged.AddListener((isOn) =>
        {
            if(isOn)
            {
                var listView = Owner as ListViewPersonCommand;
                listView.OnSelectCommand?.Invoke(command);
            }

        });
    }

    void Update()
    {
        this.gameObject.SetActive(command.isValid());
    }
}
