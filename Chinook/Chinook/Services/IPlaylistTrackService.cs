using Chinook.Models;

namespace Chinook.Services
{
    public interface IPlaylistTrackService : IBaseService<PlaylistTrack>
    {
        public Task CreatePlaylistTrackAsync(PlaylistTrack selectedTrack);
        public Task<PlaylistTrack> GetByIds(long playlistId, long trackId);
        public Task UpdatePlaylistTrackAsync(PlaylistTrack selectedTrack);
        public Task DeletePlaylistTrackAsync(PlaylistTrack selectedTrack);
    }
}
