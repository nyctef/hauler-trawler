using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaulerTrawler.Eve;

namespace HaulerTrawler.Interfaces
{
    public interface ITradeGenerator
    {
        TradeInfo GetNext();
    }
}
