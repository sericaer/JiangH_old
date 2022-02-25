using JiangH.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;

class BranchPersons : RxMonoBehaviour
{
    public Text students;
    public Text total;

    public Button button;

    public GameObject prefabs;

    // Start is called before the first frame update
    void Start()
    {
        //dataBind.BindText(GSession.inst, x => x.player.energyMgr.totalEstateOccupied, spend);
        dataBind.BindText(GSession.inst, x => x.player.branch.persons.Count, total);

        button.onClick.AddListener(ShowPersnTable);
    }

    private void ShowPersnTable()
    {
        var instance = (GameObject)Instantiate(prefabs, Global.dialogRoot);

        var personTable = instance.GetComponent<PersonTableDialog>();
        personTable.SetPersons(GSession.inst.player.branch.persons);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
