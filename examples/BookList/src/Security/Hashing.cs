namespace Security.Models
{
    /// <summary>
    /// Class for hashing data.
    /// </summary>
    public class Hashing
    {
        /// <summary>
        /// Allows to implement simple hash function. 
        /// </summary>
        /// <param name="username">String representation of username</param>
        /// <param name="password">String representation of password</param>
        /// <returns>String of 16 characters</returns>
        public string HashFunc(string username, string password)
        {
            int coef = 2;
            int iUsernameHash = 0;
            int iPasswordHash = 0;

            // Get code of a username. 
            for (int i = 0; i < username.Length; i++)
            {
                iUsernameHash = iUsernameHash * coef + username[i];
            }

            // Get code of a password. 
            for (int i = 0; i < password.Length; i++)
            {
                iPasswordHash = iPasswordHash * coef + password[i];
            }

            // Get code of number of caracters in password. 
            short u16NumberCode = (short)(password.Length * 2);
            byte[] bNumberCode = new byte[sizeof(short)];
            System.Buffer.BlockCopy(new short[] { u16NumberCode }, 0, bNumberCode, 0, bNumberCode.Length);

            // Create an array of bytes. 
            byte[] bUsernameHash = new byte[sizeof(int)];
            byte[] bPasswordHash = new byte[sizeof(int)];
            System.Buffer.BlockCopy(new int[] { iUsernameHash }, 0, bUsernameHash, 0, bUsernameHash.Length);
            System.Buffer.BlockCopy(new int[] { iPasswordHash }, 0, bPasswordHash, 0, bPasswordHash.Length);

            // Get byte value of the average between last characters. 
            byte avgLastChars = (byte)( (username[username.Length - 1] + password[password.Length - 1]) / 2 );
            
            // Create an array of characters inside output string. 
            byte[] bHash = new byte[16]
            {
                bUsernameHash[0], 
                bUsernameHash[1], 
                bUsernameHash[2],
                bUsernameHash[3],
                (byte)username[0],
                (byte)password[1], 
                (byte)username.Length, 
                bPasswordHash[0],
                bPasswordHash[1],
                bPasswordHash[2],
                bPasswordHash[3], 
                (byte)(password[0] + coef), 
                avgLastChars, 
                (byte)(username[1] - coef), 
                bNumberCode[0], 
                bNumberCode[1]
            };
            
            // Get a string of hash. 
            string sHash = System.Text.Encoding.ASCII.GetString(bHash);

            return sHash;
        }
    }
}