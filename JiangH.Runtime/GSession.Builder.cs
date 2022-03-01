using JiangH.API;
using System;
using System.Collections;
using System.Collections.Generic;
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

                Queue<IPerson> persons = new Queue<IPerson>(session.persons);
                Queue<IEstate> estates = new Queue<IEstate>(session.estates);

                foreach (var sect in session.sects)
                {
                    foreach(var person in persons.DequeueRange(3))
                    {
                        person.SetSect(sect);

                        if (sect.manager == null)
                        {
                            sect.SetManager(person);
                        }
                    }
                }

                foreach(var person in session.sects.SelectMany(x=>x.persons).ToArray())
                {
                    foreach (var estate in estates.DequeueRange(3))
                    {
                        estate.SetManager(person);
                    }

                    foreach(var apprentice in persons.DequeueRange(3))
                    {
                        apprentice.SetMaster(person);
                    }
                }

                return GSession.inst;
            }
        }
    }

    public static class Extentions
    {
        public static IEnumerable<T> DequeueRange<T>(this Queue<T> self, int count)
        {
            var list = new List<T>();
            for(int i=0; i<Math.Min(count, self.Count); i++)
            {
                list.Add(self.Dequeue());
            }

            return list;
        }
    }
}
