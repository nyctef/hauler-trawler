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
            IskString = amount + "ISK";
        }

        // TODO: we might have multiple prices here
        public string IskString { get; }
    }
}
