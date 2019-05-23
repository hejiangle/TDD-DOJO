using Bridge.Constants;
using Bridge.Models;

namespace Bridge.RuleCheckers.Implementation
{
    public class ThreeOfAKindWinChecker : Checker
    {
        public override bool IsCheckingFinished(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (!HasResult && whiteCards.IsThreeOfAKindCards() && blackCards.IsThreeOfAKindCards())
            {
                Result = CompareSameType(whiteCards, blackCards);
            }
            
            if (!HasResult && (whiteCards.IsThreeOfAKindCards() && blackCards.IsThreeOfAKindCards()))
            {
                Result = DirectlyWin(whiteCards, blackCards);
            }

            return HasResult;
        }

        protected override string DirectlyWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (whiteCards.IsThreeOfAKindCards()
                && (blackCards.IsMessyCards()
                    || blackCards.IsOnePairCards()
                    || blackCards.IsTwoPairsCards()))
            {
                HasResult = true;
                
                return string.Format(StringConstant.WHITE_WIN_TEMPLATE, StringConstant.THREE_OF_A_KIND);
            }

            if (blackCards.IsThreeOfAKindCards()
                && (whiteCards.IsMessyCards()
                    || whiteCards.IsOnePairCards()
                    || whiteCards.IsTwoPairsCards()))
            {
                HasResult = true;
                
                return string.Format(StringConstant.BLACK_WIN_TEMPLATE, StringConstant.THREE_OF_A_KIND);
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