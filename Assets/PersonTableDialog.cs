using JiangH.API;
using JiangH.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

class PersonTableDialog : RxMonoBehaviour
{
    public List<IPerson> persons = new List<IPerson>();

    // Start is called before the first frame update
    void Start()
    {
        dataBind.BindObservableCollection<IPerson>(GSession.inst.persons, OnAddPerson, OnRemovePerson);
    }

    private void OnRemovePerson(IPerson person)
    {
        persons.Remove(person);
    }

    private void OnAddPerson(IPerson person)
    {
        persons.Add(person);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
