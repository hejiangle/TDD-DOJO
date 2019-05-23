using static Bridge.Constants.StringConstant;

namespace Bridge.RuleCheckers
{
    public class OnePairWinChecker
    {
        public string CompareSameType(DescendingHandCards whiteCards, DescendingHandCards blackCards)
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
            return whiteSingleCards.CompareWith(blackSingleCards);
        }

        public string DirectlyWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
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
    }
}