using Microsoft.AspNetCore.Identity;
using MoneyManager.Application.Exceptions;
using MoneyManager.Application.Features.CQRS.Commands.User.CreateUser;
using MoneyManager.Application.Services.Entities;
using MoneyManager.Domain.Entities.Identity;

namespace MoneyManager.Persistence.Services.Entities;

public class UserService(
    UserManager<User> userManager
    ): IUserService
{
    public async Task<CreateUserCommandResponse> CreateUserAsync(CreateUserCommandRequest request)
    {
        User user = new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Surname = request.Surname,
            Email = request.Email,
            PhoneNumber = request.Phone,
            UserName = request.Email
        };
        IdentityResult result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            throw new UnknownErrorException();
        return new();
    }

    public async Task UpdateRefreshTokenAsync(string refreshToken, User user, DateTime accessTokenDate, int addOnAccessTokenDate)
    {
        user.RefreshToken = refreshToken;
        user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
        await userManager.UpdateAsync(user);
    }
}