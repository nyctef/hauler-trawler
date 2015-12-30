using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaulerTrawler.Interfaces;
using HaulerTrawler.Eve;
using HaulerTrawler.Utils;

namespace HaulerTrawler
{
    public class Notifier : INotifier
    {
        public Notifier()
        {
        }

        public void Notify(string message)
        {
            Console.WriteLine("==========");
            Console.WriteLine(message);
            Console.WriteLine("==========");
        }
    }
}
