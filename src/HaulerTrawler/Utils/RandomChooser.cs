using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaulerTrawler.Utils
{
    public class RandomChooser : IRandomChooser
    {
        private static readonly Random m_Random = new Random();

        public T Choose<T>(IEnumerable<T> enumerable)
        {
            // based on http://stackoverflow.com/a/48089/895407
            var available = enumerable.Count();
            foreach (var item in enumerable)
            {
                if (m_Random.NextDouble() < ((float)1/(float)available))
                {
                    return item;
                }
                available--;
            }
            throw new InvalidOperationException("Ran out of items to choose");
        }
    }
}
