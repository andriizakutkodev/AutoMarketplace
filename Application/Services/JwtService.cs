namespace Application.Services;

using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Application.Consts;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Options;
using Infrastructure.Results;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

/// <summary>
/// Service for generating JSON Web Tokens (JWT) for user authentication.
/// </summary>
public class JwtService(IOptions<JwtOptions> options) : IJwtService
{
    /// <summary>
    /// Generates a JWT token for the specified user.
    /// </summary>
    /// <param name="user">The user for whom the JWT token will be generated.</param>
    /// <returns>
    /// A <see cref="Result{T}"/> containing the generated JWT token as a string if successful,
    /// or an error result if the configuration is invalid.
    /// </returns>
    public Result<string> GenerateToken(User user)
    {
        if (!IsOptionsValid(options.Value))
        {
            return Result<string>.Failure(HttpStatusCode.ServiceUnavailable, "The Jwt configuration is not valid. Please contact to administrator.");
        }

        var claims = new List<Claim>
        {
            new (JwtClaimNames.Sub, user.Id.ToString()),
            new (JwtClaimNames.Email, user.Email),
            new (JwtClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        if (user.Image is not null)
        {
            claims.Add(new Claim(JwtClaimNames.ImgUrl, user.Image.Url));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(options.Value.TokenLifetimeMinutes),
            Issuer = options.Value.Issuer,
            Audience = options.Value.Audience,
            SigningCredentials = credentials,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(securityToken);

        return Result<string>.Success(token);
    }

    /// <summary>
    /// Validates the JWT configuration options.
    /// </summary>
    /// <param name="options">The JWT options to validate.</param>
    /// <returns>
    /// <c>true</c> if the options are valid; otherwise, <c>false</c>.
    /// </returns>
    private bool IsOptionsValid(JwtOptions options)
    {
        return !string.IsNullOrEmpty(options.SecretKey)
            && !string.IsNullOrEmpty(options.Audience)
            && !string.IsNullOrEmpty(options.Issuer)
            && !string.IsNullOrEmpty(options.Audience);
    }
}
