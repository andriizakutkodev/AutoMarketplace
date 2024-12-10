namespace Application.Interfaces;

using Infrastructure.Results;

/// <summary>
/// Defines the contract for a service responsible for handling password hashing and validation.
/// </summary>
public interface IPasswordHandlerService
{
    /// <summary>
    /// Hashes the provided password and generates a salt for the password.
    /// </summary>
    /// <param name="password">The plaintext password to be hashed.</param>
    /// <param name="salt">The generated salt used in the password hashing process. The salt is returned as an output parameter.</param>
    /// <returns>
    /// A <see cref="Result{T}"/> containing the hashed password as a Base64 string if successful,
    /// or an error result if the hashing process fails.
    /// </returns>
    Result<string> HashPassword(string password, out byte[] salt);

    /// <summary>
    /// Validates the provided password by comparing it with the stored password hash.
    /// </summary>
    /// <param name="password">The plaintext password entered by the user.</param>
    /// <param name="storedHash">The previously stored hashed password (Base64 encoded) from the database.</param>
    /// <param name="salt">The salt used when the password was hashed during registration or the last password change.</param>
    /// <returns>
    /// A <see cref="Result"/> containing a boolean indicating whether the password is valid (i.e., the hashes match) or not.
    /// </returns>
    Result ValidatePassword(string password, string storedHash, byte[] salt);
}
