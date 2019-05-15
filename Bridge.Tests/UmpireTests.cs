using System;
using System.Collections.Generic;
using Xunit;

namespace Bridge.Tests
{
    public class UmpireTests
    {
        [Fact]
        public void ShouldCompareTwoHandsMessyCardsAndReturnTheHighestCard()
        {
            var umpire = new Umpire();

            var theHighestCard = umpire.CompareCards(
                new List<string> {"2H, 3D, 5S, 9C, KD"},
                new List<string> {"2C, 3H, 4S, 8C, AH"});
            
            Assert.Equal("A", theHighestCard);
        }
    }
}