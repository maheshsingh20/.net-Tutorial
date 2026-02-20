using System;
using System.Text.RegularExpressions;

namespace StringTutorial.RegularExpressions
{
    public class RegexValidation
    {
        public static void Run()
        {
            Console.WriteLine("String Validation with Regex\n");

            // Email validation
            Console.WriteLine("1. Email Validation:");
            string[] emails = { "user@example.com", "invalid.email", "test@domain.co.uk" };
            foreach (string email in emails)
            {
                Console.WriteLine($"   '{email}': {IsValidEmail(email)}");
            }

            // Phone validation
            Console.WriteLine("\n2. Phone Number Validation:");
            string[] phones = { "123-456-7890", "1234567890", "(123) 456-7890", "123-45-6789" };
            foreach (string phone in phones)
            {
                Console.WriteLine($"   '{phone}': {IsValidPhone(phone)}");
            }

            // URL validation
            Console.WriteLine("\n3. URL Validation:");
            string[] urls = { "https://example.com", "http://test.org", "ftp://files.com", "invalid-url" };
            foreach (string url in urls)
            {
                Console.WriteLine($"   '{url}': {IsValidUrl(url)}");
            }

            // Password strength
            Console.WriteLine("\n4. Password Strength:");
            string[] passwords = { "weak", "Strong123", "VeryStrong@123", "NoDigits!" };
            foreach (string pwd in passwords)
            {
                Console.WriteLine($"   '{pwd}': {GetPasswordStrength(pwd)}");
            }

            // Credit card validation
            Console.WriteLine("\n5. Credit Card Format:");
            string[] cards = { "1234-5678-9012-3456", "1234567890123456", "1234-5678-9012" };
            foreach (string card in cards)
            {
                Console.WriteLine($"   '{card}': {IsValidCreditCardFormat(card)}");
            }

            // Username validation
            Console.WriteLine("\n6. Username Validation:");
            string[] usernames = { "user123", "user_name", "user-name", "user@name", "ab" };
            foreach (string username in usernames)
            {
                Console.WriteLine($"   '{username}': {IsValidUsername(username)}");
            }
        }

        static bool IsValidEmail(string email)
        {
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            return Regex.IsMatch(email, pattern);
        }

        static bool IsValidPhone(string phone)
        {
            string pattern = @"^\d{3}-\d{3}-\d{4}$";
            return Regex.IsMatch(phone, pattern);
        }

        static bool IsValidUrl(string url)
        {
            string pattern = @"^https?://[\w\.-]+\.\w{2,}";
            return Regex.IsMatch(url, pattern);
        }

        static string GetPasswordStrength(string password)
        {
            bool hasUpper = Regex.IsMatch(password, @"[A-Z]");
            bool hasLower = Regex.IsMatch(password, @"[a-z]");
            bool hasDigit = Regex.IsMatch(password, @"\d");
            bool hasSpecial = Regex.IsMatch(password, @"[!@#$%^&*(),.?""':{}|<>]");
            bool isLongEnough = password.Length >= 8;

            int strength = 0;
            if (hasUpper) strength++;
            if (hasLower) strength++;
            if (hasDigit) strength++;
            if (hasSpecial) strength++;
            if (isLongEnough) strength++;

            return strength switch
            {
                5 => "Very Strong",
                4 => "Strong",
                3 => "Medium",
                2 => "Weak",
                _ => "Very Weak"
            };
        }

        static bool IsValidCreditCardFormat(string card)
        {
            string pattern = @"^\d{4}-\d{4}-\d{4}-\d{4}$";
            return Regex.IsMatch(card, pattern);
        }

        static bool IsValidUsername(string username)
        {
            string pattern = @"^[a-zA-Z0-9_]{3,20}$";
            return Regex.IsMatch(username, pattern);
        }
    }
}
