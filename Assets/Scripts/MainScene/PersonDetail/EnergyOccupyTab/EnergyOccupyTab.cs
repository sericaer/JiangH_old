using JiangH.API;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class EnergyOccupyTab : RxMonoBehaviourWithData<EnergyOccupyTab, IEnergyMgr>
{

    public Text totalEstateOccupied;
    public ListViewEnergyOccupy energyOccupyListView;

    protected override void BindInit()
    {
        dataBind.BindText(assocData, x => x.totalEstateOccupied, totalEstateOccupied);
        dataBind.BindObservableCollection(assocData.estateOccupys, OnAddEstateOccupy, OnRemoveEstateOccupy, null);
    }

    private void OnRemoveEstateOccupy(IEnergyOccupy occupy)
    {
        energyOccupyListView.Remove(occupy);
    }

    private void OnAddEstateOccupy(IEnergyOccupy occupy)
    {
       energyOccupyListView.Add(occupy);
    }
}
