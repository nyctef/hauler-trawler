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
    public class SolarSystemFactoryTests
    {
        [Fact]
        public void PullsListOfSolarSystemsFromCrest_AndHandsThemOutByName() 
        {
            var getSolarSystemIds = new Mock<IGetSolarSystemIds>();
            getSolarSystemIds.Setup(x => x.Get()).Returns(
                    new List<SolarSystemId> {
                        new SolarSystemId(123, "Amarr"),
                        new SolarSystemId(456, "Jita")
                        });
            var subject = new SolarSystemFactory(getSolarSystemIds.Object);

            var result = subject.GetSolarSystem("Amarr");

            result.Id.Should().Be(123);
        }
    }
}
