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
                GSession gSession = new GSession();

                gSession.date = new Date();

                for (int i = 0; i < 15; i++)
                {
                    gSession.estates.Add(new Estate((i + 'a').ToString()));
                }

                for (int i=0; i<5; i++)
                {
                    var person = new Person(i.ToString());
                    gSession.persons.Add(person);

                    for(int j=i*3; j<i*3+3; j++)
                    {
                        person.AddEstate(gSession.estates[j]);
                    }
                }

                gSession.player = gSession.persons[0];
                return gSession;
            }
        }
    }
}
