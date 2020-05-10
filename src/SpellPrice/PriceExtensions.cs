using Humanizer;
using System.Globalization;

namespace SpellPrice
{
    public static class PriceExtensions
    {
        public static string PriceToWords(this decimal priceValue, CultureInfo cultureInfo)
        {
            var price = new Price(priceValue);
            var priceFormatter = new PriceFormatter(cultureInfo);

            return priceFormatter.GetPriceToWords(price).Humanize(LetterCasing.Sentence);
        }
    }
}