using JiangH.API;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;

class ListViewEnergyOccupyItem : ListViewItem, IViewData<IEnergyOccupy>
{
    public Text label;
    public Text value;

    public Toggle[] toggles;

    private IEnergyOccupy energyOccupy;

    private DataBind dataBind;

    protected override void Start()
    {
        base.Start();

        foreach(var toggle in toggles)
        {
            toggle.onValueChanged.RemoveAllListeners();

            toggle.onValueChanged.AddListener((isOn) =>
            {
                var level = (EnergyOccupyLevel)Enum.Parse(typeof(EnergyOccupyLevel), toggle.name);
                if(energyOccupy.occupyLevel != level)
                {
                    energyOccupy.occupyLevel = level;
                }
            });
        }

        dataBind = new DataBind();

        dataBind.BindText(energyOccupy, x=>x.name, label);
        dataBind.BindText(energyOccupy, x=>x.value, value);

        dataBind.BindAction(energyOccupy, x => x.occupyLevel, OnLevelChanged);
    }

    protected override void OnDestroy()
    {
        dataBind?.Clear();

        base.OnDestroy();
    }

    public void SetData(IEnergyOccupy item)
    {
        energyOccupy = item;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnLevelChanged(EnergyOccupyLevel level)
    {
        toggles.Single(x => x.name == level.ToString()).isOn = true;
    }
}
