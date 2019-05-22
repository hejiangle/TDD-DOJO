using System.Numerics;
using Xunit;

namespace Fibonacci.Tests
{
    public class FibonacciTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 9)]
        public void ShouldReturnTheSumOfTwoElementsBeforeIndexNumber(int index, BigInteger value)
        {
            Assert.Equal(value, Program.TakeFromFibonacci(index));
        }
    }
}