using Xunit;

namespace Fibonacci.Tests
{
    public class FibonacciTests
    {
        [Fact]
        public void ShouldReturn1WhenGetTheFirstElement()
        {
            var result = Program.TakeFromFibonacci(1);

            Assert.Equal(1, result);
        }
    }
}