using JiangH.API;
using System.Collections;
using System.Collections.Generic;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;

public class ListViewCommandTargetItem : ListViewItem, IViewData<ICommandTarget>
{
    public Text label;
    public ICommandTarget command;

    public void SetData(ICommandTarget item)
    {
        command = item;
        label.text = item.key;
    }
}
