using System;
using System.Collections.Generic;

namespace FizzBuzz
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static List<string> GenerateFizzBuzz()
        {
            var FizzBuzz = new List<string>();

            var index = 1;
            while (index <= 100)
            {
                FizzBuzz.Add(index.ToString());
                index++;
            }

            return FizzBuzz;
        }
    }
}