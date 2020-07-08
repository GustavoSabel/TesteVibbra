using System;
using System.Security.Cryptography;

namespace VibbraTest.Domain.Helpers
{
    public static class PasswordHelper
    {
        public static string GenerateHash(string password)
        {
            byte[] salt;

            using var cryptoProvider = new RNGCryptoServiceProvider();
            cryptoProvider.GetBytes(salt = new byte[16]);

            return GenerateHash(password, salt);
        }

        public static bool CompareWithHash(string password, string passwordHash)
        {
            var passwordHashBytes = Convert.FromBase64String(passwordHash);

            byte[] salt = new byte[16];
            Array.Copy(passwordHashBytes, 0, salt, 0, 16);

            return passwordHash == GenerateHash(password, salt);
        }

        private static string GenerateHash(string password, byte[] salt)
        {
            var pdkdf2 = new Rfc2898DeriveBytes(password, salt, 100);

            byte[] hash = pdkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string passwordHash = Convert.ToBase64String(hashBytes);

            return passwordHash;
        }
    }
}
