using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HaulerTrawler.Interfaces;
using Newtonsoft.Json.Linq;

namespace HaulerTrawler.Eve
{
    public class GetMarketableTypeIdsList : IGetMarketableTypeIdsList
    {
        public IEnumerable<TypeId> Get()
        {
            var crestBaseUrl = @"https://public-crest.eveonline.com/";
            dynamic crestBase = GetJson(crestBaseUrl);
            var marketTypesUrl = (string)crestBase.marketTypes.href;
            var result = new List<TypeId>();
            while (true)
            {
                Console.WriteLine("Fetching "+marketTypesUrl);
                dynamic marketTypes = GetJson(marketTypesUrl);
                foreach (var item in marketTypes.items)
                {
                    result.Add(new TypeId((int)item.type.id, (string)item.type.name));
                }
                var next = marketTypes.next;
                if (next == null) { break; }
                marketTypesUrl = next.href;
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
