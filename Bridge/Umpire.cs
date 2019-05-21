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
            
            if (IsDoublePairsCards(whiteCards) && IsDoublePairsCards(blackCards))
            {
                return CompareDoublePairsHandCards(whiteCards, blackCards);
            }
            if (IsDoublePairsCards(whiteCards) || IsDoublePairsCards(blackCards))
            {
                return DoublePairsWin(whiteCards, blackCards);
            }

            if (IsOnePairCards(whiteCards) && IsOnePairCards(blackCards))
            {
                return CompareOnePairHandCards(whiteCards, blackCards);
            }
            if (IsOnePairCards(whiteCards) || IsOnePairCards(blackCards))
            {
                return OnePairWin(whiteCards, blackCards);
            }

            return CompareMessyCards(whiteCards, blackCards, 5);
        }

        private string CompareDoublePairsHandCards(List<Card> whiteCards, List<Card> blackCards)
        {
            var whitePairs = whiteCards
                .Where(x => whiteCards.Count(y => y.Number.Equals(x.Number)) == 2)
                .Distinct()
                .ToList();
            var blackPairs = blackCards
                .Where(x => blackCards.Count(y => y.Number.Equals(x.Number)) == 2)
                .Distinct()
                .ToList();

            var highCard = CompareMessyCards(whitePairs, blackPairs, 2);

            if (highCard.Equals("Tie"))
            {
                var singleWhiteCard = whiteCards.Where(x => !whitePairs.Exists(x.Equals)).ToList();
                var singleBlackCard = blackCards.Where(x => !blackPairs.Exists(x.Equals)).ToList();

                highCard = CompareMessyCards(singleWhiteCard, singleBlackCard, 1);
            }

            return highCard;
        }

        private string DoublePairsWin(List<Card> whiteCards, List<Card> blackCards)
        {
            if (IsDoublePairsCards(whiteCards) && IsMessyCards(blackCards)
                || IsDoublePairsCards(whiteCards) && IsOnePairCards(blackCards))
            {
                return string.Format(WHITE_WIN_TEMPLATE, "Double Pair");
            }

            if (IsMessyCards(whiteCards) && IsDoublePairsCards(blackCards)
                || IsOnePairCards(whiteCards) && IsDoublePairsCards(blackCards))
            {
                 return string.Format(BLACK_WIN_TEMPLATE, "Double Pair");
            }

            return "Tie";
        }

        private static string CompareOnePairHandCards(List<Card> whiteCards, List<Card> blackCards)
        {
            var whitePair = whiteCards.Find(x => whiteCards.Count(y => y.Number.Equals(x.Number)) == 2);
            var blackPair = blackCards.Find(x => blackCards.Count(y => y.Number.Equals(x.Number)) == 2);

            var compareResult = whitePair.CompareTo(blackPair);
            var highCard = "Tie";

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

            return highCard;
        }

        private string OnePairWin(List<Card> whiteCards, List<Card> blackCards)
        {
            if (IsOnePairCards(whiteCards) && IsMessyCards(blackCards))
            {
                return string.Format(WHITE_WIN_TEMPLATE, "Pair");
            }

            if (IsMessyCards(whiteCards) && IsOnePairCards(blackCards))
            {
                return string.Format(BLACK_WIN_TEMPLATE, "Pair");
            }

            return "Tie";
        }

        private static string CompareMessyCards(List<Card> whiteCards, List<Card> blackCards, int cardCounts)
        {
            var index = 0;
            var highCard = "Tie";
            
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
            return !IsOnePairCards(hardCards) && !IsDoublePairsCards(hardCards);
        }

        private bool IsOnePairCards(List<Card> hardCards)
        {
            return hardCards.Distinct().Count() == 4;
        }

        private bool IsDoublePairsCards(List<Card> hardCards)
        {
            var index = 0;
            var pairsCount = 0;
            while (index < 4)
            {
                if (hardCards[index].Equals(hardCards[index + 1]))
                {
                    pairsCount++;
                    index++;
                }

                index++;
            }

            return pairsCount == 2 && hardCards.Distinct().Count() == 3;
        }
    }
}