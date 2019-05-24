using System;
using System.Collections.Generic;
using System.Linq;
using Bridge.Models;
using static Bridge.Constants.StringConstant;

namespace Bridge
{
    public class Umpire
    {
        private List<string> _whiteHandCards;
        private List<string> _blackHandCards;
        
        public void SaySomething()
        {
            Console.WriteLine(WELCOME_MESSAGE);
            Console.WriteLine(UMPIRE_JOB);
        }

        public void ReadWhiteCards(List<string> whitHandCars = null)
        {
            Console.WriteLine(INPUT_WHITE_CARDS);
            _whiteHandCards = whitHandCars ?? Console.ReadLine()?.Split(' ').ToList();
        }
        
        public void ReadBlackCards(List<string> blackHandCars = null)
        {
            Console.WriteLine(INPUT_BLACK_CARDS);
            _blackHandCards = blackHandCars ?? Console.ReadLine()?.Split(' ').ToList();
        }
        
        public string CompareCards()
        {
            var whiteCards = new DescendingHandCards(_whiteHandCards);
            var blackCards = new DescendingHandCards(_blackHandCards);

            return CheckerFactory.LaunchAllCheckers().Check(whiteCards, blackCards);
        }

        public void AnnounceTheWinner()
        {
            Console.WriteLine(CompareCards());
        }
    }
}