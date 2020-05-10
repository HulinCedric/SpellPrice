using Humanizer;
using System;
using System.Globalization;

namespace SpellPrice
{
    internal class FractionalPartPrice
    {
        private readonly CultureInfo cultureInfo;

        public FractionalPartPrice(CultureInfo cultureInfo)
        {
            this.cultureInfo = cultureInfo ?? throw new ArgumentNullException(nameof(cultureInfo));
        }

        public string GetPriceToWords(Price price)
        {
            var fractionalPartPrice = price.FractionalPartValue;
            var fractionalPartPriceToWords = fractionalPartPrice.ToWords(cultureInfo);

            var currencyCentName = "centime";

            return $"{fractionalPartPriceToWords} {currencyCentName}";
        }
    }
}