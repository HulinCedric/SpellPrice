using System.Globalization;
using Xunit;

namespace SpellPrice.Tests.enUS
{
    public class PriceToWordsTest
    {
        [Theory]
        [InlineData(2d, "Two US dollars")]
        [InlineData(3d, "Three US dollars")]
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
        [InlineData(0d, "Zero US dollar")]
        [InlineData(1d, "One US dollar")]
        public void Singular_PriceValue_Should_Give_Singular_CurrencyName(decimal price, string expectedSpelledPrice)
        {
            // Arrange
            var cultureInfo = GetCultureInfo();

            // Act
            var actualSpelledPrice = price.PriceToWords(cultureInfo);

            // Assert
            Assert.Equal(expectedSpelledPrice, actualSpelledPrice);
        }

        private CultureInfo GetCultureInfo()
            => new CultureInfo("en-US");
    }
}