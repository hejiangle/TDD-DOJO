using System.Collections.Generic;
using Bridge.Models;

namespace Bridge
{
    public class Umpire
    {
        public string CompareCards(List<string> whiteHandCards, List<string> blackHandCards)
        {
            var whiteCards = new DescendingHandCards(whiteHandCards);
            var blackCards = new DescendingHandCards(blackHandCards);

            return CheckerFactory.LaunchAllCheckers().Check(whiteCards, blackCards);
        }

        
    }
}