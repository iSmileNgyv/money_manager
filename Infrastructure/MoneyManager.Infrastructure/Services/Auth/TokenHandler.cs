using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MoneyManager.Application.Features.CQRS.Queries.Common;
using MoneyManager.Application.Services.Auth;

namespace MoneyManager.Infrastructure.Services.Auth;

public class TokenHandler(
    IConfiguration configuration
    ): ITokenHandler
{
    public TokenResponse CreateAccessToken(int second)
    {
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"] ?? "SecurityKey@12345"));
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);
        DateTime expiration = DateTime.UtcNow.AddSeconds(second);
        JwtSecurityToken token = new(
            audience: configuration["Token:Audience"],
            issuer: configuration["Token:Issuer"],
            expires: expiration,
            notBefore: DateTime.UtcNow,
            signingCredentials: signingCredentials
            );
        JwtSecurityTokenHandler tokenHandler = new();
        string accessToken = tokenHandler.WriteToken(token);
        return new()
        {
            AccessToken = accessToken,
            ExpirationDate = expiration,
            RefreshToken = CreateRefreshToken()
        };
    }

    public string CreateRefreshToken()
    {
        byte[] number = new byte[32];
        using RandomNumberGenerator rng = RandomNumberGenerator.Create();
        rng.GetBytes(number);
        return Convert.ToBase64String(number);
    }
}