using System.Globalization;
using Xunit;

namespace SpellPrice.Tests.frFR
{
    public class PriceToWordsTest
    {
        [Theory]
        [InlineData(0d, "Zéro euro")]
        [InlineData(1d, "Un euro")]
        public void Singular_PriceValue_Should_Give_Singular_CurrencyName(decimal price, string expectedSpelledPrice)
        {
            // Arrange
            var cultureInfo = new CultureInfo("fr-FR");

            // Act
            var actualSpelledPrice = price.PriceToWords(cultureInfo);

            // Assert
            Assert.Equal(expectedSpelledPrice, actualSpelledPrice);
        }
    }
}