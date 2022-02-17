using JiangH.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH.Runtime
{
    class Estate : IEstate
    {
        public string name { get; set; }

        public IPerson owner { get; }
    }
}
