using Chinook.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Chinook.Services
{
    public class UserService : BaseService<ChinookUser>, IUserService
    {
        private readonly ChinookContext _context;
        
        public UserService(ChinookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<string> GetUserId(Task<AuthenticationState> authenticationState)
        {
            var user = (await authenticationState).User;
            var userId = user.FindFirst(u => u.Type.Contains(ClaimTypes.NameIdentifier))?.Value;
            return userId;
        }
    }
}
