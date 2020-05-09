using System;

namespace SpellPrice
{
    internal static class DecimalExtensions
    {
        internal static int GetIntegerPart(this decimal value)
            => (int)Math.Truncate(value);
    }
}