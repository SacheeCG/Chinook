using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Services
{
    public class HomeService : BaseDataService<Artist>
    {
        private readonly ChinookContext _context;
        public HomeService(ChinookContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Artist>> GetArtists()
        {
            var users = await _context.Users.AsNoTracking().Include(a => a.UserPlaylists).ToListAsync();

            return _context.Artists.ToList();
        }

        public async Task<List<Album>> GetAlbumsForArtist(int artistId)
        {
            return _context.Albums.AsNoTracking().Where(a => a.ArtistId == artistId).ToList();
        }
    }
}
