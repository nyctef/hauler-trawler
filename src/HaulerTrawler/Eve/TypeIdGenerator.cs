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
        private readonly Lazy<IEnumerable<TypeId>> m_GetMarketableTypeIdsList;
        private readonly IRandomChooser m_RandomChooser;

        public TypeIdGenerator(IGetMarketableTypeIdsList getMarketableTypeIdsList,
                IRandomChooser randomChooser)
        {
            m_GetMarketableTypeIdsList = new Lazy<IEnumerable<TypeId>>(() =>
                    getMarketableTypeIdsList.Get());
            m_RandomChooser = randomChooser;
        }

        public TypeId GetNext()
        {
            var typeId = m_RandomChooser.Choose(m_GetMarketableTypeIdsList.Value);
            return typeId;
        }
    }
}
