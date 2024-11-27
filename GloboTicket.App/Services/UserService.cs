using GloboTicket.App.Models;
using GloboTicket.App.Services.Interfaces;

namespace GloboTicket.App.Services;

public class UserService: IUserService
{
    public Task<UserProfile> GetUserProfile(Guid userId)
    {
        // TODO: Get user profile
        return Task.FromResult(new UserProfile());
    }

    public Task UpdateProfile(UserProfile profile)
    {
        // TODO: Update profile
        return Task.CompletedTask;
    }
}
