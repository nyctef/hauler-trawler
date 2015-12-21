using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaulerTrawler.Interfaces;
using HaulerTrawler.Utils;

namespace HaulerTrawler.Eve
{
    public class TypeIdGenerator : ITypeIdGenerator
    {
        private readonly IGetMarketableTypeIdsList m_GetMarketableTypeIdsList;
        private readonly IRandomChooser m_RandomChooser;

        public TypeIdGenerator(IGetMarketableTypeIdsList getMarketableTypeIdsList,
                IRandomChooser randomChooser)
        {
            m_GetMarketableTypeIdsList = getMarketableTypeIdsList;
            m_RandomChooser = randomChooser;
        }

        public TypeId GetNext()
        {
            var typeIdsList = m_GetMarketableTypeIdsList.Get();
            var typeId = m_RandomChooser.Choose(typeIdsList);
            return typeId;
        }
    }
}
