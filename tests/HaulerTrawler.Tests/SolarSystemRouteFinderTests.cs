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
    public class SolarSystemRouteFinderTests
    {
        [Fact]
        public void PullsPricesFromPriceSite()
        {
            var jita = new SolarSystemId(30000142, "Jita");
            var amarr = new SolarSystemId(30002187, "Amarr");
            var subject = new SolarSystemRouteFinder();

            var result = subject.GetNumberOfJumps(jita, amarr);

            result.Should().Be(9, "Amarr to Jita is 10 systems (9 jumps)");
        }
    }
}
