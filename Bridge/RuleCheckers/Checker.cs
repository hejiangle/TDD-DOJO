using Bridge.Models;

namespace Bridge.RuleCheckers
{
    public abstract class Checker : IChecker
    {
        protected string Result { get; set; }

        protected bool HasResult { get; set; }
        public abstract bool IsCheckingFinished(DescendingHandCards whiteCards, DescendingHandCards blackCards);

        public string ShowHand()
        {
            return Result;
        }

        protected abstract string DirectlyWin(DescendingHandCards whiteCards, DescendingHandCards blackCards);
        
        protected abstract string CompareSameType(DescendingHandCards whiteCards, DescendingHandCards blackCards);
    }
}