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
        [MemberData(nameof(StraightHandCards))]
        [MemberData(nameof(FlushHandCards))]
        [MemberData(nameof(FullHouseHandCards))]
        [MemberData(nameof(FourOfAKindHandCards))]
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
            new object[]{new List<string> { "2H", "3D", "QS", "QC", "QD"}, new List<string> {"2C", "5H", "QS", "QC", "QH"}, "Cheat!!!"},
            new object[]{new List<string> { "2H", "2D", "2S", "TC", "QD"}, new List<string> {"2C", "2H", "2S", "TC", "QH"}, "Cheat!!!"},
        };

        public static IEnumerable<object[]> StraightHandCards => new List<object[]>
        {
            new object[]{new List<string> { "2H", "3D", "4S", "5C", "6D"}, new List<string> {"5C", "6H", "7S", "8C", "9H"}, "9"},
            new object[]{new List<string> { "2H", "3D", "4S", "5C", "6D"}, new List<string> {"4C", "5H", "6S", "7C", "8H"}, "8"},
            new object[]{new List<string> { "9H", "TD", "JS", "QC", "KD"}, new List<string> {"TC", "JH", "QS", "KC", "AH"}, "A"},
            new object[]{new List<string> { "2H", "3D", "4S", "5C", "6D"}, new List<string> {"2C", "3H", "4S", "5C", "6H"}, "Tie"},
            new object[]{new List<string> { "2H", "2D", "2S", "TC", "QD"}, new List<string> {"5C", "6H", "7S", "8C", "9H"}, "Black wins - Straight"},
            new object[]{new List<string> { "2H", "2D", "TS", "TC", "QD"}, new List<string> {"5C", "6H", "7S", "8C", "9H"}, "Black wins - Straight"},
            new object[]{new List<string> { "2H", "2D", "9S", "TC", "QD"}, new List<string> {"5C", "6H", "7S", "8C", "9H"}, "Black wins - Straight"},
            new object[]{new List<string> { "AH", "2D", "9S", "TC", "QD"}, new List<string> {"5C", "6H", "7S", "8C", "9H"}, "Black wins - Straight"},
        };

        public static IEnumerable<object[]> FlushHandCards => new List<object[]>
        {
            new object[]{new List<string> { "2H", "3H", "4H", "5H", "9H"}, new List<string> {"5H", "6H", "7H", "8H", "9H"}, "8"},
            new object[]{new List<string> { "2D", "3D", "4D", "5D", "8D"}, new List<string> {"4H", "5H", "6H", "7H", "2H"}, "8"},
            new object[]{new List<string> { "9S", "TS", "JS", "8S", "KS"}, new List<string> {"TC", "JC", "QC", "KC", "8C"}, "Q"},
            new object[]{new List<string> { "2H", "3H", "4H", "5H", "7H"}, new List<string> {"2C", "3C", "4C", "5C", "7C"}, "Tie"},
            new object[]{new List<string> { "2H", "2D", "2S", "TC", "QD"}, new List<string> {"5H", "6H", "7H", "8H", "TH"}, "Black wins - Flush"},
            new object[]{new List<string> { "2H", "2D", "TS", "TC", "QD"}, new List<string> {"5H", "6H", "7H", "8H", "TH"}, "Black wins - Flush"},
            new object[]{new List<string> { "2H", "2D", "9S", "TC", "QD"}, new List<string> {"5H", "6H", "7H", "8H", "TH"}, "Black wins - Flush"},
            new object[]{new List<string> { "AH", "2D", "9S", "TC", "QD"}, new List<string> {"5H", "6H", "7H", "8H", "TH"}, "Black wins - Flush"},
            new object[]{new List<string> { "TH", "JD", "QS", "KC", "AD"}, new List<string> {"5H", "6H", "7H", "8H", "TH"}, "Black wins - Flush"},
        };

        public static IEnumerable<object[]> FullHouseHandCards => new List<object[]>
        {
            new object[]{new List<string> { "2C", "2H", "2S", "9D", "9H"}, new List<string> {"8C", "8H", "8D", "AS", "AH"}, "8"},
            new object[]{new List<string> { "2D", "2S", "2H", "8C", "8D"}, new List<string> {"2H", "2D", "2S", "6C", "6H"}, "Cheat!!!"},
            new object[]{new List<string> { "9D", "9S", "9H", "KC", "KS"}, new List<string> {"QC", "QS", "QH", "8D", "8C"}, "Q"},
            new object[]{new List<string> { "2C", "2H", "2D", "7S", "7H"}, new List<string> {"2C", "2H", "2D", "7S", "7S"}, "Cheat!!!"},
            new object[]{new List<string> { "2H", "2D", "2S", "TC", "QD"}, new List<string> {"8C", "8H", "8D", "AS", "AH"}, "Black wins - FullHouse"},
            new object[]{new List<string> { "2H", "2D", "TS", "TC", "QD"}, new List<string> {"8C", "8H", "8D", "AS", "AH"}, "Black wins - FullHouse"},
            new object[]{new List<string> { "2H", "2D", "9S", "TC", "QD"}, new List<string> {"8C", "8H", "8D", "AS", "AH"}, "Black wins - FullHouse"},
            new object[]{new List<string> { "AH", "2D", "9S", "TC", "QD"}, new List<string> {"8C", "8H", "8D", "AS", "AH"}, "Black wins - FullHouse"},
            new object[]{new List<string> { "5H", "6H", "7H", "8H", "TH"}, new List<string> {"8C", "8H", "8D", "AS", "AH"}, "Black wins - FullHouse"},
            new object[]{new List<string> { "TH", "JD", "QS", "KC", "AD"}, new List<string> {"8C", "8H", "8D", "AS", "AH"}, "Black wins - FullHouse"}
        };

        public static IEnumerable<object[]> FourOfAKindHandCards => new List<object[]>
        {
            new object[]{new List<string> { "2C", "2H", "2S", "2D", "9H"}, new List<string> {"8C", "8H", "8D", "8S", "AH"}, "8"},
            new object[]{new List<string> { "2D", "2S", "2H", "2C", "8D"}, new List<string> {"2H", "2D", "2S", "2C", "6H"}, "Cheat!!!"},
            new object[]{new List<string> { "9D", "9S", "9H", "9C", "KS"}, new List<string> {"QC", "QS", "QH", "QD", "8C"}, "Q"},
            new object[]{new List<string> { "2C", "2H", "2D", "2S", "7H"}, new List<string> {"2C", "2H", "2D", "2S", "7S"}, "Cheat!!!"},
            new object[]{new List<string> { "2H", "2D", "2S", "TC", "QD"}, new List<string> {"8C", "8H", "8D", "8S", "AH"}, "Black wins - Four of a Kind"},
            new object[]{new List<string> { "2H", "2D", "TS", "TC", "QD"}, new List<string> {"8C", "8H", "8D", "8S", "AH"}, "Black wins - Four of a Kind"},
            new object[]{new List<string> { "2H", "2D", "9S", "TC", "QD"}, new List<string> {"8C", "8H", "8D", "8S", "AH"}, "Black wins - Four of a Kind"},
            new object[]{new List<string> { "AH", "2D", "9S", "TC", "QD"}, new List<string> {"8C", "8H", "8D", "8S", "AH"}, "Black wins - Four of a Kind"},
            new object[]{new List<string> { "5H", "6H", "7H", "8H", "TH"}, new List<string> {"8C", "8H", "8D", "8S", "AH"}, "Black wins - Four of a Kind"},
            new object[]{new List<string> { "TH", "JD", "QS", "KC", "AD"}, new List<string> {"8C", "8H", "8D", "8S", "AH"}, "Black wins - Four of a Kind"},
            new object[]{new List<string> { "8C", "8H", "8D", "AS", "AH"}, new List<string> {"8C", "8H", "8D", "8S", "AH"}, "Black wins - Four of a Kind"},

        };
    }
}