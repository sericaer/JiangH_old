using System.Collections.Generic;

namespace JiangH.API
{
    public interface IAttitudeMgr
    {
        IEnumerable<IAttitude> all { get; }

        void Add(int value, IPerson peer, object key);
        IAttitude GetAttitudeTo(IPerson peer);
    }
}
