
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaulerTrawler.Interfaces
{
    public interface ISolarSystemRouteFinder
    {
        int GetNumberOfJumps(SolarSystemId start, SolarSystemId end);
    }
}
