using System;
using System.Security.Cryptography;
using System.Text;

namespace FileMqBroker.MqLibrary.KeyCalculations;

/// <summary>
/// Provides SHA256 hash calculation functionality.
/// </summary>
public class KeyCalculationSHA256 : IKeyCalculation
{
    /// <summary>
    /// Calculates the SHA256 hash based on the input string.
    /// </summary>
    public string CalculateHash(string input)
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
