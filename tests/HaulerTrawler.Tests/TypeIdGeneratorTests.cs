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
    public class TypeIdGeneratorTests
    {
        [Fact]
        public void PullsListOfTypesFromCrest_AndPicksRandomOne() 
        {
           var getMarketableTypeIdsList = new Mock<IGetMarketableTypeIdsList>();
           getMarketableTypeIdsList.Setup(x => x.Get())
               .Returns(new [] { new TypeId(123, "foo"), new TypeId(456, "bar") });
           var randomChooser = new Mock<IRandomChooser>();
           randomChooser.Setup(x => x.Choose(It.IsAny<IEnumerable<TypeId>>()))
               .Returns<IEnumerable<TypeId>>(x => x.First());

           var subject = new TypeIdGenerator(getMarketableTypeIdsList.Object,
                   randomChooser.Object);
           var result = subject.GetNext();

           result.ShouldBeEquivalentTo(new TypeId(123, "foo"));
        }

        [Fact]
        public void CachesListOfTypeIds() 
        {
           var getMarketableTypeIdsList = new Mock<IGetMarketableTypeIdsList>();
           var randomChooser = new Mock<IRandomChooser>();
           var subject = new TypeIdGenerator(getMarketableTypeIdsList.Object,
                   randomChooser.Object);

           subject.GetNext();
           subject.GetNext();
           subject.GetNext();

           getMarketableTypeIdsList.Verify(x => x.Get(), Times.Once);
        }
    }
}
