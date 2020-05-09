using System;
using System.Globalization;
using System.Linq;
using Xunit;

namespace SpellPrice.Tests
{
    public class InvalidCultureInfoTest
    {
        [Fact]
        public void Invariant_CultureInfo_Throws_ArgumentException()
        {
            // Arrange
            var invariantCultureInfo = CultureInfo.InvariantCulture;
            var randomNumber = decimal.Zero;

            // Act
            void act() => randomNumber.PriceToWords(invariantCultureInfo);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Neutral_CultureInfo_Throws_ArgumentException()
        {
            // Arrange
            var neutralCultureInfo = CultureInfo.GetCultures(CultureTypes.NeutralCultures).First();
            var randomNumber = decimal.Zero;

            // Act
            void act() => randomNumber.PriceToWords(neutralCultureInfo);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Null_CultureInfo_Throws_ArgumentNullException()
        {
            // Arrange
            CultureInfo nullCultureInfo = null;
            var randomNumber = decimal.Zero;

            // Act
            void act() => randomNumber.PriceToWords(nullCultureInfo);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }
    }
}