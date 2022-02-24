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
                var session = new GSession();
                GSession.inst = session;

                session.date = new Date();

                for (int i = 0; i < 5; i++)
                {
                    var sect = new Sect($"Sect{i}");
                    session.sects.Add(sect);

                    for (var j = 0; j < 2; j++)
                    {
                        var branch = new Branch($"{sect.name}.Branch{j}", sect);

                        if (j == 0)
                        {
                            branch.SetMain();
                        }
                    }
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
                    var branch = sect.branches[i % sect.branches.Count()];
                    session.persons[i].branch = branch;

                    if(branch.owner == null)
                    {
                        branch.owner = session.persons[i];
                    }
                }

                for (int i = 0; i < session.estates.Count() / 2; i++)
                {
                    session.estates[i].owner = session.persons[i % session.persons.Count() / 2];
                }

                session.player = GSession.inst.persons[0];
                return session;
            }
        }
    }
}
