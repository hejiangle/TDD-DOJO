using Bridge.Models;

namespace Bridge.RuleCheckers
{
    public interface IChecker
    {
        bool IsCheckingFinished(DescendingHandCards whiteCards, DescendingHandCards blackCards);

        string ShowHand();
    }
}