using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockData.Repository;

namespace StockData.Tests
{
    [TestClass]
    public class StockRepositoryDataFactoryTests
    {
        [TestMethod]
        public void DataFactoryShouldReturnFileDataSourceOnEnumEqualFile()
        {
            var provider = StockDataProviderFactory.Create(StockDataSources.File);
            Assert.IsTrue(provider is WarehouseFileDataProvider);

        }

        public void DataFactoryShouldReturnMockDataSourceOnEnumEqualMock()
        {
            var provider = StockDataProviderFactory.Create(StockDataSources.Mock);
            Assert.IsTrue(provider is WarehouseMockDataProvider);

        }
    }
}
