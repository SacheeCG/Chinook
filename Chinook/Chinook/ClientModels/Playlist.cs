namespace Chinook.ClientModels;

public class Playlist
{
    public string Name { get; set; }
    public List<PlaylistTrack> PlaylistTracks { get; set; }
    public List<Track> Tracks { get; set; }
}