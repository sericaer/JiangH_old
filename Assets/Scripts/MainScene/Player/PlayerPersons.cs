using JiangH.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;

class PlayerPersons : RxMonoBehaviour
{
    public Text students;
    public Text total;

    public Button button;

    public GameObject prefabs;

    // Start is called before the first frame update
    void Start()
    {
        dataBind.BindText(GSession.inst, x => x.player.apprentices.Count, students);
        dataBind.BindText(GSession.inst, x => x.player.sect.persons.Count, total);

        button.onClick.AddListener(ShowPersnTable);
    }

    private void ShowPersnTable()
    {
        var instance = (GameObject)Instantiate(prefabs, Global.dialogRoot);

        var personTable = instance.GetComponent<PersonTableDialog>();
        personTable.SetPersons(GSession.inst.player.sect.persons);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
