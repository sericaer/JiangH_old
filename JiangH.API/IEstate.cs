namespace JiangH.API
{
    public interface IEstate
    {
        string name { get; set; }

        IPerson owner { get; }
    }
}