using Xunit;

namespace SpellPrice.Tests
{
    public class PriceToWordsTest
    {
        [Theory]
        [InlineData(0d, "Zero US dollar")]
        [InlineData(1d, "One US dollar")]
        public void Singular_PriceValue_Should_Give_Singular_CurrencyName(decimal price, string expectedSpelledPrice)
        {
            // Act
            var actualSpelledPrice = price.PriceToWords();

            // Assert
            Assert.Equal(expectedSpelledPrice, actualSpelledPrice);
        }
    }
}
