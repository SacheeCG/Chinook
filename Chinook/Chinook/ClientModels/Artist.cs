using Chinook.Models;

namespace Chinook.ClientModels
{
    public class Artist
    {
        public long ArtistId;
        public string? Name;
        public List<Album> Albums;
    }
}
