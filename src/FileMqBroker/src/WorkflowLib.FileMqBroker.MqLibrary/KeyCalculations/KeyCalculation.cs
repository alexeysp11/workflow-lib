using System.Security.Cryptography;
using System.Text;

namespace WorkflowLib.FileMqBroker.MqLibrary.KeyCalculations
{
    /// <summary>
    /// Provides hash calculation functionality.
    /// </summary>
    public static class KeyCalculation
    {
        /// <summary>
        /// Calculates the MD5 hash based on the input string.
        /// </summary>
        public static string CalculateMd5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Calculates the SHA256 hash based on the input string.
        /// </summary>
        public static string CalculateSha256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
