using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaulerTrawler.Interfaces
{
    public class PriceInfo
    {
        public PriceInfo(decimal buyMax, decimal sellMin)
        {
            BuyMax = buyMax;
            SellMin = sellMin;
            IskString = FormatISK(sellMin);
        }

        public string IskString { get; }
        public decimal BuyMax { get; }
        public decimal SellMin { get; }

        private static string FormatISK(decimal amount)
        {
            return string.Format("{0:F2} ISK", amount);
        }
    }
}
