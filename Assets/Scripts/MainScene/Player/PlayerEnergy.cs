using JiangH.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;

class PlayerEnergy : RxMonoBehaviour
{
    public Text spend;
    public Text total;

    public Button button;

    public GameObject prefabs;

    // Start is called before the first frame update
    void Start()
    {
        dataBind.BindText(GSession.inst, x => x.player.energyMgr.totalEstateOccupied, spend);
        dataBind.BindText(GSession.inst, x => x.player.energyMgr.energyValue, total);

        button.onClick.AddListener(ShowPersnDetailEnergy);
    }

    private void ShowPersnDetailEnergy()
    {
        var instance = (GameObject)Instantiate(prefabs, Global.dialogRoot);

        var personDetail = instance.GetComponent<PersonDetail>();
        personDetail.assocData = GSession.inst.player;

        personDetail.GetComponentInChildren<Tabs>().SetDefaultSelectedTab("¾«Á¦·ÖÅä");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
