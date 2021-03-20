using StockData.Contract;
using StockData.Repository;
using System;
using System.Linq;

namespace StockData.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //source should be set in config files, but i'll simplify this
            var stockDS = StockDataSources.Mock;
            var stock = new StockRepository(stockDS).GetWarehouseStock();
            DisplayData(stock);
            Console.ReadKey();
        }

        private static void DisplayData(WarehouseStockDto[] stock)
        {
            foreach (var result in stock.OrderByDescending(x=>x.SumOfProducts).OrderByDescending(x=>x.WarehouseId))
            {
                Console.WriteLine(result.ToString());
            }
        }


    }
}
