using System.Collections.Generic;
using Bridge.RuleCheckers;

namespace Bridge
{
    public class Umpire
    {
        private readonly StraightFlushWinChecker _straightFlushWinChecker;
        private readonly FourOfAKindWinChecker _fourOfAKindWinChecker;
        private readonly FullHouseWinChecker _fullHouseWinChecker;
        private readonly FlushWinChecker _flushWinChecker;
        private readonly StraightWinChecker _straightWinChecker;
        private readonly ThreeOfAKindWinChecker _threeOfAKindWinChecker;
        private readonly DoublePairsWinChecker _doublePairsWinChecker;
        private readonly OnePairWinChecker _onePairWinChecker;

        public Umpire(
            StraightFlushWinChecker straightFlushWinChecker,
            FourOfAKindWinChecker fourOfAKindWinChecker,
            FullHouseWinChecker fullHouseWinChecker,
            FlushWinChecker flushWinChecker,
            StraightWinChecker straightWinChecker,
            ThreeOfAKindWinChecker threeOfAKindWinChecker,
            DoublePairsWinChecker doublePairsWinChecker, OnePairWinChecker onePairWinChecker)
        {
            _straightFlushWinChecker = straightFlushWinChecker;
            _fourOfAKindWinChecker = fourOfAKindWinChecker;
            _fullHouseWinChecker = fullHouseWinChecker;
            _flushWinChecker = flushWinChecker;
            _straightWinChecker = straightWinChecker;
            _threeOfAKindWinChecker = threeOfAKindWinChecker;
            _doublePairsWinChecker = doublePairsWinChecker;
            _onePairWinChecker = onePairWinChecker;
        }

        public string CompareCards(List<string> whiteHandCards, List<string> blackHandCards)
        {
            var whiteCards = new DescendingHandCards(whiteHandCards);
            var blackCards = new DescendingHandCards(blackHandCards);

            if (whiteCards.IsStraightFlushCards() && blackCards.IsStraightFlushCards())
            {
                return _straightWinChecker.CompareSameType(whiteCards, blackCards);
            }
            if (whiteCards.IsStraightFlushCards() || blackCards.IsStraightFlushCards())
            {
                return _straightFlushWinChecker.DirectlyWin(whiteCards, blackCards);
            }

            if (whiteCards.IsFourOfAKindCards() && blackCards.IsFourOfAKindCards())
            {
                return _fourOfAKindWinChecker.CompareSameType(whiteCards, blackCards);
            }
            if (whiteCards.IsFourOfAKindCards() || blackCards.IsFourOfAKindCards())
            {
                return _fourOfAKindWinChecker.DirectlyWin(whiteCards, blackCards);
            }

            if (whiteCards.IsFullHouseCards() && blackCards.IsFullHouseCards())
            {
                return _fullHouseWinChecker.CompareSameType(whiteCards, blackCards);
            }
            if (whiteCards.IsFullHouseCards() || blackCards.IsFullHouseCards())
            {
                return _fullHouseWinChecker.DirectlyWin(whiteCards, blackCards);
            }

            if (whiteCards.IsFlushCards() && blackCards.IsFlushCards())
            {
                return whiteCards.CompareWith(blackCards);
            }
            if (whiteCards.IsFlushCards() || blackCards.IsFlushCards())
            {
                return _flushWinChecker.DirectlyWin(whiteCards, blackCards);
            }

            if (whiteCards.IsStraightCards() && blackCards.IsStraightCards())
            {
                return _straightWinChecker.CompareSameType(whiteCards, blackCards);
            }
            if (whiteCards.IsStraightCards() || blackCards.IsStraightCards())
            {
                return _straightWinChecker.DirectlyWin(whiteCards, blackCards);
            }

            if (whiteCards.IsThreeOfAKindCards() && blackCards.IsThreeOfAKindCards())
            {
                return _threeOfAKindWinChecker.CompareSameType(whiteCards, blackCards);
            }
            if (whiteCards.IsThreeOfAKindCards() && blackCards.IsThreeOfAKindCards())
            {
                return _threeOfAKindWinChecker.DirectlyWin(whiteCards, blackCards);
            }

            if (whiteCards.IsTwoPairsCards() && blackCards.IsTwoPairsCards())
            {
                return _doublePairsWinChecker.CompareSameType(whiteCards, blackCards);
            }
            if (whiteCards.IsTwoPairsCards() || blackCards.IsTwoPairsCards())
            {
                return _doublePairsWinChecker.DirectlyWin(whiteCards, blackCards);
            }

            if (whiteCards.IsOnePairCards() && blackCards.IsOnePairCards())
            {
                return _onePairWinChecker.CompareSameType(whiteCards, blackCards);
            }
            if (whiteCards.IsOnePairCards() || blackCards.IsOnePairCards())
            {
                return _onePairWinChecker.DirectlyWin(whiteCards, blackCards);
            }

            return whiteCards.CompareWith(blackCards);
        }

        
    }
}