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

        public string GetPriceToWords(Price price)
        {
            var fractionnalPartPrice = price.FractionalPartValue;
            var fractionnalPartPriceToWords = fractionnalPartPrice.ToWords(cultureInfo);

            var currencyCentName = "centime";

            return $"{fractionnalPartPriceToWords} {currencyCentName}";
        }
    }
}