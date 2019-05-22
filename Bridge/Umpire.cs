using System.Collections.Generic;
using Bridge.RuleCheckers;
using static Bridge.Constants.StringConstant;

namespace Bridge
{
    public class Umpire
    {
        private readonly StraightFlushWinChecker _straightFlushWinChecker;

        public Umpire(StraightFlushWinChecker straightFlushWinChecker)
        {
            _straightFlushWinChecker = straightFlushWinChecker;
        }

        public string CompareCards(List<string> whiteHandCards, List<string> blackHandCards)
        {
            var whiteCards = new DescendingHandCards(whiteHandCards);
            var blackCards = new DescendingHandCards(blackHandCards);

            if (whiteCards.IsStraightFlushCards() && blackCards.IsStraightFlushCards())
            {
                return CompareStraightHandCards(whiteCards, blackCards);
            }
            if (whiteCards.IsStraightFlushCards() || blackCards.IsStraightFlushCards())
            {
                return _straightFlushWinChecker.DirectlyWin(whiteCards, blackCards);
            }

            if (whiteCards.IsFourOfAKindCards() && blackCards.IsFourOfAKindCards())
            {
                return CompareFourOfAKindHandCards(whiteCards, blackCards);
            }
            if (whiteCards.IsFourOfAKindCards() || blackCards.IsFourOfAKindCards())
            {
                return FourOfAKindCardsWin(whiteCards, blackCards);
            }

            if (whiteCards.IsFullHouseCards() && blackCards.IsFullHouseCards())
            {
                return CompareFullHouseHandCards(whiteCards, blackCards);
            }
            if (whiteCards.IsFullHouseCards() || blackCards.IsFullHouseCards())
            {
                return FullHouseWin(whiteCards, blackCards);
            }

            if (whiteCards.IsFlushCards() && blackCards.IsFlushCards())
            {
                return CompareMessyCards(whiteCards, blackCards, 5);
            }
            if (whiteCards.IsFlushCards() || blackCards.IsFlushCards())
            {
                return FlushCardsWin(whiteCards, blackCards);
            }

            if (whiteCards.IsStraightCards() && blackCards.IsStraightCards())
            {
                return CompareStraightHandCards(whiteCards, blackCards);
            }
            if (whiteCards.IsStraightCards() || blackCards.IsStraightCards())
            {
                return StraightCardsWin(whiteCards, blackCards);
            }

            if (whiteCards.IsThreeOfAKindCards() && blackCards.IsThreeOfAKindCards())
            {
                return CompareThreeOfAKindHandCards(whiteCards, blackCards);
            }
            if (whiteCards.IsThreeOfAKindCards() && blackCards.IsThreeOfAKindCards())
            {
                return ThreeOfAKindWin(whiteCards, blackCards);
            }

            if (whiteCards.IsTwoPairsCards() && blackCards.IsTwoPairsCards())
            {
                return CompareDoublePairsHandCards(whiteCards, blackCards);
            }
            if (whiteCards.IsTwoPairsCards() || blackCards.IsTwoPairsCards())
            {
                return DoublePairsWin(whiteCards, blackCards);
            }

            if (whiteCards.IsOnePairCards() && blackCards.IsOnePairCards())
            {
                return CompareOnePairHandCards(whiteCards, blackCards);
            }
            if (whiteCards.IsOnePairCards() || blackCards.IsOnePairCards())
            {
                return OnePairWin(whiteCards, blackCards);
            }

            return CompareMessyCards(whiteCards, blackCards, 5);
        }

        

        private string FullHouseWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (whiteCards.IsFullHouseCards()
                && !blackCards.IsFullHouseCards()
                && !blackCards.IsFourOfAKindCards()
                && !blackCards.IsStraightFlushCards())
            {
                return string.Format(WHITE_WIN_TEMPLATE, FULL_HOUSE);
            }

            if (blackCards.IsFullHouseCards() && !whiteCards.IsFullHouseCards() && !whiteCards.IsStraightFlushCards())
            {
                return string.Format(BLACK_WIN_TEMPLATE, FULL_HOUSE);
            }

            return TIE;
        }

        private string CompareFullHouseHandCards(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            var whiteThreeOfAKind = whiteCards.GetSameNumberCardByCount(3);
            var blackThreeOfAKind = blackCards.GetSameNumberCardByCount(3);

            var compareResult = whiteThreeOfAKind.CompareWith(blackThreeOfAKind);
            
            return compareResult.Equals(TIE) ? CHEAT : compareResult;
        }

        private string FourOfAKindCardsWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (whiteCards.IsFourOfAKindCards()
                && !blackCards.IsFourOfAKindCards()
                && !blackCards.IsStraightFlushCards())
            {
                return string.Format(WHITE_WIN_TEMPLATE, FOUR_OF_A_KIND);
            }

            if (blackCards.IsFourOfAKindCards()
                && !whiteCards.IsFourOfAKindCards()
                && !whiteCards.IsStraightFlushCards())
            {
                return string.Format(BLACK_WIN_TEMPLATE, FOUR_OF_A_KIND);
            }

            return TIE;
        }

        private string CompareFourOfAKindHandCards(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            var whiteFullHouseCard = whiteCards.GetSameNumberCardByCount(4);
            var blackFullHouseCard = blackCards.GetSameNumberCardByCount(4);

            var compareResult = whiteFullHouseCard.CompareWith(blackFullHouseCard);
            
            return compareResult.Equals(TIE) ? CHEAT : compareResult;
        }

        private string FlushCardsWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (whiteCards.IsFlushCards()
                && !blackCards.IsStraightFlushCards()
                && !blackCards.IsFourOfAKindCards()
                && !blackCards.IsFullHouseCards())
            {
                return string.Format(WHITE_WIN_TEMPLATE, FLUSH);
            }

            if (blackCards.IsFlushCards()
                && !whiteCards.IsStraightFlushCards()
                && !whiteCards.IsFourOfAKindCards()
                && !whiteCards.IsFullHouseCards())
            {
                return string.Format(BLACK_WIN_TEMPLATE, FLUSH);
            }

            return TIE;
        }

        private string StraightCardsWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (whiteCards.IsStraightCards()
                && !blackCards.IsStraightFlushCards()
                && !blackCards.IsFourOfAKindCards()
                && !blackCards.IsFullHouseCards()
                && !blackCards.IsFlushCards())
            {
                return string.Format(WHITE_WIN_TEMPLATE, STRAIGHT);
            }

            if (blackCards.IsStraightCards()
                && !whiteCards.IsStraightFlushCards()
                && !whiteCards.IsFourOfAKindCards()
                && !whiteCards.IsFullHouseCards()
                && !whiteCards.IsFlushCards())
            {
                return string.Format(BLACK_WIN_TEMPLATE, STRAIGHT);
            }

            return CHEAT;
        }

        private string CompareStraightHandCards(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            var theMaxValueWhiteCard = whiteCards.GetTheMaxValueCard();
            var theMaxValueBlackCard = blackCards.GetTheMaxValueCard();
            
            return theMaxValueWhiteCard.CompareWith(theMaxValueBlackCard);
        }

        private string ThreeOfAKindWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (whiteCards.IsThreeOfAKindCards()
                && (blackCards.IsMessyCards()
                    || blackCards.IsOnePairCards()
                    || blackCards.IsTwoPairsCards()))
            {
                return string.Format(WHITE_WIN_TEMPLATE, THREE_OF_A_KIND);
            }

            if (blackCards.IsThreeOfAKindCards()
                && (whiteCards.IsMessyCards()
                    || whiteCards.IsOnePairCards()
                    || whiteCards.IsTwoPairsCards()))
            {
                return string.Format(BLACK_WIN_TEMPLATE, THREE_OF_A_KIND);
            }

            return TIE;
        }

        private string CompareThreeOfAKindHandCards(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            var whiteThreeOfAKind = whiteCards.GetSameNumberCardByCount(3);
            var blackThreeOfAKind = blackCards.GetSameNumberCardByCount(3);
            
            var compareResult = whiteThreeOfAKind.CompareWith(blackThreeOfAKind);

            return compareResult.Equals(TIE) ? CHEAT : compareResult;
        }


        private string CompareDoublePairsHandCards(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            var whitePairs = whiteCards.GetTwoPairsCards();
            var blackPairs = blackCards.GetTwoPairsCards();
                
            var highCard = CompareMessyCards(whitePairs, blackPairs, 2);

            if (highCard.Equals(TIE))
            {
                var singleWhiteCard = whiteCards.GetSingleCards();
                var singleBlackCard = blackCards.GetSingleCards();

                highCard = CompareMessyCards(singleWhiteCard, singleBlackCard, 1);
            }

            return highCard;
        }

        private string DoublePairsWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (whiteCards.IsTwoPairsCards() && (blackCards.IsMessyCards() || blackCards.IsOnePairCards()))
            {
                return string.Format(WHITE_WIN_TEMPLATE, TWO_PAIRS);
            }

            if (blackCards.IsTwoPairsCards() && (whiteCards.IsMessyCards() || whiteCards.IsOnePairCards()))
            {
                 return string.Format(BLACK_WIN_TEMPLATE, TWO_PAIRS);
            }

            return TIE;
        }

        private string CompareOnePairHandCards(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            var whitePair = whiteCards.GetSameNumberCardByCount(2);
            var blackPair = blackCards.GetSameNumberCardByCount(2);

            var compareResult = whitePair.CompareWith(blackPair);

            if (!compareResult.Equals(TIE))
            {
                return compareResult;
            }

            var whiteSingleCards = whiteCards.GetSingleCards();
            var blackSingleCards = blackCards.GetSingleCards();
            return CompareMessyCards(whiteSingleCards, blackSingleCards, 3);
        }

        private string OnePairWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (whiteCards.IsOnePairCards() && blackCards.IsMessyCards())
            {
                return string.Format(WHITE_WIN_TEMPLATE, PAIR);
            }

            if (whiteCards.IsMessyCards() && blackCards.IsOnePairCards())
            {
                return string.Format(BLACK_WIN_TEMPLATE, PAIR);
            }

            return TIE;
        }

        private static string CompareMessyCards(DescendingHandCards whiteCards, DescendingHandCards blackCards, int cardCounts)
        {
            var index = 1;
            
            while (index <= cardCounts)
            {
                var whiteCard = whiteCards.GetCardByIndex(index);
                var blackCard = blackCards.GetCardByIndex(index);
                
                var compareResult = whiteCard.CompareWith(blackCard);

                if (!compareResult.Equals(TIE))
                {
                    return compareResult;
                }

                index++;
            }

            return TIE;
        }

        
    }
}