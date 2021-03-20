using StockData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockData.Repository
{
    public static class WarehouseProductsHandler
    {
        public static void AddToWarehouse(ProductQuantity product, List<ProductQuantity> warehouseValues)
        {
            var productInfo = warehouseValues.SingleOrDefault(x => x.ProductId == product.ProductId);
            if (productInfo != null)
                productInfo.Quantity += product.Quantity;
            else
            {
                warehouseValues.Add(new ProductQuantity
                {
                    ProductId = product.ProductId,
                    Quantity = product.Quantity,
                });
            }
        }

        public static int GetAllProductsQuantity(IEnumerable<ProductQuantity> stock)
            => stock.Sum(x => x.Quantity);

        public static void FillProductsInfoInWarehouse(Dictionary<string, List<ProductQuantity>> warehousesWithProducts, IEnumerable<string> lines)
        {
            foreach (var line in lines)
                FillProductsInfoInWarehouse(warehousesWithProducts, line);
        }
        public static void FillProductsInfoInWarehouse(Dictionary<string, List<ProductQuantity>>warehousesWithProducts, string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return;


            var records = line.Split(';');
            if (records == null || records.Length < 3)
                return;

            var product = new Product { ProductId = records[1], ProductName = records[0] };
            var warehouses = records.Skip(2).FirstOrDefault()?.Split('|');


            foreach (var warehouseData in warehouses)
            {
                var warehouseRecords = warehouseData.Split(',');
                var warehouseId = warehouseRecords[0];
                var quantityStr = warehouseRecords[1];
                if (!int.TryParse(quantityStr, out var quantity))
                    continue;

                if (!warehousesWithProducts.ContainsKey(warehouseId))
                {
                    var productsQuantities = new List<ProductQuantity>();
                    var productQuantity = new ProductQuantity
                    {
                        ProductId = product.ProductId,
                        Quantity = quantity,
                    };

                    AddToWarehouse(productQuantity, productsQuantities);
                    warehousesWithProducts.Add(warehouseId, productsQuantities);
                }
                else
                {
                    var warehouse = warehousesWithProducts[warehouseId];

                    AddToWarehouse(new ProductQuantity
                    {
                        ProductId = product.ProductId,
                        Quantity = quantity,
                    }, warehouse);
                }
            }

        }
    }
}
