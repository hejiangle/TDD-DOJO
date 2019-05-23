using static Bridge.Constants.StringConstant;

namespace Bridge.RuleCheckers
{
    public class StraightWinChecker
    {
        public string DirectlyWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (whiteCards.IsStraightCards()
                && !blackCards.IsStraightFlushCards()
                && !blackCards.IsFourOfAKindCards()
                && !blackCards.IsFullHouseCards()
                && !blackCards.IsFlushCards())
            {
                return string.Format(WHITE_WIN_TEMPLATE, STRAIGHT);
            }

            if (blackCards.IsStraightCards()
                && !whiteCards.IsStraightFlushCards()
                && !whiteCards.IsFourOfAKindCards()
                && !whiteCards.IsFullHouseCards()
                && !whiteCards.IsFlushCards())
            {
                return string.Format(BLACK_WIN_TEMPLATE, STRAIGHT);
            }

            return CHEAT;
        }

        public string CompareSameType(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            var theMaxValueWhiteCard = whiteCards.GetTheMaxValueCard();
            var theMaxValueBlackCard = blackCards.GetTheMaxValueCard();

            return theMaxValueWhiteCard.CompareWith(theMaxValueBlackCard);
        }
    }
}