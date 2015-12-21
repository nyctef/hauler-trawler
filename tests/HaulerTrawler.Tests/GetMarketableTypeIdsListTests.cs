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
    public class GetMarketableTypeIdsListTests
    {
        [Fact]
        public void PullsListOfTypesFromCrest() 
        {
            var subject = new GetMarketableTypeIdsList();
            var result = subject.Get();
            result.Should().NotBeEmpty();
        }
    }
}
