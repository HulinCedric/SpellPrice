using System;
using System.Globalization;
using System.Linq;

namespace SpellPrice.Utils
{
    internal static class RegionInfoHelper
    {
        internal static RegionInfo TryGetRegionInfo(string ISOCurrencySymbol)
            => CultureInfo.GetCultures(CultureTypes.AllCultures)
            .Select(cultureInfo =>
            {
                try
                {
                    return new RegionInfo(cultureInfo.LCID);
                }
                catch
                {
                    return default;
                };
            })
            .FirstOrDefault(
                regionInfo
                => regionInfo != default &&
                   string.Equals(
                       regionInfo.ISOCurrencySymbol,
                       ISOCurrencySymbol,
                       StringComparison.OrdinalIgnoreCase));
    }
}