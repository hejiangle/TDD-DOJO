using System.Collections.Generic;
using System.Linq;
using Bridge.Constants;

namespace Bridge.Models
{
    public class DescendingHandCards
    {
        private readonly List<Card> _DescendingHandCards;
        
        public DescendingHandCards(IEnumerable<string> handCards)
        {
            _DescendingHandCards = handCards.Select(Card.Parse).OrderByDescending(card => card.Value).ToList();
        }

        private DescendingHandCards(IEnumerable<Card> handCards)
        {
            _DescendingHandCards = handCards.ToList();
        }

        public Card GetSameNumberCardByCount(int count)
        {
            return _DescendingHandCards.Find(x => _DescendingHandCards.Count(y => y.Equals(x)) == count);
        }

        public DescendingHandCards GetTwoPairsCards()
        {
            return new DescendingHandCards(
                _DescendingHandCards
                .Where(x => _DescendingHandCards.Count(y => y.Equals(x)) == 2)
                .Distinct());
        }

        public Card GetTheMaxValueCard()
        {
            return _DescendingHandCards.First();
        }

        private Card GetCardByIndex(int index)
        {
            return _DescendingHandCards[index - 1];
        }

        public DescendingHandCards GetSingleCards()
        {
            return new DescendingHandCards(_DescendingHandCards.Where(x => _DescendingHandCards.Count(x.Equals) == 1).ToList());
        }

        public bool IsMessyCards()
        {
            return !IsOnePairCards()
                   && !IsTwoPairsCards()
                   && !IsThreeOfAKindCards()
                   && !IsStraightCards()
                   && !IsFourOfAKindCards()
                   && !IsFlushCards()
                   && !IsStraightFlushCards();
        }

        public bool IsOnePairCards()
        {
            return _DescendingHandCards.Exists(x => _DescendingHandCards.Count(y => y.Equals(x)) == 2)
                && _DescendingHandCards.Distinct().Count() == 4;
        }

        public bool IsTwoPairsCards()
        {
            var index = 0;
            var pairsCount = 0;
            while (index < 4)
            {
                if (_DescendingHandCards[index].Equals(_DescendingHandCards[index + 1]))
                {
                    pairsCount++;
                    index++;
                }

                index++;
            }

            return pairsCount == 2 && _DescendingHandCards.Distinct().Count() == 3;
        }
        
        public bool IsThreeOfAKindCards()
        {
            return _DescendingHandCards.Exists(x => _DescendingHandCards.Count(y => y.Equals(x)) == 3)
                   && _DescendingHandCards.Distinct().Count() == 3;
        }
        
        
        public bool IsStraightCards()
        {
            return _DescendingHandCards.All(card =>
                (card.Value + _DescendingHandCards.IndexOf(card)).Equals(_DescendingHandCards.First().Value))
                && _DescendingHandCards.Exists(card => !card.Suit.Equals(_DescendingHandCards.First().Suit));
        }

        public bool IsFlushCards()
        {
            return _DescendingHandCards.Exists(
                       card => !(card.Value + _DescendingHandCards.IndexOf(card))
                                     .Equals(_DescendingHandCards.First().Value))
                && _DescendingHandCards.All(card => card.Suit.Equals(_DescendingHandCards.First().Suit));
        }

        public bool IsFullHouseCards()
        {
            return _DescendingHandCards.Exists(x => _DescendingHandCards.Count(y => y.Equals(x)) == 3)
                && _DescendingHandCards.Exists(x => _DescendingHandCards.Count(y => y.Equals(x)) == 2);
        }

        public bool IsFourOfAKindCards()
        {
            return _DescendingHandCards.Exists(x => _DescendingHandCards.Count(y => y.Equals(x)) == 4);
        }

        public bool IsStraightFlushCards()
        {
            return _DescendingHandCards.All(card => card.Suit.Equals(_DescendingHandCards.First().Suit))
                && _DescendingHandCards.All(card =>
                    (card.Value + _DescendingHandCards.IndexOf(card)).Equals(_DescendingHandCards.First().Value));
        }

        public string CompareWith(DescendingHandCards other)
        {
            var index = 1;
            
            while (index <= _DescendingHandCards.Count)
            {
                var thisCard = GetCardByIndex(index);
                var otherCard = other.GetCardByIndex(index);
                
                var compareResult = thisCard.CompareWith(otherCard);

                if (!compareResult.Equals(StringConstant.TIE))
                {
                    return compareResult;
                }

                index++;
            }

            return StringConstant.TIE;
        }
    }
}