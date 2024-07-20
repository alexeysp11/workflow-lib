namespace Security.Models
{
    /// <summary>
    /// Contains collections of ciphers 
    /// </summary>
    public class SubstitutionCipher
    {
        /// <summary>
        /// Allows to use monoalphabetic cipher for string encription 
        /// </summary>
        /// <param name="input">Input string that needs to be encrypted</param>
        /// <returns>Encrypted string</returns>
        public string Monoalphabetic(string input)
        {
            if (input == null || input == string.Empty)
            {
                throw new System.Exception("Unable to use Monoalphabetic (input string cannot be null or empty).");
            }

            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(input);

            for (int i = 0; i < bytes.Length; i++)
            {
                bool isFirstPartUpper = (bytes[i] >= 65 && bytes[i] <= 77);
                bool isSecondPartUpper = (bytes[i] >= 78 && bytes[i] <= 90);
                bool isFirstPartLower = (bytes[i] >= 97 && bytes[i] <= 109);
                bool isSecondPartLower = (bytes[i] >= 110 && bytes[i] <= 122);
                
                if (isFirstPartUpper || isFirstPartLower)
                {
                    bytes[i] = (byte)(bytes[i] + 13);
                }
                else if (isSecondPartUpper || isSecondPartLower)
                {
                    bytes[i] = (byte)(bytes[i] - 13);
                }
            }
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}