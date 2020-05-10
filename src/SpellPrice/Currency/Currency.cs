using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace SpellPrice.Currency
{
    internal class Currency
    {
        public static readonly Currency EUR = new Currency(CurrencyISOCode.EUR.ToString());
        public static readonly Currency USD = new Currency(CurrencyISOCode.USD.ToString());

        public readonly RegionInfo regionInfo;

        private Currency(string ISOCurrencySymbol)
        {
            if (string.IsNullOrWhiteSpace(ISOCurrencySymbol))
            {
                throw new ArgumentException(
                    $"{nameof(ISOCurrencySymbol)} should not be null or white space",
                    nameof(ISOCurrencySymbol));
            }

            regionInfo = Utils.RegionInfoHelper.TryGetRegionInfo(ISOCurrencySymbol) ??
                throw new ArgumentException(
                    $"{nameof(ISOCurrencySymbol)} should be in ISO 4217 codes",
                    nameof(ISOCurrencySymbol));
        }

        public string EnglishMajorName
            => regionInfo.CurrencyEnglishName;

        public string ISOCode
            => regionInfo.ISOCurrencySymbol;

        public static Currency FromISOCode(string value)
            => GetAll()
            .FirstOrDefault(currency => currency.ISOCode == value) ??
            throw new InvalidOperationException(
                $"'{value}' is not a valid {nameof(ISOCode)} in {nameof(Currency)}");

        public static IEnumerable<Currency> GetAll()
            => typeof(Currency)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<Currency>();
    }
}