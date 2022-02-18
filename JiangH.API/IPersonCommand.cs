using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JiangH.API
{
    public interface IPersonCommand : INotifyPropertyChanged
    {
        string key { get; set; }
    }
}
