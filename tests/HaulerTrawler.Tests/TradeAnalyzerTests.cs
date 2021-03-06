using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using HaulerTrawler.Interfaces;
using HaulerTrawler.Eve;
using HaulerTrawler.Utils;
using FluentAssertions;

namespace HaulerTrawler.Tests
{
    public class TradeAnalyzerTests
    {
        [Fact]
        public void ReturnsGoodTradeIfTargetSellIsHigherThanSourceSell()
        {
            // TODO: in the future we'll want more logic to decide if a trade is actually worth it
            var trade = new TradeInfo(
                    new TypeId(123, "Widget II"),
                    new PriceInfo(10, 10),
                    new PriceInfo(100, 100),
                    new SolarSystemId(1, "Amarr"),
                    new SolarSystemId(2, "Jita"),
                    9);
            var subject = new TradeAnalyzer();

            var result = subject.IsGoodTrade(trade);

            result.IsGood.Should().BeTrue();
        }
    }
}
