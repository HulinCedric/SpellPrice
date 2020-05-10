namespace SpellPrice
{
    internal class Price
    {
        public Price(decimal priceValue)
            => PriceValue = priceValue;

        public decimal PriceValue { get; }

        public int FractionalPartValue
            => PriceValue.GetFractionnalPart();

        public int IntegerPartValue
            => PriceValue.GetIntegerPart();
    }
}