using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaulerTrawler.Interfaces;

namespace HaulerTrawler.Eve
{
    public class TradeGenerator : ITradeGenerator
    {
        private readonly ITypeIdGenerator m_TypeIdGenerator;
        private readonly IPriceChecker m_PriceChecker;
        private readonly ISolarSystemFactory m_SolarSystemFactory;
        private readonly ISolarSystemRouteFinder m_SolarSystemRouteFinder;

        public TradeGenerator(ITypeIdGenerator typeIdGenerator, IPriceChecker priceChecker, ISolarSystemFactory solarSystemFactory, ISolarSystemRouteFinder solarSystemRouteFinder)
        {
            m_TypeIdGenerator = typeIdGenerator;
            m_PriceChecker = priceChecker;
            m_SolarSystemFactory = solarSystemFactory;
            m_SolarSystemRouteFinder = solarSystemRouteFinder;
        }

        public TradeInfo GetNext()
        {
             var nextTypeId = m_TypeIdGenerator.GetNext();
             var amarr = m_SolarSystemFactory.GetSolarSystem("Amarr");
             var jita = m_SolarSystemFactory.GetSolarSystem("Jita");
             var amarrPrice = m_PriceChecker.GetPrice(nextTypeId, amarr);
             var jitaPrice = m_PriceChecker.GetPrice(nextTypeId, jita);
             var numJumps = m_SolarSystemRouteFinder.GetNumberOfJumps(amarr, jita);
             return new TradeInfo(nextTypeId, amarrPrice, jitaPrice, amarr, jita, numJumps);
        }
    }
}
