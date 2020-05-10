using System;
using Xunit;

namespace SpellPrice.Currency.Tests
{
    public class InvalidCurrencyTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("eur")]
        [InlineData("EUR ")]
        public void Invalid_CurrencyISOCode_Should_Throws_InvalidOperationException(string invalidCurrencyISOCode)
        {
            // Act
            void act() => Currency.FromISOCode(invalidCurrencyISOCode);

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }
    }
}