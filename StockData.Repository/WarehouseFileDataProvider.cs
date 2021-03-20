using StockData.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockData.Repository
{
    public class WarehouseFileDataProvider : IWarehouseDataProvider
    {
        public IEnumerable<string> ProvideRawData()
        {
            throw new NotImplementedException();
        }
    }
}
