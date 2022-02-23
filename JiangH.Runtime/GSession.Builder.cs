using System;
using System.Collections;
using System.Linq;

namespace JiangH.Runtime
{
    public partial class GSession
    {
        public class Builder
        {
            public static GSession Build()
            {
                GSession.inst = new GSession();

                GSession.inst.date = new Date();

                for (int i = 0; i < 15; i++)
                {
                    GSession.inst.estates.Add(new Estate((i + 'a').ToString(), new MarketDef()));
                }

                for (int i=0; i<5; i++)
                {
                    var person = new Person(i.ToString());
                    GSession.inst.persons.Add(person);

                    for(int j=i*3; j<i*3+3; j++)
                    {
                        GSession.inst.estates[j].owner = person;
                        //person.AddEstate(gSession.estates[j]);
                    }
                }

                GSession.inst.player = GSession.inst.persons[0];
                return GSession.inst;
            }
        }
    }
}
