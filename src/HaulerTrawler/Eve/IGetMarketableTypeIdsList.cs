using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaulerTrawler.Interfaces;

namespace HaulerTrawler.Eve
{
    public interface IGetMarketableTypeIdsList
    {
        IEnumerable<TypeId> Get();
    }
}
