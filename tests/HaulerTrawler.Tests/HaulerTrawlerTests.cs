using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions;
using HaulerTrawler;
using HaulerTrawler.Interfaces;
using Moq;

namespace HaulerTrawler.Tests
{
    public class HaulerTrawlerTests
    {
        [Fact]
        public void TakesARandomTypeID_AndPriceChecksIt_AndDecidesIfProfitIsWorthIt_AndNotifiesAboutIt()
        {
            var typeIdGenerator = new Mock<ITypeIdGenerator>();
            typeIdGenerator.Setup(x => x.GetNext())
                .Returns(new TypeId(1234, "Widget II"));
            var priceChecker = new Mock<IPriceChecker>();
            priceChecker.Setup(x => x.GetPrice(It.IsAny<TypeId>(), It.IsAny<SolarSystemId>()))
                .Returns<TypeId, SolarSystemId>((type, ssId) => {
                        return ssId.NameString == "Amarr" ? new PriceInfo(123) : new PriceInfo(456);
                        });
            var tradeAnalyzer = new Mock<ITradeAnalyzer>();
            tradeAnalyzer.Setup(x => x.IsGoodTrade(It.IsAny<PriceInfo>(), It.IsAny<PriceInfo>(), It.IsAny<int>()))
                    .Returns(new TradeAnalyzerResult(true));
            var solarSystemFactory = new Mock<ISolarSystemFactory>();
            solarSystemFactory.Setup(x => x.GetSolarSystem(It.IsAny<string>()))
                    .Returns<string>(name => new SolarSystemId(1337, name));
            var notifier = new Mock<INotifier>();
            var subject = new HaulerTrawler(typeIdGenerator.Object, priceChecker.Object, solarSystemFactory.Object, tradeAnalyzer.Object, notifier.Object);

            subject.DoTheThing();

            notifier.Verify(x => x.Notify("Trade found! Widget IIs (123ISK Amarr -> 456ISK Jita)"));
        }
    }
}
