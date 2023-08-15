using Chinook.ClientModels;
using Chinook.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using Playlist = Chinook.Models.Playlist;

namespace Chinook.Services
{
    public class PlaylistService : BaseDataService<Chinook.Models.Playlist>
    {
        private readonly ChinookContext _context;
        public PlaylistService(ChinookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Chinook.Models.Playlist> FindPlaylistId(long id)
        {
            return await _context.Playlists.FindAsync(id);
        }

        public async Task<Chinook.Models.Playlist> GetPlaylistByName(string playlistName)
        {
            return await _context.Playlists.AsNoTracking().Include(x=>x.Tracks).Include(x=>x.UserPlaylists).Include(x => x.PlaylistTracks).Where(a => a.Name == playlistName && a.PlaylistId > 0).FirstOrDefaultAsync();
        }

        public async Task<Chinook.Models.Playlist> GetFavoritePlaylistByUser(long playlistId, string currentUserId)
        {
            var favoriteList = await _context.Playlists.AsNoTracking().Include(p => p.UserPlaylists.Where(x=> x.UserId == currentUserId)).Include(x=>x.Tracks).Include(x=>x.PlaylistTracks).Where(li => li.PlaylistId == playlistId).FirstOrDefaultAsync();
            
            return favoriteList;

        }

        public async Task<List<Chinook.Models.Playlist>> GetUserPlaylists(string currentUserId)
        {
            return await _context.Playlists.AsNoTracking().Include(p => p.UserPlaylists.Where(x => x.UserId == currentUserId)).Where(x=>x.UserPlaylists != null && x.PlaylistId > 0).ToListAsync();
        }

        public async Task<List<Album>> GetAlbums()
        {
            return await _context.Albums.AsNoTracking().Include(p => p.Artist).ToListAsync();
        }

        public async Task<Album> GetAlbumByName(string albumName)
        {
            return await _context.Albums.AsNoTracking().Include(p => p.Artist).Where(a => a.Title == albumName).FirstOrDefaultAsync();
        }

        public async Task CreateOrUpdateUserPlaylistAsync(UserPlaylist playlist, long playlistId)
        {
            var existingPlaylist = await _context.UserPlaylists.AsNoTracking().Where(x => x.PlaylistId == playlistId && x.UserId == playlist.UserId).FirstOrDefaultAsync();

            if (existingPlaylist == null)
            {
                _context.UserPlaylists.Add(playlist);
                _context.Entry(playlist).State = EntityState.Added;
                await _context.SaveChangesAsync();
            }
        }
    }
}
