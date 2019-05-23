using Bridge.Constants;
using Bridge.Models;

namespace Bridge.RuleCheckers.Implementation
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

                return string.Format(StringConstant.WHITE_WIN_TEMPLATE, StringConstant.STRAIGHT_FLUSH);
            }

            if (!whiteCards.IsStraightFlushCards()
                && blackCards.IsStraightFlushCards())
            {
                HasResult = true;

                return string.Format(StringConstant.BLACK_WIN_TEMPLATE, StringConstant.STRAIGHT_FLUSH);
            }

            return StringConstant.TIE;
        }

        protected override string CompareSameType(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            HasResult = true;

            return whiteCards.CompareWith(blackCards);
        }
    }
}