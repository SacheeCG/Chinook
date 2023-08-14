using Chinook.ClientModels;
using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Services
{
    public class ArtistService : BaseDataService<Artist>
    {
        private readonly ChinookContext _context;
        public ArtistService(ChinookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<PlaylistTrack>> GetAllTracksByArtist(long artistId, string currentUserId)
        {
            return _context.Tracks.Where(a => a.Album.ArtistId == artistId)
                .Include(a => a.Album).Select(t => new ClientModels.PlaylistTrack() 
                { AlbumTitle = (t.Album == null ? "-" : t.Album.Title), TrackId = t.TrackId, TrackName = t.Name, IsFavorite = t.IsFavorite }).ToList();
        }

        public async Task<Track> GetAllTrackById(long trackId)
        {
            return _context.Tracks.Where(a => a.TrackId == trackId).FirstOrDefault();
        }

    }
}
