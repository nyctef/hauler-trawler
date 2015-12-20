using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaulerTrawler
{
    public class HaulerTrawler
    {
        private readonly ITypeIdGenerator m_TypeIdGenerator;
        private readonly IPriceChecker m_PriceChecker;
        private readonly ITradeAnalyzer m_TradeAnalyzer;
        private readonly INotifier m_Notifier;
        private readonly ISolarSystemFactory m_SolarSystemFactory;

        public HaulerTrawler(ITypeIdGenerator typeIdGenerator, IPriceChecker priceChecker, ISolarSystemFactory solarSystemFactory, ITradeAnalyzer tradeAnalyzer, INotifier notifier)
        {
            m_TypeIdGenerator = typeIdGenerator;
            m_PriceChecker = priceChecker;
            m_TradeAnalyzer = tradeAnalyzer;
            m_Notifier = notifier;
            m_SolarSystemFactory = solarSystemFactory;
        }

        public void DoTheThing()
        {
            var nextTypeId = m_TypeIdGenerator.GetNext();
            var amarr = m_SolarSystemFactory.GetSolarSystem("Amarr");
            var jita = m_SolarSystemFactory.GetSolarSystem("Jita");
            var amarrPrice = m_PriceChecker.GetPrice(nextTypeId, amarr);
            var jitaPrice = m_PriceChecker.GetPrice(nextTypeId, jita);
            var numJumps = m_SolarSystemFactory.GetNumberOfJumps(amarr, jita);
            var analyzerResult = m_TradeAnalyzer.IsGoodTrade(amarrPrice, jitaPrice, numJumps);
            if (analyzerResult.IsGood())
            {
                m_Notifier.Notify(string.Format("Trade found! {0}s ({1} {2} -> {3} {4})",
                            nextTypeId.NameString,
                            amarrPrice.IskString,
                            amarr.NameString,
                            jitaPrice.IskString,
                            jita.NameString));
            }
        }
    }
}
