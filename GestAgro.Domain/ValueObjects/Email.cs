using System.Text.RegularExpressions;

namespace GestAgro.Domain.ValueObjects
{
    public sealed class Email
    {
        private string Value { get; }

        private Email(string value) => Value = value;

        private static Email Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email), "E-mail cannot be empty.");

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$",
                    match => match.Groups[1].Value + match.Groups[2].Value.ToLowerInvariant(),
                    RegexOptions.None, TimeSpan.FromMilliseconds(250));

                const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                if (!Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                    throw new ArgumentException("E-mail isn't valid.", nameof(email));

                return new Email(email);
            }
            catch (RegexMatchTimeoutException)
            {
                throw new ArgumentException("E-mail isn't valid (timeout).", nameof(email));
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("E-mail isn't valid.", nameof(email), ex);
            }
        }

        public static bool TryParse(string input, out Email? email)
        {
            try
            {
                email = Create(input);
                return true;
            }
            catch
            {
                email = null;
                return false;
            }
        }

        public override string ToString() => Value;

        public static Email Parse(string input)
        {
            if (TryParse(input, out Email? email))
                return email!;
            
            throw new ArgumentException("E-mail isn't valid.", nameof(input));
        }

        public static implicit operator string(Email e) => e.Value;
    }
}