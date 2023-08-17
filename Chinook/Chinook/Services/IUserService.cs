using Microsoft.AspNetCore.Components.Authorization;

namespace Chinook.Services
{
    public interface IUserService
    {
        public Task<string> GetUserId(Task<AuthenticationState> authenticationState);
    }
}
