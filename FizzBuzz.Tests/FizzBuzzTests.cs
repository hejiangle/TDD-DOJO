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
    }
}