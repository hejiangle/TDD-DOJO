using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace Bridge.Tests
{
    public class UmpireTests
    {
        [Theory]
        [MemberData(nameof(MessyHardCards))]
        public void ShouldCompareTwoHandsMessyCardsAndReturnTheHighestCard(List<string> hardCards_1, List<string> hardCards_2, string expected)
        {
            var umpire = new Umpire();

            var theHighestCard = umpire.CompareCards(hardCards_1, hardCards_2);
            
            Assert.Equal(expected, theHighestCard);
        }

        public static IEnumerable<object[]> MessyHardCards => new List<object[]>
        {
            new object[]{new List<string> { "2H", "3D", "5S", "9C", "KD"}, new List<string> {"2C", "3H", "4S", "8C", "AH"}, "A"},
            new object[]{new List<string> { "2H", "3D", "5S", "9C", "QD"}, new List<string> {"2C", "3H", "4S", "8C", "TH"}, "Q"},
            new object[]{new List<string> { "2H", "3D", "5S", "9C", "QD"}, new List<string> {"2C", "3H", "4S", "8C", "QH"}, "9"},
        };
    }
}