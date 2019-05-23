using static Bridge.Constants.StringConstant;

namespace Bridge.RuleCheckers
{
    public class OnePairWinChecker : Checker
    {
        protected override string CompareSameType(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            var whitePair = whiteCards.GetSameNumberCardByCount(2);
            var blackPair = blackCards.GetSameNumberCardByCount(2);

            var compareResult = whitePair.CompareWith(blackPair);

            HasResult = true;
            
            if (!compareResult.Equals(TIE))
            {
                return compareResult;
            }

            var whiteSingleCards = whiteCards.GetSingleCards();
            var blackSingleCards = blackCards.GetSingleCards();
            
            return whiteSingleCards.CompareWith(blackSingleCards);
        }

        public override bool IsCheckingFinished(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (!HasResult && whiteCards.IsOnePairCards() && blackCards.IsOnePairCards())
            {
                Result = CompareSameType(whiteCards, blackCards);
            }
            
            if (!HasResult && (whiteCards.IsOnePairCards() || blackCards.IsOnePairCards()))
            {
                Result = DirectlyWin(whiteCards, blackCards);
            }

            return HasResult;
        }

        protected override string DirectlyWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (whiteCards.IsOnePairCards() && blackCards.IsMessyCards())
            {
                HasResult = true;
                
                return string.Format(WHITE_WIN_TEMPLATE, PAIR);
            }

            if (whiteCards.IsMessyCards() && blackCards.IsOnePairCards())
            {
                HasResult = true;
                
                return string.Format(BLACK_WIN_TEMPLATE, PAIR);
            }

            return TIE;
        }
    }
}