namespace SpellPrice
{
    internal class Price
    {
        public Price(decimal priceValue)
            => PriceValue = priceValue;

        public int FractionalPartValue
            => PriceValue.GetFractionalPart();

        public int IntegerPartValue
            => PriceValue.GetIntegerPart();

        public decimal PriceValue { get; }
    }
}