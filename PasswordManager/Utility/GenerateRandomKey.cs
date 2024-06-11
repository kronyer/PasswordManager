namespace PasswordManager.Utility
{
    public class GenerateRandomKey
    {
        public static byte[] GenerateKey()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@!#$&*";
            var random = new Random();
            var key = Enumerable.Repeat(chars, 32).Select(s => (byte)s[random.Next(s.Length)]).ToArray();
            return key;
        }
    }
}
