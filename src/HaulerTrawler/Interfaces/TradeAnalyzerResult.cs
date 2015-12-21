using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaulerTrawler.Interfaces
{
    public class TradeAnalyzerResult
    {
        public TradeAnalyzerResult(bool isGood)
        {
            IsGood = isGood;
        }

        public bool IsGood { get; }
    }
}
