using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bridge
{
    public class Umpire
    {
        private const string WHITE_WIN_TEMPLATE = "White wins - {0}";
        private const string BLACK_WIN_TEMPLATE = "Black wins - {0}";
        
        public string CompareCards(List<string> whiteHandCards, List<string> blackHandCards)
        {
            var whiteCards = whiteHandCards.Select(Card.Parse).OrderByDescending(card => card.Value).ToList();
            var blackCards = blackHandCards.Select(Card.Parse).OrderByDescending(card => card.Value).ToList();
            
            var highCard = string.Empty;
            if (IsMessyCards(whiteCards) && IsMessyCards(blackCards))
            {
                highCard = CompareMessyCards(whiteCards, blackCards, 5);
            }

            if (IsOnePairCards(whiteCards) && IsMessyCards(blackCards))
            {
                highCard = string.Format(WHITE_WIN_TEMPLATE, "Pair");
            }

            if (IsMessyCards(whiteCards) && IsOnePairCards(blackCards))
            {
                highCard = string.Format(BLACK_WIN_TEMPLATE, "Pair");
            }

            if (IsOnePairCards(whiteCards) && IsOnePairCards(blackCards))
            {
                var whitePair = whiteCards.Find(x => whiteCards.Count(y => y.Number.Equals(x.Number)) == 2);
                var blackPair = blackCards.Find(x => blackCards.Count(y => y.Number.Equals(x.Number)) == 2);

                var compareResult = whitePair.CompareTo(blackPair);

                if (compareResult > 0)
                {
                    highCard = whitePair.Number.ToString();
                }

                if (compareResult < 0)
                {
                    highCard = blackPair.Number.ToString();
                }

                if (compareResult == 0)
                {
                    whiteCards.RemoveAll(card => card.Equals(whitePair));
                    blackCards.RemoveAll(card => card.Equals(blackPair));
                    highCard = CompareMessyCards(whiteCards, blackCards, 3);
                }
            }

            return highCard;
        }

        private static string CompareMessyCards(List<Card> whiteCards, List<Card> blackCards, int cardCounts)
        {
            var index = 0;
            var highCard = string.Empty;
            
            while (index < cardCounts)
            {
                var compareResult = whiteCards[index].CompareTo(blackCards[index]);

                if (compareResult > 0)
                {
                    highCard = whiteCards[index].Number.ToString();
                    break;
                }

                if (compareResult < 0)
                {
                    highCard = blackCards[index].Number.ToString();
                    break;
                }

                index++;
            }

            return highCard;
        }

        private bool IsMessyCards(List<Card> hardCards)
        {
            return !IsOnePairCards(hardCards);
        }

        private bool IsOnePairCards(List<Card> hardCards)
        {
            return hardCards.Distinct().Count() == 4;
        }
    }
}