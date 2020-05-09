using Humanizer;
using System;
using System.Globalization;

namespace SpellPrice
{
    public static class PriceExtensions
    {
        public static string PriceToWords(this decimal price, CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
            {
                throw new ArgumentNullException(nameof(cultureInfo));
            }

            var regionInfo = new RegionInfo(cultureInfo.LCID);

            var currencyName = regionInfo.CurrencyNativeName;
            if (price > 1m)
            {
                currencyName = currencyName.Pluralize();
            }

            var integerConvertedPrice = Convert.ToInt32(price);
            var integerConvertedPriceToWords = integerConvertedPrice.ToWords(cultureInfo);

            return $"{integerConvertedPriceToWords} {currencyName}".Humanize(LetterCasing.Sentence);
        }
    }
}