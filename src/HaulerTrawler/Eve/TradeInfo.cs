using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaulerTrawler.Interfaces;

namespace HaulerTrawler.Eve
{
    public class TradeInfo
    {
        public TradeInfo(TypeId type, PriceInfo sourcePrice, PriceInfo targetPrice, SolarSystemId sourceSystem, SolarSystemId targetSystem, int numJumps)
        {
            Type = type;
            SourcePrice = sourcePrice;
            TargetPrice = targetPrice;
            SourceSystem = sourceSystem;
            TargetSystem = targetSystem;
            NumJumps = numJumps;
        }

        public TypeId Type { get; }
        public PriceInfo SourcePrice { get; }
        public PriceInfo TargetPrice { get; }
        public SolarSystemId SourceSystem { get; }
        public SolarSystemId TargetSystem { get; }
        public int NumJumps { get; }
    }
}
