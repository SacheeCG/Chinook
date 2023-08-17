
namespace Chinook.ClientModels
{
    public class Album
    {
        public long AlbumId;
        public string Title;
        public long ArtistId;

        public string ArtistName;
        public Artist Artist;

        public List<Track> Tracks { get; set; }
    }
}
