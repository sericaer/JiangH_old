using JiangH.API;
using System;
using System.Collections;
using System.Collections.Generic;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;

public class ListViewCommandTagert : ListViewCustom<ListViewCommandTargetItem, ICommandTarget>
{
    public Action<ICommandTarget, bool> OnSelectStateChanegd;
}
