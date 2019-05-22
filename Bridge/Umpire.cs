using System.Collections.Generic;
using System.Linq;

namespace Bridge
{
    public class Umpire
    {
        private const string WHITE_WIN_TEMPLATE = "White wins - {0}";
        private const string BLACK_WIN_TEMPLATE = "Black wins - {0}";
        private const string TIE = "Tie";
        private const string CHEAT = "Cheat!!!";

        private const string STRAIGHT_FLUSH = "Straight flush";
        private const string FOUR_OF_A_KIND = "Four of a Kind";
        private const string FULL_HOUSE = "Full house";
        private const string FLUSH = "Flush";
        private const string STRAIGHT = "Straight";
        private const string THREE_OF_A_KIND = "Three of a Kind";
        private const string TWO_PAIRS = "Two pairs";
        private const string PAIR = "Pair";
        
        public string CompareCards(List<string> whiteHandCards, List<string> blackHandCards)
        {
            var whiteCards = whiteHandCards.Select(Card.Parse).OrderByDescending(card => card.Value).ToList();
            var blackCards = blackHandCards.Select(Card.Parse).OrderByDescending(card => card.Value).ToList();

            if (IsStraightFlushCards(whiteCards) && IsStraightFlushCards(blackCards))
            {
                return CompareStraightHandCards(whiteCards, blackCards);
            }
            if (IsStraightFlushCards(whiteCards) || IsStraightFlushCards(blackCards))
            {
                return StraightFlushWin(whiteCards, blackCards);
            }

            if (IsFourOfAKindCards(whiteCards) && IsFourOfAKindCards(blackCards))
            {
                return CompareFourOfAKindHandCards(whiteCards, blackCards);
            }
            if (IsFourOfAKindCards(whiteCards) || IsFourOfAKindCards(blackCards))
            {
                return FourOfAKindCardsWin(whiteCards, blackCards);
            }

            if (IsFullHouseCards(whiteCards) && IsFullHouseCards(blackCards))
            {
                return CompareFullHouseHandCards(whiteCards, blackCards);
            }
            if (IsFullHouseCards(whiteCards) || IsFullHouseCards(blackCards))
            {
                return FullHouseWin(whiteCards, blackCards);
            }

            if (IsFlushCards(whiteCards) && IsFlushCards(blackCards))
            {
                return CompareMessyCards(whiteCards, blackCards, 5);
            }
            if (IsFlushCards(whiteCards) || IsFlushCards(blackCards))
            {
                return FlushCardsWin(whiteCards, blackCards);
            }

            if (IsStraightCards(whiteCards) && IsStraightCards(blackCards))
            {
                return CompareStraightHandCards(whiteCards, blackCards);
            }
            if (IsStraightCards(whiteCards) || IsStraightCards(blackCards))
            {
                return StraightCardsWin(whiteCards, blackCards);
            }

            if (IsThreeOfAKindCards(whiteCards) && IsThreeOfAKindCards(blackCards))
            {
                return CompareThreeOfAKindHandCards(whiteCards, blackCards);
            }
            if (IsThreeOfAKindCards(whiteCards) && IsThreeOfAKindCards(blackCards))
            {
                return ThreeOfAKindWin(whiteCards, blackCards);
            }

            if (IsTwoPairsCards(whiteCards) && IsTwoPairsCards(blackCards))
            {
                return CompareDoublePairsHandCards(whiteCards, blackCards);
            }
            if (IsTwoPairsCards(whiteCards) || IsTwoPairsCards(blackCards))
            {
                return DoublePairsWin(whiteCards, blackCards);
            }

            if (IsOnePairCards(whiteCards) && IsOnePairCards(blackCards))
            {
                return CompareOnePairHandCards(whiteCards, blackCards);
            }
            if (IsOnePairCards(whiteCards) || IsOnePairCards(blackCards))
            {
                return OnePairWin(whiteCards, blackCards);
            }

            return CompareMessyCards(whiteCards, blackCards, 5);
        }

        private string StraightFlushWin(List<Card> whiteCards, List<Card> blackCards)
        {
            if (IsStraightFlushCards(whiteCards) && IsMessyCards(blackCards)
                || IsStraightFlushCards(whiteCards) && IsOnePairCards(blackCards)
                || IsStraightFlushCards(whiteCards) && IsTwoPairsCards(blackCards)
                || IsStraightFlushCards(whiteCards) && IsThreeOfAKindCards(blackCards)
                || IsStraightFlushCards(whiteCards) && IsStraightCards(blackCards)
                || IsStraightFlushCards(whiteCards) && IsFlushCards(blackCards)
                || IsStraightFlushCards(whiteCards) && IsFullHouseCards(blackCards)
                || IsStraightFlushCards(whiteCards) && IsFourOfAKindCards(blackCards))
            {
                return string.Format(WHITE_WIN_TEMPLATE, STRAIGHT_FLUSH);
            }

            if (IsMessyCards(whiteCards) && IsStraightFlushCards(blackCards)
                || IsOnePairCards(whiteCards) && IsStraightFlushCards(blackCards)
                || IsTwoPairsCards(whiteCards) && IsStraightFlushCards(blackCards)
                || IsThreeOfAKindCards(whiteCards) && IsStraightFlushCards(blackCards)
                || IsStraightCards(whiteCards) && IsStraightFlushCards(blackCards)
                || IsFlushCards(whiteCards) && IsStraightFlushCards(blackCards)
                || IsFullHouseCards(whiteCards) && IsStraightFlushCards(blackCards)
                || IsFourOfAKindCards(whiteCards) && IsStraightFlushCards(blackCards))
            {
                return string.Format(BLACK_WIN_TEMPLATE, STRAIGHT_FLUSH);
            }

            return TIE;
        }

        private string FullHouseWin(List<Card> whiteCards, List<Card> blackCards)
        {
            if (IsFullHouseCards(whiteCards) && IsMessyCards(blackCards)
                || IsFullHouseCards(whiteCards) && IsOnePairCards(blackCards)
                || IsFullHouseCards(whiteCards) && IsTwoPairsCards(blackCards)
                || IsFullHouseCards(whiteCards) && IsThreeOfAKindCards(blackCards)
                || IsFullHouseCards(whiteCards) && IsStraightCards(blackCards)
                || IsFullHouseCards(whiteCards) && IsFlushCards(blackCards))
            {
                return string.Format(WHITE_WIN_TEMPLATE, FULL_HOUSE);
            }

            if (IsMessyCards(whiteCards) && IsFullHouseCards(blackCards)
                || IsOnePairCards(whiteCards) && IsFullHouseCards(blackCards)
                || IsTwoPairsCards(whiteCards) && IsFullHouseCards(blackCards)
                || IsThreeOfAKindCards(whiteCards) && IsFullHouseCards(blackCards)
                || IsStraightCards(whiteCards) && IsFullHouseCards(blackCards)
                || IsFlushCards(whiteCards) && IsFullHouseCards(blackCards))
            {
                return string.Format(BLACK_WIN_TEMPLATE, FULL_HOUSE);
            }

            return TIE;
        }

        private string CompareFullHouseHandCards(List<Card> whiteCards, List<Card> blackCards)
        {
            var whiteThreeOfAKind = whiteCards.Find(x => whiteCards.Count(y => y.Equals(x)) == 3);
            var blackThreeOfAKind = blackCards.Find(x => blackCards.Count(y => y.Equals(x)) == 3);

            var compareResult = whiteThreeOfAKind.CompareTo(blackThreeOfAKind);
            
            if (compareResult > 0)
            {
                return whiteThreeOfAKind.Number.ToString();
            }

            if (compareResult < 0)
            {
                return blackThreeOfAKind.Number.ToString();
            }
            
            return CHEAT;
        }

        private string FourOfAKindCardsWin(List<Card> whiteCards, List<Card> blackCards)
        {
            if (IsFourOfAKindCards(whiteCards) && IsMessyCards(blackCards)
                || IsFourOfAKindCards(whiteCards) && IsOnePairCards(blackCards)
                || IsFourOfAKindCards(whiteCards) && IsTwoPairsCards(blackCards)
                || IsFourOfAKindCards(whiteCards) && IsThreeOfAKindCards(blackCards)
                || IsFourOfAKindCards(whiteCards) && IsStraightCards(blackCards)
                || IsFourOfAKindCards(whiteCards) && IsFlushCards(blackCards)
                || IsFourOfAKindCards(whiteCards) && IsFullHouseCards(blackCards))
            {
                return string.Format(WHITE_WIN_TEMPLATE, FOUR_OF_A_KIND);
            }

            if (IsMessyCards(whiteCards) && IsFourOfAKindCards(blackCards)
                || IsOnePairCards(whiteCards) && IsFourOfAKindCards(blackCards)
                || IsTwoPairsCards(whiteCards) && IsFourOfAKindCards(blackCards)
                || IsThreeOfAKindCards(whiteCards) && IsFourOfAKindCards(blackCards)
                || IsStraightCards(whiteCards) && IsFourOfAKindCards(blackCards)
                || IsFlushCards(whiteCards) && IsFourOfAKindCards(blackCards)
                || IsFullHouseCards(whiteCards) && IsFourOfAKindCards(blackCards))
            {
                return string.Format(BLACK_WIN_TEMPLATE, FOUR_OF_A_KIND);
            }

            return TIE;
        }

        private string CompareFourOfAKindHandCards(List<Card> whiteCards, List<Card> blackCards)
        {
            var whiteFullHouseCard = whiteCards.Find(x => whiteCards.Count(y => y.Equals(x)) == 4);
            var blackFullHouseCard = blackCards.Find(x => blackCards.Count(y => y.Equals(x)) == 4);

            var compareResult = whiteFullHouseCard.CompareTo(blackFullHouseCard);

            if (compareResult > 0)
            {
                return whiteFullHouseCard.Number.ToString();
            }

            if (compareResult < 0)
            {
                return blackFullHouseCard.Number.ToString();
            }

            return CHEAT;
        }

        private string FlushCardsWin(List<Card> whiteCards, List<Card> blackCards)
        {
            if (IsFlushCards(whiteCards) && IsMessyCards(blackCards)
                || IsFlushCards(whiteCards) && IsOnePairCards(blackCards)
                || IsFlushCards(whiteCards) && IsTwoPairsCards(blackCards)
                || IsFlushCards(whiteCards) && IsThreeOfAKindCards(blackCards)
                || IsFlushCards(whiteCards) && IsStraightCards(blackCards))
            {
                return string.Format(WHITE_WIN_TEMPLATE, FLUSH);
            }

            if (IsMessyCards(whiteCards) && IsFlushCards(blackCards)
                || IsOnePairCards(whiteCards) && IsFlushCards(blackCards)
                || IsTwoPairsCards(whiteCards) && IsFlushCards(blackCards)
                || IsThreeOfAKindCards(whiteCards) && IsFlushCards(blackCards)
                || IsStraightCards(whiteCards) && IsFlushCards(blackCards))
            {
                return string.Format(BLACK_WIN_TEMPLATE, FLUSH);
            }

            return TIE;
        }

        private string StraightCardsWin(List<Card> whiteCards, List<Card> blackCards)
        {
            if (IsStraightCards(whiteCards) && IsMessyCards(blackCards)
                || IsStraightCards(whiteCards) && IsOnePairCards(blackCards)
                || IsStraightCards(whiteCards) && IsTwoPairsCards(blackCards)
                || IsStraightCards(whiteCards) && IsThreeOfAKindCards(blackCards))
            {
                return string.Format(WHITE_WIN_TEMPLATE, STRAIGHT);
            }

            if (IsMessyCards(whiteCards) && IsStraightCards(blackCards)
                || IsOnePairCards(whiteCards) && IsStraightCards(blackCards)
                || IsTwoPairsCards(whiteCards) && IsStraightCards(blackCards)
                || IsThreeOfAKindCards(whiteCards) && IsStraightCards(blackCards))
            {
                return string.Format(BLACK_WIN_TEMPLATE, STRAIGHT);
            }

            return CHEAT;
        }

        private string CompareStraightHandCards(List<Card> whiteCards, List<Card> blackCards)
        {
            var highCard = TIE;

            var compareResult = whiteCards.First().CompareTo(blackCards.First());
            
            if (compareResult > 0)
            {
                highCard = whiteCards.First().Number.ToString();
            }

            if (compareResult < 0)
            {
                highCard = blackCards.First().Number.ToString();
            }

            return highCard;
        }

        private string ThreeOfAKindWin(List<Card> whiteCards, List<Card> blackCards)
        {
            if (IsThreeOfAKindCards(whiteCards) && IsMessyCards(blackCards)
                || IsThreeOfAKindCards(whiteCards) && IsOnePairCards(blackCards)
                || IsThreeOfAKindCards(whiteCards) && IsTwoPairsCards(blackCards))
            {
                return string.Format(WHITE_WIN_TEMPLATE, THREE_OF_A_KIND);
            }

            if (IsMessyCards(whiteCards) && IsThreeOfAKindCards(blackCards)
                || IsOnePairCards(whiteCards) && IsThreeOfAKindCards(blackCards)
                || IsTwoPairsCards(whiteCards) && IsThreeOfAKindCards(blackCards))
            {
                return string.Format(BLACK_WIN_TEMPLATE, THREE_OF_A_KIND);
            }

            return TIE;
        }

        private string CompareThreeOfAKindHandCards(List<Card> whiteCards, List<Card> blackCards)
        {
            var whiteThreeOfAKind = whiteCards.Find(x => whiteCards.Count(y => y.Equals(x)) == 3);
            var blackThreeOfAKind = blackCards.Find(x => blackCards.Count(y => y.Equals(x)) == 3);
            
            var compareResult = whiteThreeOfAKind.CompareTo(blackThreeOfAKind);
            var highCard = CHEAT;

            if (compareResult > 0)
            {
                highCard = whiteThreeOfAKind.Number.ToString();
            }

            if (compareResult < 0)
            {
                highCard = blackThreeOfAKind.Number.ToString();
            }
            
            
//            if (compareResult == 0)
//            {
//                whiteCards.RemoveAll(card => card.Equals(whiteThreeOfAKind));
//                blackCards.RemoveAll(card => card.Equals(blackThreeOfAKind));
//                highCard = CompareMessyCards(whiteCards, blackCards, 2);
//            }

            return highCard;
        }


        private string CompareDoublePairsHandCards(List<Card> whiteCards, List<Card> blackCards)
        {
            var whitePairs = whiteCards
                .Where(x => whiteCards.Count(y => y.Equals(x)) == 2)
                .Distinct()
                .ToList();
            var blackPairs = blackCards
                .Where(x => blackCards.Count(y => y.Equals(x)) == 2)
                .Distinct()
                .ToList();

            var highCard = CompareMessyCards(whitePairs, blackPairs, 2);

            if (highCard.Equals(TIE))
            {
                var singleWhiteCard = whiteCards.Where(x => !whitePairs.Exists(x.Equals)).ToList();
                var singleBlackCard = blackCards.Where(x => !blackPairs.Exists(x.Equals)).ToList();

                highCard = CompareMessyCards(singleWhiteCard, singleBlackCard, 1);
            }

            return highCard;
        }

        private string DoublePairsWin(List<Card> whiteCards, List<Card> blackCards)
        {
            if (IsTwoPairsCards(whiteCards) && IsMessyCards(blackCards)
                || IsTwoPairsCards(whiteCards) && IsOnePairCards(blackCards))
            {
                return string.Format(WHITE_WIN_TEMPLATE, TWO_PAIRS);
            }

            if (IsMessyCards(whiteCards) && IsTwoPairsCards(blackCards)
                || IsOnePairCards(whiteCards) && IsTwoPairsCards(blackCards))
            {
                 return string.Format(BLACK_WIN_TEMPLATE, TWO_PAIRS);
            }

            return TIE;
        }

        private static string CompareOnePairHandCards(List<Card> whiteCards, List<Card> blackCards)
        {
            var whitePair = whiteCards.Find(x => whiteCards.Count(y => y.Equals(x)) == 2);
            var blackPair = blackCards.Find(x => blackCards.Count(y => y.Equals(x)) == 2);

            var compareResult = whitePair.CompareTo(blackPair);
            var highCard = TIE;

            if (compareResult > 0)
            {
                highCard = whitePair.Number.ToString();
            }

            if (compareResult < 0)
            {
                highCard = blackPair.Number.ToString();
            }

            if (compareResult == 0)
            {
                whiteCards.RemoveAll(card => card.Equals(whitePair));
                blackCards.RemoveAll(card => card.Equals(blackPair));
                highCard = CompareMessyCards(whiteCards, blackCards, 3);
            }

            return highCard;
        }

        private string OnePairWin(List<Card> whiteCards, List<Card> blackCards)
        {
            if (IsOnePairCards(whiteCards) && IsMessyCards(blackCards))
            {
                return string.Format(WHITE_WIN_TEMPLATE, PAIR);
            }

            if (IsMessyCards(whiteCards) && IsOnePairCards(blackCards))
            {
                return string.Format(BLACK_WIN_TEMPLATE, PAIR);
            }

            return TIE;
        }

        private static string CompareMessyCards(List<Card> whiteCards, List<Card> blackCards, int cardCounts)
        {
            var index = 0;
            var highCard = TIE;
            
            while (index < cardCounts)
            {
                var compareResult = whiteCards[index].CompareTo(blackCards[index]);

                if (compareResult > 0)
                {
                    highCard = whiteCards[index].Number.ToString();
                    break;
                }

                if (compareResult < 0)
                {
                    highCard = blackCards[index].Number.ToString();
                    break;
                }

                index++;
            }

            return highCard;
        }

        private bool IsMessyCards(List<Card> handCards)
        {
            return !IsOnePairCards(handCards) 
                   && !IsTwoPairsCards(handCards) 
                   && !IsThreeOfAKindCards(handCards) 
                   && !IsStraightCards(handCards)
                   && !IsFourOfAKindCards(handCards)
                   && !IsFullHouseCards(handCards)
                   && !IsFlushCards(handCards)
                   && !IsStraightFlushCards(handCards);
        }

        private bool IsOnePairCards(List<Card> handCards)
        {
            return handCards.Distinct().Count() == 4;
        }

        private bool IsTwoPairsCards(List<Card> handCards)
        {
            var index = 0;
            var pairsCount = 0;
            while (index < 4)
            {
                if (handCards[index].Equals(handCards[index + 1]))
                {
                    pairsCount++;
                    index++;
                }

                index++;
            }

            return pairsCount == 2 && handCards.Distinct().Count() == 3;
        }
        
        private bool IsThreeOfAKindCards(List<Card> handCards)
        {
            return !IsTwoPairsCards(handCards) && handCards.Distinct().Count() == 3;
        }
        
        
        private bool IsStraightCards(List<Card> handCards)
        {
            return handCards.All(card => (card.Value + handCards.IndexOf(card)).Equals(handCards.First().Value));
        }

        private bool IsFlushCards(List<Card> handCards)
        {
            return handCards.All(card => card.Suit.Equals(handCards.First().Suit));
        }

        private bool IsFullHouseCards(List<Card> handCards)
        {
            return !IsFourOfAKindCards(handCards) && handCards.Distinct().Count() == 2;
        }

        private bool IsFourOfAKindCards(List<Card> handCards)
        {
            return handCards.Exists(x => handCards.Count(y => y.Equals(x)) == 4);
        }

        private bool IsStraightFlushCards(List<Card> handCards)
        {
            return IsFlushCards(handCards) && IsStraightCards(handCards);
        }
    }
}