using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaulerTrawler.Interfaces
{
    public class TypeId
    {
        public TypeId(int id, string name)
        {
            Id = id;
            NameString = name;
        }

        public int Id { get; }
        public string NameString { get; }
    }
}
