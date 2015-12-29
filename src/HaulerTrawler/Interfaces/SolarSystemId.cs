using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaulerTrawler.Interfaces
{
    public class SolarSystemId
    {
        public SolarSystemId(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; }
        public int Id { get; }
    }
}
