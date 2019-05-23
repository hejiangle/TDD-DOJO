using static Bridge.Constants.StringConstant;

namespace Bridge.RuleCheckers
{
    public class FullHouseWinChecker
    {
        public string DirectlyWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
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

        public string CompareSameType(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            var whiteThreeOfAKind = whiteCards.GetSameNumberCardByCount(3);
            var blackThreeOfAKind = blackCards.GetSameNumberCardByCount(3);

            var compareResult = whiteThreeOfAKind.CompareWith(blackThreeOfAKind);

            return compareResult.Equals(TIE) ? CHEAT : compareResult;
        }
    }
}