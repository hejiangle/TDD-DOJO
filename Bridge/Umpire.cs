using System;
using System.Collections.Generic;
using System.Linq;

namespace Bridge
{
    public class Umpire
    {
        public string CompareCards(List<string> hardCards_1, List<string> hardCards_2)
        {
            var cards_1 = hardCards_1.Select(Card.Parse).OrderByDescending(card => card.Value).ToList();
            var cards_2 = hardCards_2.Select(Card.Parse).OrderByDescending(card => card.Value).ToList();
            
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