using System.Globalization;

namespace SpellPrice
{
    internal class PriceFormatter
    {
        private readonly CultureInfo cultureInfo;

        public PriceFormatter(CultureInfo cultureInfo)
            => this.cultureInfo = cultureInfo;

        public string GetPriceToWords(Price price)
        {
            var integerPartPriceToWords = new IntegerPartPrice(cultureInfo).GetPriceToWords(price);

            string priceToWords;
            if (price.FractionalPartValue != 0)
            {
                var fractionalPartPriceToWords = new FractionalPartPrice(cultureInfo).GetPriceToWords(price);
                priceToWords = $"{integerPartPriceToWords} et {fractionalPartPriceToWords}";
            }
            else
            {
                priceToWords = $"{integerPartPriceToWords}";
            }

            return priceToWords;
        }
    }
}