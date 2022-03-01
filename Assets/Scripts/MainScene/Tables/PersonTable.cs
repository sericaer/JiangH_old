using JiangH.API;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

class PersonTable : RxMonoBehaviour
{

    public List<PersonView> persons = new List<PersonView>();

    // Start is called before the first frame update

    private void OnRemovePerson(IPerson person)
    {
        persons.RemoveAll(x => x.person == person);
    }

    private void OnAddPerson(IPerson person)
    {
        persons.Add(new PersonView(person));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public class PersonView
    {
        public string name => person.name;
        public int estateCount => person.estates.Count;
        public int money => person.money;

        public readonly IPerson person;

        public PersonView(IPerson person)
        {
            this.person = person;
        }
    }

    internal void SetPersons(ReadOnlyObservableCollection<IPerson> persons)
    {
        dataBind.BindObservableCollection<IPerson>(persons, OnAddPerson, OnRemovePerson, null);
    }
}