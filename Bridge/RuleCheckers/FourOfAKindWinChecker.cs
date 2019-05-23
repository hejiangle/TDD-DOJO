using static Bridge.Constants.StringConstant;

namespace Bridge.RuleCheckers
{
    public class FourOfAKindWinChecker
    {
        public string DirectlyWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
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

        public string CompareSameType(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            var whiteFullHouseCard = whiteCards.GetSameNumberCardByCount(4);
            var blackFullHouseCard = blackCards.GetSameNumberCardByCount(4);

            var compareResult = whiteFullHouseCard.CompareWith(blackFullHouseCard);

            return compareResult.Equals(TIE) ? CHEAT : compareResult;
        }
    }
}