using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;

namespace IbanValidation
{
    public class IbanValidator : IIbanValidator
    {
        public IbanValidationResult Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) { return IbanValidationResult.ValueMissing; }

            if (value.Length < 2) { return IbanValidationResult.ValueTooSmall; }

            var countryCode = value.Substring(0, 2).ToUpper();

            int lengthForCountryCode;

            var countryCodeKnown = _lengths.TryGetValue(countryCode, out lengthForCountryCode);
            if (!countryCodeKnown)
            {
                return IbanValidationResult.CountryCodeNotKnown;
            }

            // Check length.
            if (value.Length < lengthForCountryCode) { return IbanValidationResult.ValueTooSmall; }
            if (value.Length > lengthForCountryCode) { return IbanValidationResult.ValueTooBig; }

            var upperValue = value.ToUpper();
            var newIban = upperValue.Substring(4) + upperValue.Substring(0, 4);

            newIban = Regex.Replace(newIban, @"\D", match => (match.Value[0] - 55).ToString(CultureInfo.InvariantCulture));

            var remainder = BigInteger.Parse(newIban) % 97;

            if (remainder != 1) { return IbanValidationResult.ValueFailsModule97Check; }

            return IbanValidationResult.IsValid;
        }

        private static readonly Dictionary<string, int> _lengths = new Dictionary<string, int>
        {
            {"AD", 24 },
            {"AE", 23 },
            {"AL", 28 },
            {"AO", 25 },
            {"AT", 20 },
            {"AZ", 28 },
            {"BA", 20 },
            {"BE", 16 },
            {"BF", 27 },
            {"BG", 22 },
            {"BH", 22 },
            {"BI", 16 },
            {"BJ", 28 },
            {"BR", 29 },
            {"BY", 28 },
            {"CH", 21 },
            {"CI", 28 },
            {"CM", 27 },
            {"CR", 22 },
            {"CV", 25 },
            {"CY", 28 },
            {"CZ", 24 },
            {"DE", 22 },
            {"DK", 18 },
            {"DO", 28 },
            {"DZ", 24 },
            {"EE", 20 },
            {"ES", 24 },
            {"FI", 18 },
            {"FO", 18 },
            {"FR", 27 },
            {"GB", 22 },
            {"GE", 22 },
            {"GI", 23 },
            {"GL", 18 },
            {"GR", 27 },
            {"GT", 28 },
            {"HR", 21 },
            {"HU", 28 },
            {"IE", 22 },
            {"IL", 23 },
            {"IM", 22 },
            {"IQ", 23 },
            {"IR", 26 },
            {"IS", 26 },
            {"IT", 27 },
            {"JO", 30 },
            {"KW", 30 },
            {"KZ", 20 },
            {"LB", 28 },
            {"LC", 32 },
            {"LI", 21 },
            {"LT", 20 },
            {"LU", 20 },
            {"LV", 21 },
            {"MC", 27 },
            {"MD", 24 },
            {"ME", 22 },
            {"MG", 27 },
            {"MK", 19 },
            {"ML", 28 },
            {"MR", 27 },
            {"MT", 31 },
            {"MU", 30 },
            {"MZ", 25 },
            {"NL", 18 },
            {"NO", 15 },
            {"PK", 24 },
            {"PL", 28 },
            {"PS", 29 },
            {"PT", 25 },
            {"QA", 29 },
            {"RO", 24 },
            {"RS", 22 },
            {"SA", 24 },
            {"SC", 31 },
            {"SE", 24 },
            {"SI", 19 },
            {"SK", 24 },
            {"SL", 32 },
            {"ST", 25 },
            {"SM", 27 },
            {"SN", 28 },
            {"SV", 28 },
            {"TL", 23 },
            {"TN", 24 },
            {"TR", 26 },
            {"UA", 29 },
            {"VG", 24 },
            {"XK", 20 }
        };
    }
}