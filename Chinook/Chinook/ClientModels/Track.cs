
namespace Chinook.ClientModels
{
    public class Track
    {
        public long TrackId;
        public string Name;
        public long? AlbumId;
        public long MediaTypeId;
        public long? GenreId;
        public string? Composer;
        public long Milliseconds;
        public long? Bytes;
        public byte[] UnitPrice;
        public long? PlaylistId;
        public Album? Album;
        //public virtual Genre? Genre { get; set; }
        //public virtual MediaType MediaType { get; set; } = null!;
        //public virtual List<InvoiceLine> InvoiceLines { get; set; }

        public List<Playlist> Playlists;
        public List<PlaylistTrack> PlaylistTracks;
    }
}
