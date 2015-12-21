using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaulerTrawler.Interfaces
{
    public interface ISolarSystemFactory
    {
        SolarSystemId GetSolarSystem(string name);

        // TODO move this onto some route finder interface
        int GetNumberOfJumps(SolarSystemId start, SolarSystemId end);
    }
}
