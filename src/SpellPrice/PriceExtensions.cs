using Humanizer;
using System;
using System.Globalization;

namespace SpellPrice
{
    public static class PriceExtensions
    {
        public static string PriceToWords(this decimal price, CultureInfo cultureInfo)
        {
            var naturalPartPriceToWords = GetNaturalPartPrice(price, cultureInfo);

            return $"{naturalPartPriceToWords}".Humanize(LetterCasing.Sentence);
        }

        private static string GetCurrencyName(decimal price, RegionInfo regionInfo)
        {
            var currencyName = regionInfo.CurrencyNativeName;
            if (price > 1m)
            {
                currencyName = currencyName.Pluralize();
            }

            return currencyName;
        }

        private static string GetNaturalPartPrice(this decimal price, CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
            {
                throw new ArgumentNullException(nameof(cultureInfo));
            }

            var regionInfo = new RegionInfo(cultureInfo.LCID);

            var naturalPartPrice = (int)Math.Truncate(price);
            var naturalPartPriceToWords = naturalPartPrice.ToWords(cultureInfo);

            var currencyName = GetCurrencyName(price, regionInfo);

            return $"{naturalPartPriceToWords} {currencyName}";
        }
    }
}