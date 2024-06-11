namespace PasswordManager.Utility
{
    public class PasswordGenerator
    {
        public static string GeneratePassword(int lenght, bool upperCase, bool numbers, bool specials)
        {
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string number = "0123456789";
            const string special = "!@#$%^&*()_-+=<>?";

            var chars = lower.ToList();
            if (upperCase) chars.AddRange(upper);
            if (numbers) chars.AddRange(number);
            if (specials) chars.AddRange(special);

            var password = new char[lenght];
            var random = new Random();
            for (int i = 0; i < lenght; i++)
            {
                password[i] = chars[random.Next(chars.Count)];
            }

            return new string(password);
        }
    }
}
