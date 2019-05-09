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
    }
}