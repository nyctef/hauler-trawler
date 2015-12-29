using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaulerTrawler.Interfaces
{
    public class PriceInfo
    {
        public PriceInfo(decimal amount)
        {
            IskString = FormatISK(amount);
        }

        // TODO: we might have multiple prices here
        public string IskString { get; }

        private static string FormatISK(decimal amount)
        {
            return string.Format("{0:F2} ISK", amount);
        }
    }
}
