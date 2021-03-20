using StockData.Contract;
using StockData.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockData.Repository
{
    public static class Mapper
    {
        public static ProductDto Map(Product entity)
        => new ProductDto
            {
                Id = entity.ProductId,
                Name = entity.ProductName
            };

        public static ProductQuantityDto Map(ProductQuantity entity)
        => new ProductQuantityDto
            {
                ProductId = entity.ProductId,
                Quantity = entity.Quantity,
            };
    }
}
