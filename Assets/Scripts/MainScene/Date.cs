using JiangH.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class Date : RxMonoBehaviour
{
    public Text value;

    void Start()
    {
        dataBind.BindText(GSession.inst, x => x.date.desc, value);
    }
}