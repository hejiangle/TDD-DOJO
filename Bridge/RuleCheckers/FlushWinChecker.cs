using static Bridge.Constants.StringConstant;

namespace Bridge.RuleCheckers
{
    public class FlushWinChecker
    {
        public string DirectlyWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
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
    }
}