namespace PasswordManager.Utility
{
    public class SaltGenerator
    {
        public static string GenerateSalt()
        {
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string number = "0123456789";
            const string special = "!@#$%^&*()_-+=<>?";

            var chars = lower.ToList();
            chars.AddRange(upper);
            chars.AddRange(number);
            chars.AddRange(special);

            var salt = new char[32];
            var random = new Random();
            for (int i = 0; i < 32; i++)
            {
                salt[i] = chars[random.Next(chars.Count)];
            }

            return new string(salt);
        }
    }
}
