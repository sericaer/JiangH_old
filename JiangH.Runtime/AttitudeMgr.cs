using JiangH.API;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace JiangH.Runtime
{
    class AttitudeMgr : IAttitudeMgr
    {
        private Dictionary<IPerson, Attitude> dict = new Dictionary<IPerson, Attitude>();
        private Person owner;

        public AttitudeMgr(Person person)
        {
            this.owner = person;
        }

        public void Add(int value, IPerson peer, object label)
        {
            var attitude = GetAttitudeTo(peer) as Attitude;
            if(attitude == null)
            {
                attitude = new Attitude(peer);
                dict.Add(peer, attitude);
            }

            attitude.Add(label, value);
        }

        public IAttitude GetAttitudeTo(IPerson peer)
        {
            Attitude rlst;

            dict.TryGetValue(peer, out rlst);

            return rlst;
        }
    }

    class Attitude : IAttitude
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int total { get; private set; }

        public IPerson peer { get; private set; }

        private List<(object label, int value)> list = new List<(object label, int value)>();

        public Attitude(IPerson peer)
        {
            this.peer = peer;
        }

        public void Add(object label, int value)
        {
            list.Add((label, value));

            total = list.Sum(x => x.value);
        }
    }
}