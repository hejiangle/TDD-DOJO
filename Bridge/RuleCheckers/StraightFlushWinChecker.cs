using static Bridge.Constants.StringConstant;

namespace Bridge.RuleCheckers
{
    public class StraightFlushWinChecker : Checker
    {
        public override bool IsCheckingFinished(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (!HasResult && whiteCards.IsStraightFlushCards() && blackCards.IsStraightFlushCards())
            {
                Result = CompareSameType(whiteCards, blackCards);
            }
            
            if (!HasResult && (whiteCards.IsStraightFlushCards() || blackCards.IsStraightFlushCards()))
            {
                Result = DirectlyWin(whiteCards, blackCards);
            }

            return HasResult;
        }

        protected override string DirectlyWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (whiteCards.IsStraightFlushCards() 
                && !blackCards.IsStraightFlushCards())
            {
                HasResult = true;

                return string.Format(WHITE_WIN_TEMPLATE, STRAIGHT_FLUSH);
            }

            if (!whiteCards.IsStraightFlushCards()
                && blackCards.IsStraightFlushCards())
            {
                HasResult = true;

                return string.Format(BLACK_WIN_TEMPLATE, STRAIGHT_FLUSH);
            }

            return TIE;
        }

        protected override string CompareSameType(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            HasResult = true;

            return whiteCards.CompareWith(blackCards);
        }
    }
}