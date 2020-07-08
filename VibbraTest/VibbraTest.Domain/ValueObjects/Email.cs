using System;
using System.Text.RegularExpressions;
using VibbraTest.Domain.Exceptions;

namespace VibbraTest.Domain.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new BusinessException("E-mail not found");

            if(!IsValidEmail(value))
                throw new BusinessException($"E-mail {value} is inválid");

            Value = value.ToLowerInvariant().Trim();
        }

        public string Value { get; }

        protected override bool EqualsCore(Email other) => other.Value == Value;

        protected override int GetHashCodeCore() => Value.GetHashCode();

        public override string ToString() => Value;

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        /// </summary>
        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new System.Globalization.IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static implicit operator string(Email email) => email.Value;
    }
}
