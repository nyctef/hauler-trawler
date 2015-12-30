using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaulerTrawler.Interfaces;
using HaulerTrawler.Eve;

namespace HaulerTrawler
{
    public class HaulerTrawler
    {
        private readonly ITradeGenerator m_TradeGenerator;
        private readonly ITradeAnalyzer m_TradeAnalyzer;
        private readonly INotifier m_Notifier;

        public HaulerTrawler(ITradeGenerator tradeGenerator, ITradeAnalyzer tradeAnalyzer, INotifier notifier)
        {
            m_TradeGenerator = tradeGenerator;
            m_TradeAnalyzer = tradeAnalyzer;
            m_Notifier = notifier;
        }

        public void DoTheThing()
        {
            var tradeInfo = m_TradeGenerator.GetNext();
            var analyzerResult = m_TradeAnalyzer.IsGoodTrade(tradeInfo);
            if (analyzerResult.IsGood)
            {
                m_Notifier.Notify(string.Format("Trade found! {0}s ({1} {2} -> {3} {4})",
                            tradeInfo.Type.Name,
                            tradeInfo.SourcePrice.IskString,
                            tradeInfo.SourceSystem.Name,
                            tradeInfo.TargetPrice.IskString,
                            tradeInfo.TargetSystem.Name));
            }
        }
    }
}
