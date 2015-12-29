using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HaulerTrawler.Interfaces;
using Newtonsoft.Json.Linq;

namespace HaulerTrawler.Eve
{
    public class GetSolarSystemIds : IGetSolarSystemIds
    {
        // TODO start de-duping between this class and GetMarketableTypeIdsList

        public IEnumerable<SolarSystemId> Get()
        {
            var crestBaseUrl = @"https://public-crest.eveonline.com/";
            dynamic crestBase = GetJson(crestBaseUrl);
            var systemsUrl = (string)crestBase.industry.systems.href;
            var result = new List<SolarSystemId>();
            while (true)
            {
                Console.WriteLine("Fetching "+systemsUrl);
                dynamic systems = GetJson(systemsUrl);
                foreach (var item in systems.items)
                {
                    result.Add(new SolarSystemId((int)item.solarSystem.id, (string)item.solarSystem.name));
                }
                var next = systems.next;
                if (next == null) { break; }
                systemsUrl = next.href;
            }
            return result;
        }

        private static dynamic GetJson(string url)
        {
            using (var client = new HttpClient())
            {
                // TODO async
                var json = client.GetStringAsync(url).Result;
                return JObject.Parse(json);
            }
        }
    }
}
