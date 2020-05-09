using Humanizer;
using System.Globalization;

namespace SpellPrice
{
    public static class PriceExtensions
    {
        public static string PriceToWords(this decimal price, CultureInfo cultureInfo)
        {
            var naturalPartPriceToWords = new NaturalPartPrice(cultureInfo).GetPriceToWords(price);

            return $"{naturalPartPriceToWords}".Humanize(LetterCasing.Sentence);
        }
    }
}