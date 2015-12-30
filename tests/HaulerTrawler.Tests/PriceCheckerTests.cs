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
    [Slow]
    public class PriceCheckerTests
    {
        [Fact]
        public void PullsPricesFromPriceSite()
        {
            var jita = new SolarSystemId(30000142, "Jita");
            var trit = new TypeId(34, "Tritanium");
            var subject = new PriceChecker();

            var result = subject.GetPrice(trit, jita);

            result.SellMin.Should().BeLessThan(10, "trit should not be crazy expensive");
            result.SellMin.Should().BeGreaterThan(0, "trit should not be free");
        }
    }
}
