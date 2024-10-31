namespace TestTask.Infrastructure.Extensions
{
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// The Encrypter extension
    /// </summary>
    public static class Encrypter
    {
        /// <summary>
        /// Encrypts the sha1.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string EncryptSha1(this string value)
        {
            return Encrypt(value, string.Empty, SHA1.Create());
        }

        /// <summary>
        /// Encrypts the sha1.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="salt">The salt.</param>
        /// <returns></returns>
        public static string EncryptSha1(this string value, string salt)
        {
            return Encrypt(value, salt, SHA1.Create());
        }

        /// <summary>
        /// Encrypts the sha512.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string EncryptSha512(this string value)
        {
            return Encrypt(value, string.Empty, SHA512.Create());
        }

        /// <summary>
        /// Encrypts the sha512.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="salt">The salt.</param>
        /// <returns></returns>
        public static string EncryptSha512(this string value, string salt)
        {
            return Encrypt(value, salt, SHA512.Create());
        }

        /// <summary>
        /// Encrypts the m d5.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string EncryptMD5(this string value)
        {
            return Encrypt(value, string.Empty, MD5.Create());
        }

        private static string Encrypt(string value, string salt, HashAlgorithm hashAlgorithm)
        {
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

            byte[] toHash = new byte[valueBytes.Length + saltBytes.Length];
            Array.Copy(valueBytes, 0, toHash, 0, valueBytes.Length);
            Array.Copy(saltBytes, 0, toHash, valueBytes.Length, saltBytes.Length);

            var hash = hashAlgorithm.ComputeHash(toHash);
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}
