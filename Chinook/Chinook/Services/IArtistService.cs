using Chinook.Models;

namespace Chinook.Services
{
    public interface IArtistService : IBaseService<Artist>
    {
        public Task<List<Artist>> GetArtists();
        public Task<Artist> GetById(long artistId);
    }
}
