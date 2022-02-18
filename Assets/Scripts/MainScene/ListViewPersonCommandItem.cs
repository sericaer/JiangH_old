using JiangH.API;
using System.Collections;
using System.Collections.Generic;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;

public class ListViewPersonCommandItem : ListViewItem, IViewData<IPersonCommand>
{
    public Text label;
    public IPersonCommand command;

    public void SetData(IPersonCommand item)
    {
        command = item;
        label.text = item.key;
    }
}
