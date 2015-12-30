using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions;
using HaulerTrawler;
using HaulerTrawler.Interfaces;
using HaulerTrawler.Eve;
using Moq;

namespace HaulerTrawler.Tests
{
    public class HaulerTrawlerTests
    {
        [Fact]
        public void TakesARandomTrade_AndDecidesIfProfitIsWorthIt_AndNotifiesAboutIt()
        {
            var tradeGenerator = new Mock<ITradeGenerator>();
            tradeGenerator.Setup(x => x.GetNext())
                .Returns(new TradeInfo(new TypeId(1234, "Widget II"),
                            new PriceInfo(120, 123),
                            new PriceInfo(450, 456),
                            new SolarSystemId(123, "Amarr"),
                            new SolarSystemId(456, "Jita"),
                            12));
            var tradeAnalyzer = new Mock<ITradeAnalyzer>();
            tradeAnalyzer.Setup(x => x.IsGoodTrade(It.IsAny<TradeInfo>()))
                    .Returns(new TradeAnalyzerResult(true));
            var notifier = new Mock<INotifier>();
            var subject = new HaulerTrawler(tradeGenerator.Object, tradeAnalyzer.Object, notifier.Object);

            subject.DoTheThing();

            notifier.Verify(x => x.Notify("Trade found! Widget IIs (123.00 ISK Amarr -> 456.00 ISK Jita)"));
        }
    }
}
