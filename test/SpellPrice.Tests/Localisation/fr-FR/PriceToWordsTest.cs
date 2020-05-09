using System.Globalization;
using Xunit;

namespace SpellPrice.Tests.frFR
{
    public class PriceToWordsTest
    {
        [Theory]
        [InlineData(2d, "Deux euros")]
        [InlineData(3d, "Trois euros")]
        public void Over_One_PriceValue_Should_Give_Pluralize_CurrencyName(decimal price, string expectedSpelledPrice)
        {
            // Arrange
            var cultureInfo = GetCultureInfo();

            // Act
            var actualSpelledPrice = price.PriceToWords(cultureInfo);

            // Assert
            Assert.Equal(expectedSpelledPrice, actualSpelledPrice);
        }

        [Theory]
        [InlineData(0d, "Zéro euro")]
        [InlineData(1d, "Un euro")]
        public void Singular_PriceValue_Should_Give_Singular_CurrencyName(decimal price, string expectedSpelledPrice)
        {
            // Arrange
            var cultureInfo = GetCultureInfo();

            // Act
            var actualSpelledPrice = price.PriceToWords(cultureInfo);

            // Assert
            Assert.Equal(expectedSpelledPrice, actualSpelledPrice);
        }

        [Theory]
        [InlineData(0.1d, "Zéro euro et un centime")]
        [InlineData(3.1d, "Trois euros et un centime")]
        public void Non_Rounded_Singular_Cent_PriceValue_Should_Give_Singular_CurrencyCentName(decimal price, string expectedSpelledPrice)
        {
            // Arrange
            var cultureInfo = GetCultureInfo();

            // Act
            var actualSpelledPrice = price.PriceToWords(cultureInfo);

            // Assert
            Assert.Equal(expectedSpelledPrice, actualSpelledPrice);
        }

        private static CultureInfo GetCultureInfo()
            => new CultureInfo("fr-FR");
    }
}