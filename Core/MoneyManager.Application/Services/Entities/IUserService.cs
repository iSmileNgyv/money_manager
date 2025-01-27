using MoneyManager.Application.Features.CQRS.Commands.User.CreateUser;
using MoneyManager.Domain.Entities.Identity;

namespace MoneyManager.Application.Services.Entities;

public interface IUserService
{
    Task<CreateUserCommandResponse> CreateUserAsync(CreateUserCommandRequest request);
    Task UpdateRefreshTokenAsync(string refreshToken, User user, DateTime accessTokenDate, int addOnAccessTokenDate);
}