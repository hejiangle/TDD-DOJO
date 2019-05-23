using static Bridge.Constants.StringConstant;

namespace Bridge.RuleCheckers
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
                
                return string.Format(WHITE_WIN_TEMPLATE, STRAIGHT);
            }

            if (blackCards.IsStraightCards()
                && !whiteCards.IsStraightFlushCards()
                && !whiteCards.IsFourOfAKindCards()
                && !whiteCards.IsFullHouseCards()
                && !whiteCards.IsFlushCards())
            {
                HasResult = true;
                
                return string.Format(BLACK_WIN_TEMPLATE, STRAIGHT);
            }

            return CHEAT;
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