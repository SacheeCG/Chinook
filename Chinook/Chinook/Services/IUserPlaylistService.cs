using Chinook.Models;

namespace Chinook.Services
{
    public interface IUserPlaylistService : IBaseService<UserPlaylist>
    {
        public Task<List<UserPlaylist>> GetPlaylistsByUser(string userId);
        public Task CreateUserPlaylistAsync(UserPlaylist playlist, long playlistId);
    }
}
