using System;
using System.Collections.Generic;
using System.Text;

namespace StockData.Repository
{
    public interface IWarehouseDataProvider
    {
        IEnumerable<string> ProvideRawData();
    }
}
