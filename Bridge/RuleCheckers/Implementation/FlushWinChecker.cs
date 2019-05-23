using Bridge.Constants;
using Bridge.Models;

namespace Bridge.RuleCheckers.Implementation
{
    public class FlushWinChecker : Checker
    {
        public override bool IsCheckingFinished(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (!HasResult && whiteCards.IsFlushCards() && blackCards.IsFlushCards())
            {
                Result = CompareSameType(whiteCards,blackCards);
            }
            if (!HasResult && (whiteCards.IsFlushCards() || blackCards.IsFlushCards()))
            {
                Result = DirectlyWin(whiteCards, blackCards);
            }

            return HasResult;
        }

        protected override string DirectlyWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (whiteCards.IsFlushCards()
                && !blackCards.IsStraightFlushCards()
                && !blackCards.IsFourOfAKindCards()
                && !blackCards.IsFullHouseCards())
            {
                HasResult = true;

                return string.Format(StringConstant.WHITE_WIN_TEMPLATE, StringConstant.FLUSH);
            }

            if (blackCards.IsFlushCards()
                && !whiteCards.IsStraightFlushCards()
                && !whiteCards.IsFourOfAKindCards()
                && !whiteCards.IsFullHouseCards())
            {
                HasResult = true;

                return string.Format(StringConstant.BLACK_WIN_TEMPLATE, StringConstant.FLUSH);
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