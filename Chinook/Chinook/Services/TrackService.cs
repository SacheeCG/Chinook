using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Services
{
    public class TrackService : BaseService<Track>, ITrackService
    {
        private readonly ChinookContext _context;
        public TrackService(ChinookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Track>> GetTracksByArtistId(long artistId)
        {
            return await _context.Tracks.AsNoTracking().Include(x => x.Album).ThenInclude(x => x.Artist).Where(a => a.Album.ArtistId == artistId).Include(x => x.PlaylistTracks).ToListAsync();
        }

        public async Task<Track> GetTrackById(long trackId)
        {
            return await _context.Tracks.AsNoTracking().Include(x => x.Album).Where(a => a.TrackId == trackId).FirstOrDefaultAsync();
        }

        public async Task UpdateTrackAsync(Track selectedTrack)
        {
            _context.Tracks.Add(selectedTrack);
            _context.Entry(selectedTrack).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTrackAsync(Track selectedTrack, long playlistId)
        {
            var existingTrack = await _context.Tracks.AsNoTracking().Where(x => x.PlaylistId == playlistId && x.TrackId == selectedTrack.TrackId).FirstOrDefaultAsync();

            if (!_context.Tracks.Contains(existingTrack))
            {
                await base.UpdateAsync(selectedTrack);
            }

        }
    }
}
