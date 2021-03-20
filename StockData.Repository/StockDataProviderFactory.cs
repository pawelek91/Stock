using StockData.Data;
using System;

namespace StockData.Repository
{
    public static class StockDataProviderFactory
    {
        public static IWarehouseDataProvider Create(StockDataSources source)
        {
            switch(source)
            {
                case StockDataSources.File: return new WarehouseFileDataProvider();
                case StockDataSources.Mock: return new WarehouseMockDataProvider();
               default: throw new NotImplementedException();
            }
        }
    }
}
