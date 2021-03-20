using StockData.Contract;
using StockData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockData.Repository
{
    public class StockRepository
    {
        string[] _data;
        public StockRepository(StockDataSources source)
        {
            _data = StockDataProviderFactory.Create(source).ProvideRawData().ToArray();
        }

        private Dictionary<string, ProductQuantity[]> GetProductsQuantityByWarehouses()
        {
            if (_data == null || _data.Length < 1)
                throw new ApplicationException("Data is empty");

            var warehousesWithProducts = new Dictionary<string, List<ProductQuantity>>();

            WarehouseProductsHandler.FillProductsInfoInWarehouse(warehousesWithProducts, _data);

            var result = new Dictionary<string, ProductQuantity[]>();
            foreach(var value in warehousesWithProducts)
            {
                result.Add(value.Key, value.Value.ToArray());
            }
            return result;
        }

        public WarehouseStockDto[] GetWarehouseStock()
        {
            var data = GetProductsQuantityByWarehouses();
            var result = new List<WarehouseStockDto>(data.Count());
            foreach(var warehouse in data)
            {
                result.Add(new WarehouseStockDto
                {
                    WarehouseId = warehouse.Key,
                    SumOfProducts = WarehouseProductsHandler.GetAllProductsQuantity(warehouse.Value),
                    ProductQuantity = warehouse.Value.Select(x => Mapper.Map(x)),
                });
            }

            return result.ToArray();


        }






    }
}
