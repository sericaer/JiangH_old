﻿using JiangH.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

class Estates : RxMonoBehaviour
{
    public Button button;

    public Text Value;

    // Start is called before the first frame update
    void Start()
    {
        dataBind.BindText(GSession.inst, x => x.player.estates.Count, Value);
    }

    // Update is called once per frame
    void Update()
    {

    }
}