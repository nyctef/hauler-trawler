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
    public class RandomChooserTests
    {
        [Fact]
        public void ChoosesSingleElementFromSingletonList() 
        {
            var randomChooser = new RandomChooser();
            var list = new[] { "foo" };
            randomChooser.Choose(list).Should().Be("foo");
        }
    }
}
