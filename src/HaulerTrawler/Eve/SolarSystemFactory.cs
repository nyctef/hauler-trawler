using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaulerTrawler.Interfaces;

namespace HaulerTrawler.Eve
{
    public class SolarSystemFactory : ISolarSystemFactory
    {
        private readonly Lazy<Dictionary<string, SolarSystemId>> m_SolarSystemIds;

        public SolarSystemFactory(IGetSolarSystemIds getSolarSystemIds)
        {
            m_SolarSystemIds = new Lazy<Dictionary<string, SolarSystemId>>(() =>
                    getSolarSystemIds.Get().ToDictionary(x => x.Name, x => x));
        }

        public SolarSystemId GetSolarSystem(string name)
        {
            return m_SolarSystemIds.Value[name];
        }
    }
}
