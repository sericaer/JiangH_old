using JiangH.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH.Runtime
{
    public class Estate : IEstate
    {
        public string name { get; set; }

        public IPerson owner { get; }

        public Estate(string name)
        {
            this.name = name;
        }
    }
}
