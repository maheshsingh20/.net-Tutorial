using System.Security.Cryptography;

namespace m1Assessment_Practise.Questions.Question14;

class PasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 10000;

    public string HashPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password cannot be empty");

        byte[] salt = new byte[SaltSize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        byte[] hash = GenerateHash(password, salt);

        byte[] hashBytes = new byte[SaltSize + HashSize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

        return Convert.ToBase64String(hashBytes);
    }

    public bool VerifyPassword(string password, string storedHash)
    {
        if (string.IsNullOrWhiteSpace(password))
            return false;

        try
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);
            
            if (hashBytes.Length != SaltSize + HashSize)
                return false;

            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            byte[] storedHashPart = new byte[HashSize];
            Array.Copy(hashBytes, SaltSize, storedHashPart, 0, HashSize);

            byte[] computedHash = GenerateHash(password, salt);

            return CryptographicOperations.FixedTimeEquals(storedHashPart, computedHash);
        }
        catch
        {
            return false;
        }
    }

    private byte[] GenerateHash(string password, byte[] salt)
    {
        return Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, HashSize);
    }
}
