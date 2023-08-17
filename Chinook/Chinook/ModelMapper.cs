using Chinook.ClientModels;
using Chinook.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Chinook
{
    public static class ModelMapper
    {
        public static ClientModels.Playlist MapPlaylistToViewModel(Models.Playlist playlist)
        {
            List<long> trackIdsInPlaylist = playlist.PlaylistTracks.Where(x => x.PlaylistId == playlist.PlaylistId).Select(pt => pt.TrackId).ToList();
            return new ClientModels.Playlist
            {
                Name = playlist.Name,
                Tracks = MapTracksToViewModel(playlist.Tracks?.ToList()),
                PlaylistTracks = ModelMapper.MapPlaylistTracksToViewModel(playlist.PlaylistTracks.ToList())

            };
        }

        public static ClientModels.PlaylistTrack MapPlaylistTrackToViewModel(Models.PlaylistTrack track)
        {
            return new ClientModels.PlaylistTrack
            {
                AlbumTitle = track.Track?.Album.Title,
                ArtistName = track.Track?.Album?.Artist?.Name,
                TrackId = track.TrackId,
                TrackName = track.Track?.Name,
                IsFavorite = track.IsFavorite
            };
        }

        public static List<ClientModels.PlaylistTrack> MapPlaylistTracksToViewModel(List<Models.PlaylistTrack> playlistTracks)
        {
            return playlistTracks.Select(MapPlaylistTrackToViewModel).ToList();
        }

        public static ClientModels.PlaylistTrack MapTrackToPlaylistTrackModel(Models.Track track)
        {
            return new ClientModels.PlaylistTrack
            {
                AlbumTitle = track.Album?.Title,
                ArtistName = track.Album?.Artist.Name,
                TrackId = track.TrackId,
                TrackName = track.Name,
                IsFavorite = track.PlaylistTracks != null ? track.PlaylistTracks.Where(x=>x.TrackId == track.TrackId).Select(x=>x.IsFavorite).FirstOrDefault() : false
            };
        }

        public static List<ClientModels.PlaylistTrack> MapPlaylistsToViewModel(List<Models.Track> playlists)
        {
            return playlists.Select(MapTrackToPlaylistTrackModel).ToList();
        }

        public static ClientModels.Artist MapArtistToViewModel(Models.Artist artist)
        {
            return new ClientModels.Artist
            {
                Name = artist.Name,
                ArtistId = artist.ArtistId,
                Albums = MapAlbumsToViewModel(artist.Albums.ToList())
            };
        }

        public static List<ClientModels.Artist> MapArtistsToViewModel(List<Models.Artist> artists)
        {
            return artists.Select(MapArtistToViewModel).ToList();
        }

        public static ClientModels.Album MapAlbumToViewModel(Models.Album album)
        {
            return new ClientModels.Album
            {
                AlbumId = album.AlbumId,
                Title = album.Title,
                ArtistId = album.ArtistId,
                ArtistName = album.Artist.Name
            };
        }

        public static List<ClientModels.Album> MapAlbumsToViewModel(List<Models.Album> albums)
        {
            return albums.Select(MapAlbumToViewModel).ToList();
        }

        public static ClientModels.Track MapTrackToViewModel(Models.Track track)
        {
            return new ClientModels.Track
            {
                AlbumId = track.AlbumId,
                Bytes = track.Bytes,
                TrackId = track.TrackId,
                MediaTypeId = track.MediaTypeId,
                Milliseconds = track.Milliseconds,
                Composer = track.Composer,
                GenreId = track.GenreId,
                Name = track.Name,
                PlaylistId = track.PlaylistId,
                UnitPrice = track.UnitPrice
            };
        }

        public static List<ClientModels.Track> MapTracksToViewModel(List<Models.Track> albums)
        {
            return albums.Select(MapTrackToViewModel).ToList();
        }
    }
}
