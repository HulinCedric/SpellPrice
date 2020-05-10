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
            var integerPartPriceToWords = new IntegerPartPrice(cultureInfo).GetPriceToWords(price);

            if (price.FractionalPartValue != 0)
            {
                var fractionalPartPriceToWords = new FractionalPartPrice(cultureInfo).GetPriceToWords(price);
                priceToWords = $"{integerPartPriceToWords} et {fractionalPartPriceToWords}";
            }
            else
            {
                priceToWords = $"{integerPartPriceToWords}";
            }

            return priceToWords.Humanize(LetterCasing.Sentence);
        }
    }
}