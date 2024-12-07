namespace Application.Options;

/// <summary>
/// Represents the configuration options for generating JSON Web Tokens (JWT).
/// </summary>
public class JwtOptions
{
    /// <summary>
    /// Gets or sets the secret key used for signing the JWT.
    /// </summary>
    public string SecretKey { get; set; }

    /// <summary>
    /// Gets or sets the issuer of the JWT.
    /// </summary>
    public string Issuer { get; set; }

    /// <summary>
    /// Gets or sets the audience of the JWT.
    /// </summary>
    public string Audience { get; set; }

    /// <summary>
    /// Gets or sets the lifetime of the token in minutes.
    /// </summary>
    public int TokenLifetimeMinutes { get; set; }
}
