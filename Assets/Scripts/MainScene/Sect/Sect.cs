﻿using JiangH.Runtime;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

class Sect : RxMonoBehaviour
{
    public Text sectName;
    public Button button;

    public GameObject prefabs;

    // Use this for initialization
    void Start()
    {
        dataBind.BindText(GSession.inst, x => x.player.branch.sect.name, sectName);

        button.onClick.AddListener(() =>
        {
            var instance = (GameObject)Instantiate(prefabs, Global.dialogRoot);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}