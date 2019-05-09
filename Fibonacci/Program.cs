using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Fibonacci
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static BigInteger TakeFromFibonacci(int index)
        {
            var baseFibonacci = new List<BigInteger> {1, 1};

            while (baseFibonacci.Count < index)
            {
                baseFibonacci = Extend(baseFibonacci);
            }
            
            return baseFibonacci[index-1];
        }

        private static List<BigInteger> Extend(List<BigInteger> baseFibonacci)
        {
            var lastItem = baseFibonacci.Last();
            var lastSecondItem = baseFibonacci[baseFibonacci.Count-2];
            baseFibonacci.Add(lastItem + lastSecondItem);

            return baseFibonacci;
        }
    }
}