using Bridge.Constants;
using Bridge.Models;

namespace Bridge.RuleCheckers.Implementation
{
    public class TwoPairsWinChecker : Checker
    {
        public override bool IsCheckingFinished(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (!HasResult && whiteCards.IsTwoPairsCards() && blackCards.IsTwoPairsCards())
            {
                Result = CompareSameType(whiteCards, blackCards);
            }
            
            if (!HasResult && (whiteCards.IsTwoPairsCards() || blackCards.IsTwoPairsCards()))
            {
                 Result = DirectlyWin(whiteCards, blackCards);
            }

            return HasResult;
        }

        protected override string DirectlyWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (whiteCards.IsTwoPairsCards() && (blackCards.IsMessyCards() || blackCards.IsOnePairCards()))
            {
                HasResult = true;
                return string.Format(StringConstant.WHITE_WIN_TEMPLATE, StringConstant.TWO_PAIRS);
            }

            if (blackCards.IsTwoPairsCards() && (whiteCards.IsMessyCards() || whiteCards.IsOnePairCards()))
            {
                HasResult = true;
                return string.Format(StringConstant.BLACK_WIN_TEMPLATE, StringConstant.TWO_PAIRS);
            }

            return StringConstant.TIE;
        }

        protected override string CompareSameType(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            var whitePairs = whiteCards.GetTwoPairsCards();
            var blackPairs = blackCards.GetTwoPairsCards();

            var highCard = whitePairs.CompareWith(blackPairs);

            if (highCard.Equals(StringConstant.TIE))
            {
                var singleWhiteCard = whiteCards.GetSingleCards();
                var singleBlackCard = blackCards.GetSingleCards();

                highCard = singleWhiteCard.CompareWith(singleBlackCard);
            }

            HasResult = true;
            return highCard;
        }
    }
}