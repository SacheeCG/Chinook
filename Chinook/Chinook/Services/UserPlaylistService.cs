using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Services
{
    public class UserPlaylistService : BaseService<UserPlaylist>, IUserPlaylistService
    {
        private readonly ChinookContext _context;
        public UserPlaylistService(ChinookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<UserPlaylist>> GetPlaylistsByUser(string userId)
        {
            return await _context.UserPlaylists.AsNoTracking().Where(x=>x.UserId == userId).ToListAsync();
        }

        public async Task CreateUserPlaylistAsync(UserPlaylist playlist, long playlistId)
        {
            var existingPlaylist = await _context.UserPlaylists.AsNoTracking().Where(x => x.PlaylistId == playlistId && x.UserId == playlist.UserId).FirstOrDefaultAsync();

            if (existingPlaylist == null)
            {
                await base.AddAsync(playlist);
            }
        }
    }
}
