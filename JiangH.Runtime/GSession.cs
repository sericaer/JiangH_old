﻿using JiangH.API;
using JiangH.RelationMgr;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace JiangH.Runtime
{
    public partial class GSession : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static GSession inst;

        public IPerson player { get; set; }

        public IDate date { get; set; }

        public readonly ObservableCollection<IPerson> persons;

        public readonly ObservableCollection<IEstate> estates;

        public readonly IRelationManager relationMgr;

        public GSession()
        {
            persons = new ObservableCollection<IPerson>();
            estates = new ObservableCollection<IEstate>();
            relationMgr = new RelationManager();
        }

        public void OnDayInc()
        {
            date.day++;

            player = persons[0];

            foreach(var estate in estates)
            {
                estate.OnDayInc(date.year, date.month, date.day);
            }

            //persons.RemoveAt(0);
            //persons.Add(player);
        }
    }
}
