using static Bridge.Constants.StringConstant;

namespace Bridge.RuleCheckers
{
    public class StraightFlushWinChecker
    {
        public string DirectlyWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (whiteCards.IsStraightFlushCards() 
                && !blackCards.IsStraightFlushCards())
            {
                return string.Format(WHITE_WIN_TEMPLATE, STRAIGHT_FLUSH);
            }

            if (!whiteCards.IsStraightFlushCards()
                && blackCards.IsStraightFlushCards())
            {
                return string.Format(BLACK_WIN_TEMPLATE, STRAIGHT_FLUSH);
            }

            return TIE;
        }
    }
}