using Chinook.Models;

namespace Chinook.Services
{
    public interface IPlaylistService : IBaseService<Playlist>
    {
        public Task<Playlist> FindPlaylistId(long id);
        public Task<Playlist> GetPlaylistByName(string playlistName, string userId);
        public Task<Playlist> GetFavoritePlaylistByUser(long playlistId, string currentUserId);
        public Task<List<Playlist>> GetUserPlaylists(string currentUserId);
        public Task UpdatePlaylistAsync(Playlist playlist);
    }
}
