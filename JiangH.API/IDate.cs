using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JiangH.API
{
    public interface IDate : INotifyPropertyChanged
    {
        int year { get; set; }
        int month { get; set; }
        int day { get; set; }

        string desc { get; }
    }
}
