using JiangH.API;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class EnergyOccupyTab : RxMonoBehaviour
{

    public Text totalEstateOccupied;
    public ListViewEnergyOccupy energyOccupyListView;

    private IEnergyMgr energyMgr;

    internal void SetEnergyMgr(IEnergyMgr energyMgr)
    {
        this.energyMgr = energyMgr;

        dataBind.BindText(energyMgr, x => x.totalEstateOccupied, totalEstateOccupied);
        dataBind.BindObservableCollection(energyMgr.estateOccupys, OnAddEstateOccupy, OnRemoveEstateOccupy, null);
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
