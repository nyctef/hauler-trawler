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
    public class TradeGeneratorTests
    {
        [Fact]
        public void TakesARandomTypeID_AndPriceChecksIt()
        {
            var typeIdGenerator = new Mock<ITypeIdGenerator>();
            typeIdGenerator.Setup(x => x.GetNext())
                .Returns(new TypeId(1234, "Widget II"));
            var priceChecker = new Mock<IPriceChecker>();
            priceChecker.Setup(x => x.GetPrice(It.IsAny<TypeId>(), It.IsAny<SolarSystemId>()))
                .Returns<TypeId, SolarSystemId>((type, ssId) => {
                        return ssId.Name == "Amarr" ? new PriceInfo(120, 123) : new PriceInfo(450, 456);
                        });
            var solarSystemFactory = new Mock<ISolarSystemFactory>();
            solarSystemFactory.Setup(x => x.GetSolarSystem(It.IsAny<string>()))
                    .Returns<string>(name => new SolarSystemId(1337, name));
            var routeFinder = new Mock<ISolarSystemRouteFinder>();
            var subject = new TradeGenerator(typeIdGenerator.Object, priceChecker.Object, solarSystemFactory.Object, routeFinder.Object);

            var result = subject.GetNext();

            result.SourceSystem.Name.Should().Be("Amarr");
            result.TargetSystem.Name.Should().Be("Jita");
            result.Type.Name.Should().Be("Widget II");
        }
    }
}
