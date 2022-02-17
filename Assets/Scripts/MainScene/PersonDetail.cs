using JiangH.API;
using JiangH.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonDetail : MonoBehaviour
{
    public IPerson person;

    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(() =>
        {
            var estate = new Estate(DateTime.Now.Second.ToString());
            person.AddEstate(estate);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
