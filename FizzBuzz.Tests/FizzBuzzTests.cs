using System.Linq;
using Xunit;

namespace FizzBuzz.Tests
{
    public class FizzBuzzTests
    {
        [Fact]
        public void ShouldReturn100ItemsList()
        {
            var result = Program.GenerateFizzBuzz();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(100, result.Count);
        }

        [Fact]
        public void ShouldUseFizzReplaceMultipleOfThree()
        {
            var result = Program.GenerateFizzBuzz();

            Assert.Contains("Fizz", result);
            Assert.True(result.Where(item => result.IndexOf(item)%3 == 0).All(item => item.Contains("Fizz")));
        }
    }
}