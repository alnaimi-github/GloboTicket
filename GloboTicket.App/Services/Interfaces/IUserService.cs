using GloboTicket.App.Models;

namespace GloboTicket.App.Services.Interfaces;

public interface IUserService
{
    Task<UserProfile> GetUserProfile(Guid userId);

    Task UpdateProfile(UserProfile profile);
}
