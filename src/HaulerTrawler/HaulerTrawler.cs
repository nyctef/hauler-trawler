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
        private readonly ITypeIdGenerator m_TypeIdGenerator;
        private readonly IPriceChecker m_PriceChecker;
        private readonly ITradeAnalyzer m_TradeAnalyzer;
        private readonly INotifier m_Notifier;
        private readonly ISolarSystemFactory m_SolarSystemFactory;
        private readonly ISolarSystemRouteFinder m_SolarSystemRouteFinder;

        public HaulerTrawler(ITypeIdGenerator typeIdGenerator, IPriceChecker priceChecker, ISolarSystemFactory solarSystemFactory, ITradeAnalyzer tradeAnalyzer, INotifier notifier, ISolarSystemRouteFinder solarSystemRouteFinder)
        {
            m_TypeIdGenerator = typeIdGenerator;
            m_PriceChecker = priceChecker;
            m_TradeAnalyzer = tradeAnalyzer;
            m_Notifier = notifier;
            m_SolarSystemFactory = solarSystemFactory;
            m_SolarSystemRouteFinder = solarSystemRouteFinder;
        }

        public void DoTheThing()
        {
            var nextTypeId = m_TypeIdGenerator.GetNext();
            var amarr = m_SolarSystemFactory.GetSolarSystem("Amarr");
            var jita = m_SolarSystemFactory.GetSolarSystem("Jita");
            var amarrPrice = m_PriceChecker.GetPrice(nextTypeId, amarr);
            var jitaPrice = m_PriceChecker.GetPrice(nextTypeId, jita);
            var numJumps = m_SolarSystemRouteFinder.GetNumberOfJumps(amarr, jita);
            var tradeInfo = new TradeInfo(amarrPrice, jitaPrice, numJumps);
            var analyzerResult = m_TradeAnalyzer.IsGoodTrade(tradeInfo);
            if (analyzerResult.IsGood)
            {
                m_Notifier.Notify(string.Format("Trade found! {0}s ({1} {2} -> {3} {4})",
                            nextTypeId.Name,
                            amarrPrice.IskString,
                            amarr.Name,
                            jitaPrice.IskString,
                            jita.Name));
            }
        }
    }
}
