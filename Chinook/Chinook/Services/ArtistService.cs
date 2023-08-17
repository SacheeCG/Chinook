using Chinook.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Playlist = Chinook.Models.Playlist;

namespace Chinook.Services
{
    public class ArtistService : BaseService<Artist>, IArtistService
    {
        private readonly ChinookContext _context;
        public ArtistService(ChinookContext context) : base(context)
        {
            _context = context;
        }     

        public async Task<Artist> GetById(long artistId)
        {
            return await _context.Artists.AsNoTracking().Where(a => a.ArtistId == artistId).FirstOrDefaultAsync();
        }


        public async Task<List<Artist>> GetArtists()
        {
            var users = await _context.Users.AsNoTracking().Include(a => a.UserPlaylists).ToListAsync();

            return _context.Artists.ToList();
        }

    }
}
