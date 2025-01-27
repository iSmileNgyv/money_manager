using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Exceptions.User;
using MoneyManager.Application.Features.CQRS.Queries.Common;
using MoneyManager.Application.Services.Auth;
using MoneyManager.Application.Services.Entities;
using MoneyManager.Domain.Entities.Identity;

namespace MoneyManager.Persistence.Services.Auth;

public class AuthService(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    ITokenHandler tokenHandler,
    IUserService userService
    ): IAuthService
{
    public async Task<TokenResponse> LoginAsync(string email, string password, int accessTokenLifeTime)
    {
        User? user = await userManager.FindByEmailAsync(email);
        if (user == null)
            throw new UserNotFoundException();
        SignInResult signInResult = await signInManager.CheckPasswordSignInAsync(user, password, false);
        if (!signInResult.Succeeded)
            throw new InvalidEmailOrPasswordException();
        TokenResponse token = tokenHandler.CreateAccessToken(accessTokenLifeTime);
        if (token.RefreshToken != null)
            await userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.ExpirationDate,
                (60 * 60 * 24 * 7));
        return token;
    }

    public async Task<TokenResponse> RefreshTokenLoginAsync(string refreshToken)
    {
        User? user = userManager.Users.FirstOrDefault(u => u.RefreshToken == refreshToken);
        if (user == null)
            throw new UnauthorizedAccessException();
        if (user.RefreshTokenEndDate < DateTime.UtcNow)
            throw new InvalidRefreshTokenException();
        TokenResponse token = tokenHandler.CreateAccessToken(60*60*24);
        if(token.RefreshToken != null)
            await userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.ExpirationDate, 60*60*24*7);
        return token;
    }
}