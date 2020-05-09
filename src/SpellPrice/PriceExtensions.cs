using Humanizer;
using System.Globalization;

namespace SpellPrice
{
    public static class PriceExtensions
    {
        public static string PriceToWords(this decimal price, CultureInfo cultureInfo)
        {
            var priceToWords = string.Empty;
            var naturalPartPriceToWords = new NaturalPartPrice(cultureInfo).GetPriceToWords(price);

            if (price.GetFractionnalPart() != 0)
            {
                var fractionnalPartPriceToWords = new FractionnalPartPrice(cultureInfo).GetPriceToWords(price);
                priceToWords = $"{naturalPartPriceToWords} et {fractionnalPartPriceToWords}";
            }
            else
            {
                priceToWords = $"{naturalPartPriceToWords}";
            }

            return priceToWords.Humanize(LetterCasing.Sentence);
        }
    }
}