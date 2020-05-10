using Humanizer;
using System;
using System.Globalization;

namespace SpellPrice
{
    internal class NaturalPartPrice
    {
        private readonly CultureInfo cultureInfo;
        private readonly RegionInfo regionInfo;

        public NaturalPartPrice(CultureInfo cultureInfo)
        {
            this.cultureInfo = cultureInfo ?? throw new ArgumentNullException(nameof(cultureInfo));
            this.regionInfo = new RegionInfo(cultureInfo.LCID);
        }

        public string GetPriceToWords(Price price)
        {
            var naturalPartPrice = price.IntegerPartValue;
            var naturalPartPriceToWords = naturalPartPrice.ToWords(cultureInfo);

            var currencyName = GetCurrencyName(naturalPartPrice, regionInfo);

            return $"{naturalPartPriceToWords} {currencyName}";
        }

        private static string GetCurrencyName(int naturalPartPrice, RegionInfo regionInfo)
        {
            var currencyName = regionInfo.CurrencyNativeName;
            if (naturalPartPrice > 1.0m)
            {
                currencyName = currencyName.Pluralize();
            }

            return currencyName;
        }
    }
}