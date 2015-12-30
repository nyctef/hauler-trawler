using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaulerTrawler.Interfaces;
using HaulerTrawler.Eve;
using HaulerTrawler.Utils;

namespace HaulerTrawler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var prog = new HaulerTrawler(
                    new TradeGenerator(
                        new TypeIdGenerator(
                            new GetMarketableTypeIdsList(),
                            new RandomChooser()
                            ),
                        new PriceChecker(),
                        new SolarSystemFactory(
                            new GetSolarSystemIds()
                            ),
                        new SolarSystemRouteFinder()
                        ),
                    new TradeAnalyzer(),
                    null // new Notifier()
                    );

            prog.DoTheThing();


            Console.WriteLine("Hello World");
            Console.Read();
        }
    }
}
