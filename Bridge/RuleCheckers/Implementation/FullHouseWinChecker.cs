using Bridge.Constants;
using Bridge.Models;

namespace Bridge.RuleCheckers.Implementation
{
    public class FullHouseWinChecker : Checker, IChecker
    {
        public override bool IsCheckingFinished(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (!HasResult && whiteCards.IsFullHouseCards() && blackCards.IsFullHouseCards())
            {
                Result = CompareSameType(whiteCards, blackCards);
            }
            
            if (!HasResult && (whiteCards.IsFullHouseCards() || blackCards.IsFullHouseCards()))
            {
                Result = DirectlyWin(whiteCards, blackCards);
            }

            return HasResult;
        }

        protected override string DirectlyWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (whiteCards.IsFullHouseCards()
                && !blackCards.IsFullHouseCards()
                && !blackCards.IsFourOfAKindCards()
                && !blackCards.IsStraightFlushCards())
            {
                HasResult = true;

                return string.Format(StringConstant.WHITE_WIN_TEMPLATE, StringConstant.FULL_HOUSE);
            }

            if (blackCards.IsFullHouseCards() && !whiteCards.IsFullHouseCards() && !whiteCards.IsStraightFlushCards())
            {
                HasResult = true;

                return string.Format(StringConstant.BLACK_WIN_TEMPLATE, StringConstant.FULL_HOUSE);
            }

            return StringConstant.TIE;
        }

        protected override string CompareSameType(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            var whiteThreeOfAKind = whiteCards.GetSameNumberCardByCount(3);
            var blackThreeOfAKind = blackCards.GetSameNumberCardByCount(3);

            var compareResult = whiteThreeOfAKind.CompareWith(blackThreeOfAKind);

            HasResult = true;

            return compareResult.Equals(StringConstant.TIE) ? StringConstant.CHEAT : compareResult;
        }
    }
}