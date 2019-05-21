using System;
using System.Collections.Generic;
using System.Linq;

namespace Bridge
{
    public class Umpire
    {
        public string CompareCards(List<string> handCards_1, List<string> handCards_2)
        {
            var cards_1 = handCards_1.Select(Card.Parse).OrderByDescending(card => card.Value).ToList();
            var cards_2 = handCards_2.Select(Card.Parse).OrderByDescending(card => card.Value).ToList();
            
            var highCard = string.Empty;
            if (IsMessyCards(cards_1) && IsMessyCards(cards_2))
            {
                var index = 0;
                while (index < 5)
                {
                    var compareResult = cards_1[index].CompareTo(cards_2[index]);

                    if (compareResult > 0)
                    {
                        highCard = cards_1[index].Number.ToString();
                        break;
                    }

                    if (compareResult < 0)
                    {
                        highCard = cards_2[index].Number.ToString();
                        break;
                    }

                    index++;
                }
            }

            return highCard;
        }

        private bool IsMessyCards(List<Card> hardCards)
        {
            return true;
        }
    }
}