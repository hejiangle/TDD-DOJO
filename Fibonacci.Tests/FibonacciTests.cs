using System.Numerics;
using Xunit;

namespace Fibonacci.Tests
{
    public class FibonacciTests
    {
        [Fact]
        public void ShouldReturn1WhenGetTheFirstElement()
        {
            Assert.Equal(1, Program.TakeFromFibonacci(1));
        }

        [Fact]
        public void ShouldReturn1WhenGetTheSecondElement()
        {
            Assert.Equal(1, Program.TakeFromFibonacci(2));
        }

        [Fact]
        public void ShouldReturnTheSumOfTwoElementsBeforeIndexNumber()
        {
            Assert.Equal(2, Program.TakeFromFibonacci(3));
        }

        [Fact]
        public void ShouldReturnThe120Value()
        {
            var the120Item = BigInteger.Parse("5358359254990966640871840");

            Assert.Equal(the120Item, Program.TakeFromFibonacci(120));
        }
    }
}