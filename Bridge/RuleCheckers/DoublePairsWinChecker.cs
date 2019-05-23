using static Bridge.Constants.StringConstant;

namespace Bridge.RuleCheckers
{
    public class DoublePairsWinChecker
    {
        public string CompareSameType(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            var whitePairs = whiteCards.GetTwoPairsCards();
            var blackPairs = blackCards.GetTwoPairsCards();

            var highCard = whitePairs.CompareWith(blackPairs);

            if (highCard.Equals(TIE))
            {
                var singleWhiteCard = whiteCards.GetSingleCards();
                var singleBlackCard = blackCards.GetSingleCards();

                highCard = singleWhiteCard.CompareWith(singleBlackCard);
            }

            return highCard;
        }

        public string DirectlyWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
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
    }
}