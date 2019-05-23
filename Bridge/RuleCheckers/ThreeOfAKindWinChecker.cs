using static Bridge.Constants.StringConstant;

namespace Bridge.RuleCheckers
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
                
                return string.Format(WHITE_WIN_TEMPLATE, THREE_OF_A_KIND);
            }

            if (blackCards.IsThreeOfAKindCards()
                && (whiteCards.IsMessyCards()
                    || whiteCards.IsOnePairCards()
                    || whiteCards.IsTwoPairsCards()))
            {
                HasResult = true;
                
                return string.Format(BLACK_WIN_TEMPLATE, THREE_OF_A_KIND);
            }

            return TIE;
        }

        protected override string CompareSameType(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            var whiteThreeOfAKind = whiteCards.GetSameNumberCardByCount(3);
            var blackThreeOfAKind = blackCards.GetSameNumberCardByCount(3);

            var compareResult = whiteThreeOfAKind.CompareWith(blackThreeOfAKind);

            HasResult = true;

            return compareResult.Equals(TIE) ? CHEAT : compareResult;
        }
    }
}