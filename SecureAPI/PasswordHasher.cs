using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace SecureAPI
{
    public class PasswordHasher
    {
        public static string salt() {
            byte[] saltBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetNonZeroBytes(saltBytes);
            }
            string salt = Convert.ToBase64String(saltBytes);
            return salt;
        }

        public static string hashPassword(string password, string salt) {
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashedPassword;
        }

    }
}
