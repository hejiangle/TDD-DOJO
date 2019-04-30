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
            Assert.True(result.Where(item => (result.IndexOf(item) + 1) % 3 == 0).All(item => item.Contains("Fizz")));
        }

        [Fact]
        public void ShouldUseBuzzReplaceMultipleOfFive()
        {
            var result = Program.GenerateFizzBuzz();

            Assert.Contains("Buzz", result);
            Assert.True(result.Where(item => (result.IndexOf(item) + 1) % 5 == 0).All(item => item.Contains("Buzz")));
        }

        [Fact]
        public void ShouldUseFizzBuzzReplaceMultipleOfThreeAndFive()
        {
            var result = Program.GenerateFizzBuzz();

            Assert.Contains("Buzz", result);
            Assert.True(
                result.Where(item => (result.IndexOf(item) + 1) % 5 == 0)
                      .Where(item => (result.IndexOf(item) + 1) % 3 == 0)
                      .All(item => item.Contains("FizzBuzz")));
        }

        [Fact]
        public void ShouldUseFizzReplaceTheIndexIncludingThree()
        {
            var result = Program.GenerateFizzBuzz();

            Assert.Contains("Fizz", result);
            Assert.True(result.Where(item => item.Contains("3")).All(item => item.Contains("Fizz")));
        }
    }
}