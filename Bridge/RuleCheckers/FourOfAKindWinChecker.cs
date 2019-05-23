using static Bridge.Constants.StringConstant;

namespace Bridge.RuleCheckers
{
    public class FourOfAKindWinChecker : Checker
    {
        public override bool IsCheckingFinished(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (!HasResult && whiteCards.IsFourOfAKindCards() && blackCards.IsFourOfAKindCards())
            {
                Result = CompareSameType(whiteCards, blackCards);
                
            }
            
            if (!HasResult && (whiteCards.IsFourOfAKindCards() || blackCards.IsFourOfAKindCards()))
            {
                Result = DirectlyWin(whiteCards, blackCards);
            }

            return HasResult;
        }

        protected override string DirectlyWin(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            if (whiteCards.IsFourOfAKindCards()
                && !blackCards.IsFourOfAKindCards()
                && !blackCards.IsStraightFlushCards())
            {
                HasResult = true;

                return string.Format(WHITE_WIN_TEMPLATE, FOUR_OF_A_KIND);
            }

            if (blackCards.IsFourOfAKindCards()
                && !whiteCards.IsFourOfAKindCards()
                && !whiteCards.IsStraightFlushCards())
            {
                HasResult = true;

                return string.Format(BLACK_WIN_TEMPLATE, FOUR_OF_A_KIND);
            }

            return TIE;
        }

        protected override string CompareSameType(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            var whiteFullHouseCard = whiteCards.GetSameNumberCardByCount(4);
            var blackFullHouseCard = blackCards.GetSameNumberCardByCount(4);

            var compareResult = whiteFullHouseCard.CompareWith(blackFullHouseCard);

            HasResult = true;
            
            return compareResult.Equals(TIE) ? CHEAT : compareResult;
        }
    }
}