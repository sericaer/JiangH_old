using System;

namespace JiangH.Runtime
{
    public partial class GSession
    {
        public class Builder
        {
            public static GSession Build()
            {
                GSession gSession = new GSession();

                for(int i=0; i<5; i++)
                {
                    gSession.persons.Add(new Person(i.ToString()));
                }

                gSession.player = gSession.persons[0];
                gSession.date = new Date();

                return gSession;
            }
        }
    }
}
