using Bridge.Models;

namespace Bridge.RuleCheckers.Implementation
{
    public class MessyWinChecker : Checker
    {
        public override bool IsCheckingFinished(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (whiteCards.IsMessyCards() && blackCards.IsMessyCards())
            {
                Result = CompareSameType(whiteCards, blackCards);
            }

            return HasResult;
        }

        protected override string DirectlyWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            throw new System.NotImplementedException();
        }

        protected override string CompareSameType(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            HasResult = true;
            
            return whiteCards.CompareWith(blackCards);
        }
    }
}