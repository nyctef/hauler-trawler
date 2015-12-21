using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaulerTrawler.Utils
{
    public interface IRandomChooser
    {
        T Choose<T>(IEnumerable<T> choices);
    }
}
