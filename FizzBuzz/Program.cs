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
                if (!(IsMultipleOfThree(index) || IsHasThree(index)) && !(IsMultipleOfFive(index) || IsHasFive(index)))
                {
                    FizzBuzz.Add(index.ToString());
                    index++;
                    continue;
                }

                if ((IsMultipleOfThree(index) || IsHasThree(index)) && (IsMultipleOfFive(index) || IsHasFive(index)))
                {
                    FizzBuzz.Add("FizzBuzz");
                    index++;
                    continue;
                }

                if (IsMultipleOfThree(index) || IsHasThree(index))
                {
                    FizzBuzz.Add("Fizz");
                }

                if (IsMultipleOfFive(index) || IsHasFive(index))
                {
                    FizzBuzz.Add("Buzz");
                }

                index++;
            }

            return FizzBuzz;
        }

        private static bool IsMultipleOfThree(int index)
        {
            return index % 3 == 0;
        }

        private static bool IsMultipleOfFive(int index)
        {
            return index % 5 == 0;
        }

        private static bool IsHasThree(int index)
        {
            return index.ToString().Contains("3");
        }

        private static bool IsHasFive(int index)
        {
            return index.ToString().Contains("5");
        }
    }
}