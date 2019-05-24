using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Bridge.Exceptions;
using Bridge.Models;
using static Bridge.Constants.StringConstant;

namespace Bridge
{
    public class Umpire
    {
        private DescendingHandCards _whiteHandCards;
        private DescendingHandCards _blackHandCards;
        
        public void SaySomething()
        {
            Console.WriteLine(WELCOME_MESSAGE);
            Console.WriteLine(UMPIRE_JOB);
        }

        public void ReadWhiteCards(List<string> whitHandCars = null)
        {
            Console.WriteLine(INPUT_WHITE_CARDS);
            var gotThem = whitHandCars ?? Console.ReadLine()?.Split(' ').ToList();

            try
            {
                _whiteHandCards = new DescendingHandCards(gotThem);
            }
            catch (IsNotCardException e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }
        
        public void ReadBlackCards(List<string> blackHandCars = null)
        {
            Console.WriteLine(INPUT_BLACK_CARDS);
            var gotThem = blackHandCars ?? Console.ReadLine()?.Split(' ').ToList();
            try
            {
                _blackHandCards = new DescendingHandCards(gotThem);
            }
            catch (IsNotCardException e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }
        
        public string CompareCards()
        {

            return CheckerFactory.LaunchAllCheckers().Check(_whiteHandCards, _blackHandCards);
        }

        public void AnnounceTheWinner()
        {
            Console.WriteLine(CompareCards());
        }
    }
}