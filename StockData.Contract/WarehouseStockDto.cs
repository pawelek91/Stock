using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockData.Contract
{
    public class WarehouseStockDto
    {
        public string WarehouseId { get; set; }
        public int SumOfProducts { get; set; }
        public IEnumerable<ProductQuantityDto> ProductQuantity { get; set; }
        public WarehouseStockDto()
        {
            ProductQuantity = new List<ProductQuantityDto>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{WarehouseId} (total {SumOfProducts})");
            foreach(var pq in ProductQuantity.OrderBy(x=>x.ProductId))
            {
                sb.AppendLine($"{pq.ProductId}:\t{pq.Quantity}");
            }
            return sb.ToString();
        }
    }
}
