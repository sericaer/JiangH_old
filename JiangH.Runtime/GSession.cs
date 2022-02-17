using JiangH.API;
using System;
using System.ComponentModel;

namespace JiangH.Runtime
{
    public partial class GSession : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static GSession inst;

        public IPerson player { get; set; }

        public void OnDayInc()
        {
            player = new Person($"{this.GetHashCode().ToString("X2")} {DateTime.Now.ToString()}");
        }
    }
}
