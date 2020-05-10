using Xunit;

namespace SpellPrice.Tests
{
    public class PriceTest
    {
        [Theory]
        [InlineData(0.0, 0)]
        [InlineData(0.1, 1)]
        [InlineData(0.2, 2)]
        [InlineData(0.3, 3)]
        [InlineData(0.4, 4)]
        [InlineData(0.5, 5)]
        [InlineData(0.6, 6)]
        [InlineData(0.7, 7)]
        [InlineData(0.8, 8)]
        [InlineData(0.9, 9)]
        [InlineData(1.0, 0)]
        [InlineData(1.1, 1)]
        [InlineData(1.2, 2)]
        [InlineData(1.3, 3)]
        [InlineData(1.4, 4)]
        [InlineData(1.5, 5)]
        [InlineData(1.6, 6)]
        [InlineData(1.7, 7)]
        [InlineData(1.8, 8)]
        [InlineData(1.9, 9)]
        public void Price_Should_Have_FractionalPart(decimal priceValue, int expectedFractionalPartPriceValue)
        {
            // Arrange
            var price = GetPrice(priceValue);

            // Act
            var actualFractionalPartPriceValue = price.FractionalPartValue;

            // Assert
            Assert.Equal(expectedFractionalPartPriceValue, actualFractionalPartPriceValue);
        }

        [Theory]
        [InlineData(0.0, 0)]
        [InlineData(0.1, 0)]
        [InlineData(0.2, 0)]
        [InlineData(0.3, 0)]
        [InlineData(0.4, 0)]
        [InlineData(0.5, 0)]
        [InlineData(0.6, 0)]
        [InlineData(0.7, 0)]
        [InlineData(0.8, 0)]
        [InlineData(0.9, 0)]
        [InlineData(1.0, 1)]
        [InlineData(1.1, 1)]
        [InlineData(1.2, 1)]
        [InlineData(1.3, 1)]
        [InlineData(1.4, 1)]
        [InlineData(1.5, 1)]
        [InlineData(1.6, 1)]
        [InlineData(1.7, 1)]
        [InlineData(1.8, 1)]
        [InlineData(1.9, 1)]
        public void Price_Should_Have_IntegerPart(decimal priceValue, int expectedIntegerPartPriceValue)
        {
            // Arrange
            var price = GetPrice(priceValue);

            // Act
            var actualIntegerPartPriceValue = price.IntegerPartValue;

            // Assert
            Assert.Equal(expectedIntegerPartPriceValue, actualIntegerPartPriceValue);
        }

        private static Price GetPrice(decimal priceValue)
            => new Price(priceValue);
    }
}