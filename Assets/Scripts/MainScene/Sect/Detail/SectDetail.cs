using JiangH.API;
using System.Collections;
using UnityEngine;

class SectDetail : RxMonoBehaviour
{
    public PersonTableTab personTableTab;

    public ISect sect;

    // Use this for initialization
    void Start()
    {
        personTableTab.assocData = sect.persons;
    }

    // Update is called once per frame
    void Update()
    {

    }
}