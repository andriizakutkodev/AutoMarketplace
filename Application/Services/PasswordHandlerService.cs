namespace Application.Services;

using System.Net;
using System.Security.Cryptography;
using Application.Interfaces;
using Infrastructure.Results;

/// <summary>
/// Service for hashing passwords and generating salts using a secure cryptographic algorithm.
/// </summary>
public class PasswordHandlerService : IPasswordHandlerService
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 10000;

    /// <summary>
    /// Hashes a password using PBKDF2 with a randomly generated salt.
    /// </summary>
    /// <param name="password">The password to be hashed.</param>
    /// <param name="salt">
    /// An output parameter that will contain the generated cryptographic salt used in hashing.
    /// </param>
    /// <returns>
    /// A <see cref="Result{T}"/> containing the hashed password as a Base64-encoded string.
    /// </returns>
    public Result<string> HashPassword(string password, out byte[] salt)
    {
        salt = GenerateSalt(SaltSize);

        var hashedPassword = HashPasswordWithSalt(password, salt);

        return Result<string>.Success(Convert.ToBase64String(hashedPassword));
    }

    /// <summary>
    /// Validates a user's password by comparing the provided password hash with the stored hash.
    /// </summary>
    /// <param name="password">The plaintext password entered by the user.</param>
    /// <param name="storedHash">The previously stored hashed password (Base64 encoded) from the database.</param>
    /// <param name="salt">The salt that was used to hash the password during registration or the last password change.</param>
    /// <returns>
    /// A <see cref="Result{T}"/> containing a boolean value:
    /// <c>true</c> if the provided password is valid (i.e., the hashes match),
    /// <c>false</c> if the password is invalid.
    /// </returns>
    public Result ValidatePassword(string password, string storedHash, byte[] salt)
    {
        var hashedPassword = HashPasswordWithSalt(password, salt);
        var base64HashedPassword = Convert.ToBase64String(hashedPassword);

        var isValid = base64HashedPassword == storedHash;

        if (!isValid)
        {
            return Result.Failure(HttpStatusCode.BadRequest, "Password is not valid. Try again.");
        }

        return Result.Success();
    }

    /// <summary>
    /// Generates a cryptographic salt of the specified size.
    /// </summary>
    /// <param name="size">The size of the salt in bytes.</param>
    /// <returns>A byte array containing the cryptographic salt.</returns>
    private static byte[] GenerateSalt(int size)
    {
        var salt = new byte[size];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        return salt;
    }

    /// <summary>
    /// Hashes a password using PBKDF2 with the provided salt.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <param name="salt">The cryptographic salt to use for hashing.</param>
    /// <returns>A byte array containing the hashed password.</returns>
    private static byte[] HashPasswordWithSalt(string password, byte[] salt)
    {
        using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
        {
            return rfc2898DeriveBytes.GetBytes(HashSize);
        }
    }
}
