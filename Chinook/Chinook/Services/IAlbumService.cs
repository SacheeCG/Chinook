using Chinook.Models;

namespace Chinook.Services
{
    public interface IAlbumService : IBaseService<Album>
    {
        public Task<List<Album>> GetAlbums();
        public Task<Album> GetAlbumByName(string albumName);
        public Task<List<Album>> GetAlbumsByArtist(int artistId);
    }
}
