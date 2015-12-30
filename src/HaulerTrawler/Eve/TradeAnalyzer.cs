using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaulerTrawler.Interfaces;
using HaulerTrawler.Eve;
using HaulerTrawler.Utils;

namespace HaulerTrawler.Eve
{
    public class TradeAnalyzer : ITradeAnalyzer
    {
        public TradeAnalyzer()
        {
        }

        public TradeAnalyzerResult IsGoodTrade(TradeInfo trade)
        {
            return new TradeAnalyzerResult(
                    trade.TargetPrice.SellMin > trade.SourcePrice.SellMin
                    );
        }
    }
}
