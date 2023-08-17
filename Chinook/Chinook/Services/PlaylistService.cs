//using Chinook.ClientModels;
using Chinook.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace Chinook.Services
{
    public class PlaylistService : BaseService<Playlist>, IPlaylistService
    {
        private readonly ChinookContext _context;
        public PlaylistService(ChinookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Playlist> FindPlaylistId(long id)
        {
            return await _context.Playlists.FindAsync(id);
        }

        public async Task<Playlist> GetPlaylistByName(string playlistName, string userId)
        {
            return await _context.Playlists.AsNoTracking().Include(x=>x.Tracks).Include(x=>x.UserPlaylists).Include(x => x.PlaylistTracks).Where(a => a.Name == playlistName && a.PlaylistId > 0 && a.UserPlaylists.Where(x => x.UserId == userId).Any()).FirstOrDefaultAsync();
        }

        public async Task<Playlist> GetFavoritePlaylistByUser(long playlistId, string currentUserId)
        {
            List<long> trackIdsInPlaylist = _context.PlaylistTracks.Where(x=>x.PlaylistId == playlistId).Select(pt => pt.TrackId).ToList();
            var tracks = await _context.Tracks.Where(t => trackIdsInPlaylist.Contains(t.TrackId)).ToListAsync();
            var favoritePlaylist = await _context.Playlists.AsNoTracking().Include(p => p.UserPlaylists.Where(x=> x.UserId == currentUserId)).Include(x=>x.Tracks).Include(x=>x.PlaylistTracks).Where(x => x.PlaylistId == playlistId).FirstOrDefaultAsync();
            favoritePlaylist.Tracks.AddRange(tracks);
            return favoritePlaylist;
        }

        public async Task<List<Playlist>> GetUserPlaylists(string currentUserId)
        {
            return await _context.Playlists.AsNoTracking().Include(p => p.UserPlaylists.Where(x => x.UserId == currentUserId)).Where(x=>x.UserPlaylists != null && x.PlaylistId > 0).ToListAsync();
        }

        public async Task UpdatePlaylistAsync(Playlist playlist)
        {
            _context.Playlists.Attach(playlist);
            _context.Entry(playlist).State = EntityState.Detached;
         
            await _context.SaveChangesAsync();
        }
    }
}
