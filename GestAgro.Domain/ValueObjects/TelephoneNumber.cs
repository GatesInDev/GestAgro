using GestAgro.Domain.Exceptions;
using PhoneNumbers;

namespace GestAgro.Domain.ValueObjects
{
    public sealed class TelephoneNumber
    {
        private string E164 { get; }
        public string Raw { get; }

        private TelephoneNumber(string raw, string e164)
        {
            Raw = raw;
            E164 = e164;
        }

        private static TelephoneNumber Create(string telephoneNumber, string region)
        {
            if (string.IsNullOrWhiteSpace(telephoneNumber))
                throw new InvalidPhoneException(nameof(telephoneNumber), "Telephone cannot be empty.");

            if (string.IsNullOrWhiteSpace(region))
                throw new InvalidRegionException(nameof(region), "Region cannot be empty.");

            var phoneUtil = PhoneNumberUtil.GetInstance();

            try
            {
                var parsed = phoneUtil.Parse(telephoneNumber, region);
                if (!phoneUtil.IsValidNumber(parsed))
                    throw new InvalidPhoneException(nameof(telephoneNumber), "Phone number isn't valid.");

                var e164 = phoneUtil.Format(parsed, PhoneNumberFormat.E164);
                return new TelephoneNumber(telephoneNumber, e164);
            }
            catch (NumberParseException ex)
            {
                throw new InvalidPhoneException(nameof(telephoneNumber), "Phone number isn't valid.");
            }
        }

        public static bool TryParse(string input, out TelephoneNumber? number, string region)
        {
            try
            {
                number = Create(input, region);
                return true;
            }
            catch
            {
                number = null;
                return false;
            }
        }

        public static TelephoneNumber Parse(string input, string region = "BR")
        {
            if (TryParse(input, out TelephoneNumber? phoneNumber, region))
                return phoneNumber!;

            throw new ArgumentException("Phone isn't valid.", nameof(input));
        }

        public override string ToString() => E164;
    }
}