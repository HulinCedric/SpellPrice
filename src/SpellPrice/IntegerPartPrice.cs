using Humanizer;
using System;
using System.Globalization;

namespace SpellPrice
{
    internal class IntegerPartPrice
    {
        private readonly CultureInfo cultureInfo;
        private readonly RegionInfo regionInfo;

        public IntegerPartPrice(CultureInfo cultureInfo)
        {
            this.cultureInfo = cultureInfo ?? throw new ArgumentNullException(nameof(cultureInfo));
            this.regionInfo = new RegionInfo(cultureInfo.LCID);
        }

        public string GetPriceToWords(Price price)
        {
            var integerPartPrice = price.IntegerPartValue;
            var integerPartPriceToWords = integerPartPrice.ToWords(cultureInfo);

            var currencyName = GetCurrencyName(integerPartPrice, regionInfo);

            return $"{integerPartPriceToWords} {currencyName}";
        }

        private static string GetCurrencyName(int integerPartPrice, RegionInfo regionInfo)
        {
            var currencyName = regionInfo.CurrencyNativeName;
            if (integerPartPrice > 1.0m)
            {
                currencyName = currencyName.Pluralize();
            }

            return currencyName;
        }
    }
}