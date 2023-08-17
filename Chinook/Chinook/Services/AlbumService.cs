using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Services
{
    public class AlbumService : BaseService<Album>, IAlbumService
    {
        private readonly ChinookContext _context;
        public AlbumService(ChinookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Album>> GetAlbums()
        {
            return await _context.Albums.AsNoTracking().Include(p => p.Artist).ToListAsync();
        }

        public async Task<Album> GetAlbumByName(string albumName)
        {
            return await _context.Albums.AsNoTracking().Include(p => p.Artist).Where(a => a.Title == albumName).FirstOrDefaultAsync();
        }

        public async Task<List<Album>> GetAlbumsByArtist(int artistId)
        {
            return _context.Albums.AsNoTracking().Where(a => a.ArtistId == artistId).ToList();
        }
    }
}
