using Chinook.ClientModels;
using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Services
{
    public class PlaylistService : BaseDataService<Chinook.Models.Playlist>
    {
        private readonly ChinookContext _context;
        public PlaylistService(ChinookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Chinook.Models.Playlist> GetPlaylistByName(string playlistName)
        {
            return await _context.Playlists.Where(a => a.Name == playlistName).FirstOrDefaultAsync();
        }

        public async Task<Chinook.Models.Playlist> GetFavoritePlaylistByUser(long playlistId, string currentUserId)
        {
            return await _context.Playlists.Include(p => p.UserPlaylists.Where(x=> x.UserId == currentUserId)).Where(li => li.PlaylistId == playlistId).FirstOrDefaultAsync();
        }

        public async Task<List<Chinook.Models.Playlist>> GetUserPlaylists(string currentUserId)
        {
            return await _context.Playlists.Include(p => p.UserPlaylists.Where(x => x.UserId == currentUserId)).ToListAsync();
        }

        public async Task<List<Album>> GetAlbums()
        {
            return await _context.Albums.Include(p => p.Artist).ToListAsync();
        }
    }
}
