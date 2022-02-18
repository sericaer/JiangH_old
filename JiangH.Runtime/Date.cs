using JiangH.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JiangH.Runtime
{
    public class Date : IDate
    {
#pragma warning disable 0067 // No "Never used" warning
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067

        public int year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
            }
        }

        public int month
        {
            get
            {
                return _month;
            }
            set
            {
                _month = value;
                if (_month > 12)
                {
                    year += 1;
                    _month = 1;
                }
            }
        }

        public int day
        {
            get
            {
                return _day;
            }
            set
            {
                _day = value;
                if (_day > 30)
                {
                    month += 1;
                    _day = 1;
                }
            }
        }

        public string desc => $"{year}-{month}-{day}";

        private int _year;
        private int _month;
        private int _day;

        public Date()
        {
            year = 1;
            month = 1;
            day = 1;
        }
    }
}
