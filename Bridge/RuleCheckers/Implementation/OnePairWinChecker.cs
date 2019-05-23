using Bridge.Constants;
using Bridge.Models;

namespace Bridge.RuleCheckers.Implementation
{
    public class OnePairWinChecker : Checker
    {
        protected override string CompareSameType(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            var whitePair = whiteCards.GetSameNumberCardByCount(2);
            var blackPair = blackCards.GetSameNumberCardByCount(2);

            var compareResult = whitePair.CompareWith(blackPair);

            HasResult = true;
            
            if (!compareResult.Equals(StringConstant.TIE))
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
                
                return string.Format(StringConstant.WHITE_WIN_TEMPLATE, StringConstant.PAIR);
            }

            if (whiteCards.IsMessyCards() && blackCards.IsOnePairCards())
            {
                HasResult = true;
                
                return string.Format(StringConstant.BLACK_WIN_TEMPLATE, StringConstant.PAIR);
            }

            return StringConstant.TIE;
        }
    }
}