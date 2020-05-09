using System;

namespace SpellPrice
{
    internal static class DecimalExtensions
    {
        internal static int GetIntegerPart(this decimal value)
            => (int)Math.Truncate(value);

        internal static int GetFractionnalPart(this decimal value)
        {
            var decimalSeparatorSplitValues = value.ToString().Split('.');
            return decimalSeparatorSplitValues.Length == 2 ?
            int.Parse(decimalSeparatorSplitValues[1]) :
            0;
        }
    }
}