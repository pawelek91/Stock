using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockData.Data;
using StockData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockData.Tests
{
    [TestClass]
    public class WarehouseProductsCountsTests
    {
        [TestMethod]
        public void AddSameProductToMultipleWarehousesShouldIncreaseProductQuantityInSpecificWarehouse()
        {
            var sb = new StringBuilder();
            string productId = "COM-100001";
            int quantity1 = 5;
            int quantity2 = 10;
            string warehouseId1 = "WH-A";
            string warehouseId2 = "WH-B";
            sb.AppendLine($"QPharm 200 MGTABS 64;{productId};{warehouseId1},{quantity1}|{warehouseId2},{quantity1}");
            sb.AppendLine($"QPharm 200 MGTABS 64;{productId};{warehouseId1},{quantity2}");
            var mockData = sb.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var warehouseDict = new Dictionary<string, List<ProductQuantity>>();

            WarehouseProductsHandler.FillProductsInfoInWarehouse(warehouseDict, mockData);

            Assert.IsTrue(warehouseDict.ContainsKey(warehouseId1));

            Assert.IsTrue(warehouseDict[warehouseId1].SingleOrDefault(x => x.ProductId == productId).Quantity == quantity1 + quantity2);
            Assert.IsTrue(warehouseDict[warehouseId2].SingleOrDefault(x => x.ProductId == productId).Quantity == quantity1);
        }

        [TestMethod]
        public void TotalProductsCountInWarehouseShouldReturnSumOfDifferentProductsQuantities()
        {
            var sb = new StringBuilder();
            string productId = "COM-100001";
            int quantity1 = 5;
            int quantity2 = 10;
            string warehouseId1 = "WH-A";
            string warehouseId2 = "WH-B";
            sb.AppendLine($"QPharm 200 MGTABS 64;{productId};{warehouseId1},{quantity1}|{warehouseId2},{quantity1}");
            sb.AppendLine($"QPharm 200 MGTABS 64;{productId};{warehouseId1},{quantity2}");

            var mockData = sb.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var warehouseDict = new Dictionary<string, List<ProductQuantity>>();

            WarehouseProductsHandler.FillProductsInfoInWarehouse(warehouseDict, mockData);
            Assert.IsTrue(WarehouseProductsHandler.GetAllProductsQuantity(warehouseDict[warehouseId1]) == quantity1 + quantity2);
            Assert.IsTrue(WarehouseProductsHandler.GetAllProductsQuantity(warehouseDict[warehouseId2]) == quantity1 );





        }

    }
}
