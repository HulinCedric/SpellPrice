using System.Globalization;
using Xunit;

namespace SpellPrice.Tests.enUS
{
    public class PriceToWordsTest
    {
        [Theory]
        [InlineData(0d, "Zero US dollar")]
        [InlineData(1d, "One US dollar")]
        public void Singular_PriceValue_Should_Give_Singular_CurrencyName(decimal price, string expectedSpelledPrice)
        {
            // Arrange
            var cultureInfo = new CultureInfo("en-US");

            // Act
            var actualSpelledPrice = price.PriceToWords(cultureInfo);

            // Assert
            Assert.Equal(expectedSpelledPrice, actualSpelledPrice);
        }
    }
}