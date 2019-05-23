using static Bridge.Constants.StringConstant;

namespace Bridge.RuleCheckers
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

                return string.Format(WHITE_WIN_TEMPLATE, FLUSH);
            }

            if (blackCards.IsFlushCards()
                && !whiteCards.IsStraightFlushCards()
                && !whiteCards.IsFourOfAKindCards()
                && !whiteCards.IsFullHouseCards())
            {
                HasResult = true;

                return string.Format(BLACK_WIN_TEMPLATE, FLUSH);
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