using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Services
{
    public class PlaylistTrackService : BaseService<PlaylistTrack>, IPlaylistTrackService
    {
        private readonly ChinookContext _context;
        public PlaylistTrackService(ChinookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PlaylistTrack> GetByIds(long playlistId, long trackId)
        {
            return await _context.PlaylistTracks.AsNoTracking().Where(x => x.PlaylistId == playlistId && x.TrackId == trackId).FirstOrDefaultAsync();
        }

        public async Task CreatePlaylistTrackAsync(PlaylistTrack selectedTrack)
        {
            var existingTrack = await _context.PlaylistTracks.AsNoTracking().Where(x => x.PlaylistId == selectedTrack.PlaylistId && x.TrackId == selectedTrack.TrackId).FirstOrDefaultAsync();

            if (!_context.PlaylistTracks.Contains(existingTrack))
            {
                await base.AddAsync(selectedTrack);
                //_context.Entry(existingTrack).State = EntityState.Added;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePlaylistTrackAsync(PlaylistTrack selectedTrack)
        {
            await base.UpdateAsync(selectedTrack);
        }

        public async Task DeletePlaylistTrackAsync(PlaylistTrack selectedTrack)
        {
            _context.Entry(selectedTrack).State = EntityState.Detached;
            _context.ChangeTracker.Clear();
            _context.PlaylistTracks.Remove(selectedTrack);
            await _context.SaveChangesAsync();
        }

    }
}
