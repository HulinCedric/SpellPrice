namespace SpellPrice
{
    internal class Price
    {
        public Price(decimal priceValue)
            => PriceValue = priceValue;

        public int FractionalPartValue
            => PriceValue.GetFractionnalPart();

        public int IntegerPartValue
            => PriceValue.GetIntegerPart();

        public decimal PriceValue { get; }
    }
}