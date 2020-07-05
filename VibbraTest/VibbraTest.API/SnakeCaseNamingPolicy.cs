using Newtonsoft.Json.Serialization;
using System.Text.Json;

namespace VibbraTest.API
{
    /// <summary>
    /// Snake policy convention.
    /// It converts a property named "EmailAddress" in "email_address"
    /// Font: https://stackoverflow.com/questions/58570189/is-there-a-built-in-way-of-using-snake-case-as-the-naming-policy-for-json-in-asp
    /// </summary>
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        private readonly SnakeCaseNamingStrategy _newtonsoftSnakeCaseNamingStrategy
            = new SnakeCaseNamingStrategy();

        public static SnakeCaseNamingPolicy Instance { get; } = new SnakeCaseNamingPolicy();

        public override string ConvertName(string name)
        {
            return _newtonsoftSnakeCaseNamingStrategy.GetPropertyName(name, false);
        }
    }
}
