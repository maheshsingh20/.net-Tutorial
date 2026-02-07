// Question 14: Secure Password Storage Utility
namespace m1Assessment_Practise.Questions.Question14;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 14: Secure Password Storage ===\n");

        var hasher = new PasswordHasher();

        string password = "MySecureP@ssw0rd";
        Console.WriteLine($"Original Password: {password}");

        string hashedPassword = hasher.HashPassword(password);
        Console.WriteLine($"Hashed: {hashedPassword}\n");

        bool isValid = hasher.VerifyPassword(password, hashedPassword);
        Console.WriteLine($"Verify correct password: {isValid}");

        bool isInvalid = hasher.VerifyPassword("WrongPassword", hashedPassword);
        Console.WriteLine($"Verify wrong password: {isInvalid}");

        string hashedPassword2 = hasher.HashPassword(password);
        Console.WriteLine($"\nSame password hashed again: {hashedPassword2}");
        Console.WriteLine($"Hashes are different (due to salt): {hashedPassword != hashedPassword2}");
    }
}
