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
                gSession.player = new Person($"{gSession.GetHashCode().ToString("X2")} {DateTime.Now.ToString()}");

                return gSession;
            }
        }
    }
}
