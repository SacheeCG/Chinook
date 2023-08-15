using Chinook.ClientModels;
using Chinook.Models;
using Microsoft.EntityFrameworkCore;
using Playlist = Chinook.Models.Playlist;

namespace Chinook.Services
{
    public class ArtistService : BaseDataService<Playlist>
    {
        private readonly ChinookContext _context;
        public ArtistService(ChinookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ClientModels.PlaylistTrack>> GetAllTracksByArtist(long artistId, string currentUserId)
        {
            return _context.Tracks.AsNoTracking().Where(a => a.Album.ArtistId == artistId)
                .Include(a => a.Album).Select(t => new ClientModels.PlaylistTrack() 
                { AlbumTitle = (t.Album == null ? "-" : t.Album.Title), TrackId = t.TrackId, TrackName = t.Name, IsFavorite = t.IsFavorite }).ToList();
        }

        public async Task<Track> GetTrackById(long trackId)
        {
            return await _context.Tracks.AsNoTracking().Where(a => a.TrackId == trackId).FirstOrDefaultAsync();
        }

        public async Task<Artist> GetById(long artistId)
        {
            return await _context.Artists.AsNoTracking().Where(a => a.ArtistId == artistId).FirstOrDefaultAsync();
        }

        public async Task CreateOrUpdateTrackAsync(Track selectedTrack, long playlistId)
        {
            var existingTrack = await _context.Tracks.AsNoTracking().Where(x => x.PlaylistId == playlistId && x.TrackId == selectedTrack.TrackId).FirstOrDefaultAsync();
            if (existingTrack == null)
            {
                //_context.Tracks.Add(selectedTrack);
                _context.Entry(selectedTrack).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
            public async Task CreateOrUpdatePlaylistTrackAsync(Models.PlaylistTrack selectedTrack)
        {
            var existingTrack = await _context.PlaylistTracks.AsNoTracking().Where(x=>x.PlaylistId == selectedTrack.PlaylistId && x.TrackId == selectedTrack.TrackId).FirstOrDefaultAsync();
            if (existingTrack == null)
            {
                _context.PlaylistTracks.Add(selectedTrack);
                _context.Entry(selectedTrack).State = EntityState.Added;
                await _context.SaveChangesAsync();
            }
            //else
            //{
            //    _context.PlaylistTracks.Add(selectedTrack);
            //    _context.Entry(selectedTrack).State = EntityState.Added;
            //    await _context.SaveChangesAsync();
            //}
        }

        public async Task UpdateTrackAsync(Track selectedTrack)
        {
            _context.Tracks.Add(selectedTrack);
            _context.Entry(selectedTrack).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
