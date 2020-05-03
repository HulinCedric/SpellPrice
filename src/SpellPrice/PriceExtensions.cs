using System;
using System.Globalization;
using Humanizer;

namespace SpellPrice
{
    public static class PriceExtensions
    {
        public static string PriceToWords(this decimal price)
        {
            var currencyName = new RegionInfo("US").CurrencyNativeName;

            var integerConvertedPrice = Convert.ToInt32(price);
            var integerConvertedPriceToWords = integerConvertedPrice.ToWords();

            return $"{integerConvertedPriceToWords} {currencyName}".Humanize(LetterCasing.Sentence);
        }
    }
}
