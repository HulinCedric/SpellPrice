using System;
using System.Globalization;
using Humanizer;

namespace SpellPrice
{
    internal class FractionnalPartPrice
    {
        private readonly CultureInfo cultureInfo;

        public FractionnalPartPrice(CultureInfo cultureInfo)
        {
            this.cultureInfo = cultureInfo ?? throw new ArgumentNullException(nameof(cultureInfo));
        }

        public string GetPriceToWords(decimal price)
        {
            var fractionnalPartPrice = price.GetFractionnalPart();
            var fractionnalPartPriceToWords = fractionnalPartPrice.ToWords(cultureInfo);

            var currencyCentName = "centime";

            return $"{fractionnalPartPriceToWords} {currencyCentName}";
        }
    }
}