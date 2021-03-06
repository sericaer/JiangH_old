using JiangH.API;
using JiangH.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        public class AttitudeView : TooltipCell.IToolTipCellData
        {
            public string celltext => attitude == null ? "--" : attitude.total.ToString();

            public string tooltipText => attitude == null ? null : string.Join("\n", attitude.elements.Select(x=>$"{x.label} {x.value}"));

            private IAttitude attitude;

            public AttitudeView(IAttitude attitude)
            {
                this.attitude = attitude;
            }
        }

        public readonly IPerson person;

        public int estateCount => person.estates.Count;
        public int apprenticeCount => person.apprentices.Count;
        public int money => person.money;

        public AttitudeView attitudeToPlayer1;

        public AttitudeView attitudeFromPlayer1;

        public string attitudeToPlayer
        {
            get
            {
                string rslt = "--";
                var attitude = person.attitudeMgr.GetAttitudeTo(GSession.inst.player);
                if (attitude != null)
                {
                    rslt = attitude.total.ToString();
                }

                return rslt;
            }
        }

        public string attitudeFromPlayer
        {
            get
            {
                string rslt = "--";
                var attitude = GSession.inst.player.attitudeMgr.GetAttitudeTo(person);
                if (attitude != null)
                {
                    rslt = attitude.total.ToString();
                }

                return rslt;
            }
        }

        public string master => person.master == null ? "--" : person.master.name;

        public PersonView(IPerson person)
        {
            this.person = person;

            attitudeToPlayer1 = new AttitudeView(person.attitudeMgr.GetAttitudeTo(GSession.inst.player));
            attitudeFromPlayer1 = new AttitudeView(GSession.inst.player.attitudeMgr.GetAttitudeTo(person));
        }
    }

    internal void SetPersons(ReadOnlyObservableCollection<IPerson> persons)
    {
        dataBind.BindObservableCollection<IPerson>(persons, OnAddPerson, OnRemovePerson, null);
    }
}