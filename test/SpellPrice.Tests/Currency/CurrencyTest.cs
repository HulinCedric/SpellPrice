using Xunit;

namespace SpellPrice.Currency.Tests
{
    public class CurrencyTest
    {
        [Theory]
        [InlineData(CurrencyISOCode.EUR, "Euro")]
        [InlineData(CurrencyISOCode.USD, "US Dollar")]
        public void Currency_Should_Have_EnglishMajorName(CurrencyISOCode currencyISOCode, string expectedEnglishMajorName)
        {
            // Arrange
            var currency = Currency.FromISOCode(currencyISOCode.ToString());

            // Act
            var actualEnglishMajorName = currency.EnglishMajorName;

            // Assert
            Assert.Equal(expectedEnglishMajorName, actualEnglishMajorName);
        }
    }
}