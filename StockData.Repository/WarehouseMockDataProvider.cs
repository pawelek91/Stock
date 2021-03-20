using System;
using System.Collections.Generic;
using System.Text;

namespace StockData.Repository
{
    public class WarehouseMockDataProvider : IWarehouseDataProvider
    {
        public IEnumerable<string> ProvideRawData()
        {
            var sb = new StringBuilder();
            sb.AppendLine("# Productinventory initial state as of Jan 01 20");
            sb.AppendLine("# New products");
            sb.AppendLine("QPharm 200 MGTABS 64;COM-100001;WH-A,5|WH-B,10");
            sb.AppendLine("QPharm 200 MG TABS 32;COM-124047;WH-A,15");
            sb.AppendLine("AD Tech300 MG 200 ML;COM-123906c;WH-A,10|WH-B,6|WH-C,2");
            sb.AppendLine("ActiveLab VIAL INFUS 500 MG 10 50 M;COM-123908;WH-A,10|WH-B,11");
            sb.AppendLine("# Existing products, restocked");
            sb.AppendLine("QPharm 200MGTABS 16;CB0115-CASSRC;WH-C,13|WH-B,5");
            sb.AppendLine("4H CherryDROPS 500 MG /1ML 1 100 ML;4H-Cherry-100ml;WH-A,10|WH-B,1");
            sb.AppendLine("ActiveLab VIAL INFUS 500 MG 10 100 M;COM-123823;WH-C,10");
            sb.AppendLine("AD Tech 500 MG 200 ML;COM-101734;WH-C,8");
            var str = sb.ToString();
            return str.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }
    }
}
