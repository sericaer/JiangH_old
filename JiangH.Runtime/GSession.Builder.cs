﻿using System;
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
                var session = new GSession();
                GSession.inst = session;

                session.date = new Date();

                for (int i = 0; i < 5; i++)
                {
                    var sect = new Sect($"Sect{i}");
                    session.sects.Add(sect);
                }

                for (int i = 0; i < 100; i++)
                {
                    session.estates.Add(new Estate($"EState{i}", new MarketDef()));
                }

                for (int i = 0; i < 100; i++)
                {
                    session.persons.Add(new Person($"Person{i}"));
                }

                for(int i=0; i< session.persons.Count() / 2; i++)
                {
                    var sect = session.sects[i % session.sects.Count()];
                    session.persons[i].SetSect(sect);

                    if(sect.manager == null)
                    {
                        sect.SetManager(session.persons[i]);
                    }
                }

                for (int i = 0; i < session.estates.Count() / 2; i++)
                {
                    var person = session.persons[i % session.persons.Count() / 2];
                    session.estates[i].SetManager(person);
                }

                session.player = GSession.inst.persons[0];
                return session;
            }
        }
    }
}
