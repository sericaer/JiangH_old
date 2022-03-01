namespace JiangH.API
{
    public interface IAttitudeMgr
    {
        void Add(int value, IPerson peer, object key);
        IAttitude GetAttitudeTo(IPerson peer);
    }
}
