using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaulerTrawler.Interfaces
{
    public interface ITradeAnalyzer
    {
        TradeAnalyzerResult IsGoodTrade(PriceInfo buyPrice, PriceInfo sellPrice, int numJumps);
    }
}
