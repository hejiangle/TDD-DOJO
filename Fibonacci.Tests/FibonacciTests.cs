using System.Numerics;
using Xunit;

namespace Fibonacci.Tests
{
    public class FibonacciTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(29, 514229)]
        [InlineData(43, 433494437)]
        public void ShouldReturnTheSumOfTwoElementsBeforeIndexNumber(int index, BigInteger value)
        {
            Assert.Equal(value, Program.TakeFromFibonacci(index));
        }

        [Fact]
        public void ShouldReturnThe120Value()
        {
            var the120Item = BigInteger.Parse("5358359254990966640871840");

            Assert.Equal(the120Item, Program.TakeFromFibonacci(120));
        }
    }
}