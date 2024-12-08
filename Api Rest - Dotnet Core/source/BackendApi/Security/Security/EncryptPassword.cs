namespace Security
{
    using Microsoft.AspNetCore.Cryptography.KeyDerivation;
    using System;
    using System.Security.Cryptography;

    public class EncryptPassword
    {
        /// <summary>
        /// Realiza cryptografia de senha apatir de um salt
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string Encrypt(string password, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                                       password: password,
                                                       salt: Convert.FromBase64String(salt),
                                                      prf: KeyDerivationPrf.HMACSHA1,
                                                      iterationCount: 10000,
                                                      numBytesRequested: 256 / 8));
        }

        /// <summary>
        /// Gera um salt aleatorio de 128b bits
        /// </summary>
        /// <returns></returns>
        public static string GeneratorSalt()
        {
            var salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(salt);

            return Convert.ToBase64String(salt);
        }
    }
}