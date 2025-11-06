using GestAgro.Domain.Exceptions;
using System.Globalization;

namespace GestAgro.Domain.ValueObjects
{
    public sealed class DateValue
    {
        private DateTime Value { get; }

        private DateValue(DateTime value) => Value = value;

        private static DateValue Create(string dateString)
        {
            if (string.IsNullOrWhiteSpace(dateString))
                throw new InvalidDateException(nameof(dateString), "Date isn't empty.");

            if (DateTime.TryParse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out var parsed))
            {
                return new DateValue(parsed.ToUniversalTime());
            }

            throw new InvalidDateException(nameof(dateString), "Date isn't valid.");
        }

        public static bool TryParse(string input, out DateValue? date)
        {
            try
            {
                date = Create(input);
                return true;
            }
            catch
            {
                date = null;
                return false;
            }
        }

        public override string ToString() => Value.ToString("o");
    }
}