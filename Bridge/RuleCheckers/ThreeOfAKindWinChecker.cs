using static Bridge.Constants.StringConstant;

namespace Bridge.RuleCheckers
{
    public class ThreeOfAKindWinChecker
    {
        public string DirectlyWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
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

        public string CompareSameType(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            var whiteThreeOfAKind = whiteCards.GetSameNumberCardByCount(3);
            var blackThreeOfAKind = blackCards.GetSameNumberCardByCount(3);

            var compareResult = whiteThreeOfAKind.CompareWith(blackThreeOfAKind);

            return compareResult.Equals(TIE) ? CHEAT : compareResult;
        }
    }
}