using Assessment.Factorial;

namespace Assessment.Tests
{
    public class FactorialUnitTests
    {
        [Fact]
        public async Task Factorial_ReturnsArrayOfFactorials_WhenCalled()
        {
            // arrange
            var numbers = new int[] { 1, 2, 3, 4, 5 };
            var expected = new int[] { 1, 2, 6, 24, 120 };

            // act
            var result = await numbers.FactorAsync();
            Assert.Equal(expected, result);

        }

        [Fact]
        public async Task Factorial_ReturnsArrayOfFactorials_WhenCalledWithZero()
        {
            // arrange
            var numbers = new int[] { 0, 1, 2, 3, 4, 5 };
            var expected = new int[] { 1, 1, 2, 6, 24, 120 };

            // act
            var result = await numbers.FactorAsync();
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Factorial_ReturnsArrayOfFactorials_WhenCalledWithNegativeNumbers()
        {
            // arrange
            var numbers = new int[] { -1, -2, -3, -4, -5 };

            // act
            var result = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => numbers.FactorAsync());

            // assert
            Assert.Equal("number", result.ParamName);

        }

        [Fact]
        public async Task Factorial_DoesNotCrash_WhenCalledWithLongArray()
        {
            // arrange
            var numbers = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                numbers[i] = i;
            }

            // use a parrallel for loop to generate the expected result
            var expected = new int[1000];
            Parallel.For(0, 1000, async i =>
            {
                expected[i] = await FactorialExtensions.FactorialOfAsync(i);
            });

            // act
            var result = await numbers.FactorAsync();
            Assert.Equal(expected, result);

        }

    }
}