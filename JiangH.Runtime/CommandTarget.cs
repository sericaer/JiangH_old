using JiangH.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH.Runtime
{
    class CommandTarget : ICommandTarget
    {
        public string key { get; set ; }

        public object param { get; set; }
    }
}
