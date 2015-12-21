using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions;
using HaulerTrawler;
using HaulerTrawler.Interfaces;

namespace HaulerTrawler.Tests
{
    public class HaulerTrawlerTests
    {
        [Fact]
        public void TakesARandomTypeID_AndPriceChecksIt_AndDecidesIfProfitIsWorthIt_AndNotifiesAboutIt()
        {
            var typeIdGenerator = new Mock<ITypeIdGenerator>();
            var priceChecker = new Mock<IPriceChecker>();
            var tradeAnalyzer = new Mock<ITradeAnalyzer>();
            var solarSystemFactory = new Mock<ISolarSystemFactory>();
            var notifier = new Mock<INotifier>();
            var subject = new HaulerTrawler(typeIdGenerator.Object, priceChecker.Object, solarSystemFactory.Object, tradeAnalyzer.Object, notifier.Object);

            subject.DoTheThing();

            notifier.Verify(x => x.Notify("Trade found! Widget IIs (123ISK Amarr -> 456ISK Jita)"));
        }
    }
}
