using System;
using System.Collections.Generic;
using System.Linq;
using Bridge.Models;

namespace Bridge
{
    public class Umpire
    {
        private List<string> _whiteHandCards;
        private List<string> _blackHandCards;
        
        public void SaySomething()
        {
            Console.WriteLine("Hi, I'm clever umpire! please give me both of your hand cards.");
            Console.WriteLine("Then I will tell you who is the winner!");
        }

        public void ReadWhiteCards()
        {
            Console.WriteLine("Now give me the white player's cards:");
            _whiteHandCards = Console.ReadLine()?.Split(' ').ToList();
        }
        
        public void ReadBlackCards()
        {
            Console.WriteLine("then please give me the black player's cards:");
            _blackHandCards = Console.ReadLine()?.Split(' ').ToList();
        }
        
        public string CompareCards()
        {
            var whiteCards = new DescendingHandCards(_whiteHandCards);
            var blackCards = new DescendingHandCards(_blackHandCards);

            return CheckerFactory.LaunchAllCheckers().Check(whiteCards, blackCards);
        }

        public string CompareCards(List<string> whiteHandCards, List<string> blackHandCards)
        {
            var whiteCards = new DescendingHandCards(whiteHandCards);
            var blackCards = new DescendingHandCards(blackHandCards);

            return CheckerFactory.LaunchAllCheckers().Check(whiteCards, blackCards);
        }

        public void AnnounceTheWinner()
        {
            Console.WriteLine(CompareCards());
        }


    }
}