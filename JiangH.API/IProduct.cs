using System;
using System.Collections.Generic;
using System.Text;

namespace JiangH.API
{
    public interface IProduct
    {
        int baseValue { get; }
        int readlValue { get; }

        string name { get; }

        void AddOrUpdateEffect(string key, int value);
    }
}
