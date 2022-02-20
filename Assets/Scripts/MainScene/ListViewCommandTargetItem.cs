using JiangH.API;
using System.Collections;
using System.Collections.Generic;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;

public class ListViewCommandTargetItem : ListViewItem, IViewData<ICommandTarget>
{
    public Text label;
    public Toggle toggle;

    public ICommandTarget target;

    public void SetData(ICommandTarget item)
    {
        target = item;
        label.text = item.key;

        toggle.onValueChanged.RemoveAllListeners();

        toggle.onValueChanged.AddListener((isOn) =>
        {
            var list = Owner as ListViewCommandTagert;
            list.OnSelectStateChanegd?.Invoke(target, isOn);
        });
    }
}
