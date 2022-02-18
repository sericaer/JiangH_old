using JiangH.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace JiangH.Runtime
{
    public partial class GSession : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static GSession inst;

        public IPerson player { get; set; }


        public IDate date { get; set; }

        public List<IPerson> persons = new List<IPerson>();

        public void OnDayInc()
        {
            date.day++;

            player = persons[0];

  
            persons.RemoveAt(0);
            persons.Add(player);
        }
    }
}
