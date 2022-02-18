using JiangH.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JiangH.Runtime
{
    public class PersonCommand : IPersonCommand
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string key { get; set ; }


    }
}
