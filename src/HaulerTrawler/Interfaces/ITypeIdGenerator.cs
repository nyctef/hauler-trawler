using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaulerTrawler.Interfaces
{
    public interface ITypeIdGenerator
    {
        TypeId GetNext();
    }
}
