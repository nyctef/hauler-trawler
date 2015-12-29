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
    [Slow]
    public class GetSolarSystemIdsTests
    {
        [Fact]
        public void PullsListOfTypesFromCrest() 
        {
            var subject = new GetSolarSystemIds();
            var result = subject.Get();
            result.Should().Contain(x => x.Name == "Amarr", "should contain the most important system");
        }
    }
}
