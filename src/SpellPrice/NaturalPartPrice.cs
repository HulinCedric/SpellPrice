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

        public string GetPriceToWords(decimal price)
        {
            var naturalPartPrice = price.GetIntegerPart();
            var naturalPartPriceToWords = naturalPartPrice.ToWords(cultureInfo);

            var currencyName = GetCurrencyName(price, regionInfo);

            return $"{naturalPartPriceToWords} {currencyName}";
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
    }
}