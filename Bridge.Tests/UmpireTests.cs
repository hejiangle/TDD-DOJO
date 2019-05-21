using System.Collections.Generic;
using Xunit;

namespace Bridge.Tests
{
    public class UmpireTests
    {
        [Theory]
        [MemberData(nameof(MessyHandCards))]
        [MemberData(nameof(OnePairHandCards))]
        [MemberData(nameof(TwoPairsHandCards))]
        [MemberData(nameof(ThreeOfAKindHandCards))]
        public void ShouldCompareTwoHandsCardsAndReturnTheHighestCard(List<string> hardCards_1, List<string> hardCards_2, string expected)
        {
            var umpire = new Umpire();

            var theHighestCard = umpire.CompareCards(hardCards_1, hardCards_2);
            
            Assert.Equal(expected, theHighestCard);
        }

        public static IEnumerable<object[]> MessyHandCards => new List<object[]>
        {
            new object[]{new List<string> { "2H", "3D", "5S", "9C", "KD"}, new List<string> {"2C", "3H", "4S", "8C", "AH"}, "A"},
            new object[]{new List<string> { "2H", "3D", "5S", "9C", "QD"}, new List<string> {"2C", "3H", "4S", "8C", "TH"}, "Q"},
            new object[]{new List<string> { "2H", "3D", "5S", "9C", "QD"}, new List<string> {"2C", "3H", "4S", "8C", "QH"}, "9"},
            new object[]{new List<string> { "2H", "3D", "5S", "9C", "QD"}, new List<string> {"2C", "3H", "5S", "9C", "QH"}, "Tie"},
        };

        public static IEnumerable<object[]> OnePairHandCards => new List<object[]>
        {
            new object[]{new List<string> { "2H", "2D", "5S", "9C", "KD"}, new List<string> {"3C", "3H", "4S", "8C", "AH"}, "3"},
            new object[]{new List<string> { "2H", "3D", "9S", "9C", "QD"}, new List<string> {"2C", "3H", "4S", "TC", "TH"}, "T"},
            new object[]{new List<string> { "2H", "3D", "5S", "QC", "QD"}, new List<string> {"2C", "3H", "4S", "QC", "QH"}, "5"},
            new object[]{new List<string> { "2H", "3D", "5S", "QC", "QD"}, new List<string> {"2C", "3H", "5S", "QC", "QH"}, "Tie"},
        };

        public static IEnumerable<object[]> TwoPairsHandCards => new List<object[]>
        {
            new object[]{new List<string> { "2H", "2D", "5S", "5C", "KD"}, new List<string> {"3C", "3H", "4S", "4C", "AH"}, "5"},
            new object[]{new List<string> { "2H", "2D", "9S", "9C", "QD"}, new List<string> {"2C", "4H", "4S", "TC", "TH"}, "T"},
            new object[]{new List<string> { "2H", "2D", "5S", "QC", "QD"}, new List<string> {"2C", "2H", "4S", "QC", "QH"}, "5"},
            new object[]{new List<string> { "2H", "2D", "5S", "QC", "QD"}, new List<string> {"2C", "2H", "5S", "QC", "QH"}, "Tie"},
        };
        
        public static IEnumerable<object[]> ThreeOfAKindHandCards => new List<object[]>
        {
            new object[]{new List<string> { "2H", "2D", "2S", "5C", "KD"}, new List<string> {"3C", "3H", "3S", "4C", "AH"}, "3"},
            new object[]{new List<string> { "2H", "9D", "2S", "2C", "QD"}, new List<string> {"4C", "QH", "4S", "TC", "4H"}, "4"},
            new object[]{new List<string> { "2H", "3D", "QS", "QC", "QD"}, new List<string> {"2C", "4H", "QS", "QC", "QH"}, "4"},
            new object[]{new List<string> { "2H", "2D", "2S", "TC", "QD"}, new List<string> {"2C", "2H", "2S", "TC", "QH"}, "Tie"},
        };
    }
}