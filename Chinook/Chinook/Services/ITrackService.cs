using Chinook.Models;

namespace Chinook.Services
{
    public interface ITrackService : IBaseService<Track>
    {
        public Task<List<Track>> GetTracksByArtistId(long artistId);
        public Task<Track> GetTrackById(long trackId);
        public Task UpdateTrackAsync(Track selectedTrack);
        public Task UpdateTrackAsync(Track selectedTrack, long playlistId);
    }
}
