using Bridge.Constants;
using Bridge.Models;

namespace Bridge.RuleCheckers.Implementation
{
    public class StraightWinChecker : Checker
    {
        public override bool IsCheckingFinished(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (!HasResult && whiteCards.IsStraightCards() && blackCards.IsStraightCards())
            {
                Result = CompareSameType(whiteCards, blackCards);
            }
            
            if (!HasResult && (whiteCards.IsStraightCards() || blackCards.IsStraightCards()))
            {
                Result = DirectlyWin(whiteCards, blackCards);
            }

            return HasResult;
        }

        protected override string DirectlyWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (whiteCards.IsStraightCards()
                && !blackCards.IsStraightFlushCards()
                && !blackCards.IsFourOfAKindCards()
                && !blackCards.IsFullHouseCards()
                && !blackCards.IsFlushCards())
            {
                HasResult = true;
                
                return string.Format(StringConstant.WHITE_WIN_TEMPLATE, StringConstant.STRAIGHT);
            }

            if (blackCards.IsStraightCards()
                && !whiteCards.IsStraightFlushCards()
                && !whiteCards.IsFourOfAKindCards()
                && !whiteCards.IsFullHouseCards()
                && !whiteCards.IsFlushCards())
            {
                HasResult = true;
                
                return string.Format(StringConstant.BLACK_WIN_TEMPLATE, StringConstant.STRAIGHT);
            }

            return StringConstant.CHEAT;
        }

        protected override string CompareSameType(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            var theMaxValueWhiteCard = whiteCards.GetTheMaxValueCard();
            var theMaxValueBlackCard = blackCards.GetTheMaxValueCard();

            HasResult = true;
            
            return theMaxValueWhiteCard.CompareWith(theMaxValueBlackCard);
        }
    }
}