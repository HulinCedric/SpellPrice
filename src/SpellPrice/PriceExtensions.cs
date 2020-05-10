using Humanizer;
using System.Globalization;

namespace SpellPrice
{
    public static class PriceExtensions
    {
        public static string PriceToWords(this decimal priceValue, CultureInfo cultureInfo)
        {
            var priceToWords = string.Empty;
            var price = new Price(priceValue);
            var naturalPartPriceToWords = new NaturalPartPrice(cultureInfo).GetPriceToWords(price);

            if (price.FractionalPartValue != 0)
            {
                var fractionalPartPriceToWords = new FractionalPartPrice(cultureInfo).GetPriceToWords(price);
                priceToWords = $"{naturalPartPriceToWords} et {fractionalPartPriceToWords}";
            }
            else
            {
                priceToWords = $"{naturalPartPriceToWords}";
            }

            return priceToWords.Humanize(LetterCasing.Sentence);
        }
    }
}