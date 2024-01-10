using ApolloGraphQL.HotChocolate.Federation;
using SpotifyWeb;

namespace Odyssey.Liftoff;

[GraphQLDescription("Information about a playlist owned by a Spotify user")]
[Key("id")]
public class Playlist
{
    [GraphQLDescription("The Spotify ID for the playlist.")]
    [ID]
    public string Id { get; }

    [GraphQLDescription("The name of the playlist.")]
    public string Name { get; set; }

    [GraphQLDescription(
        "The playlist description. _Only returned for modified, verified playlists, otherwise null_."
    )]
    public string? Description { get; set; }

    [GraphQLDescription("The playlist's tracks.")]
    public async Task<List<Track>> Tracks(SpotifyService spotifyService)
    {
        if (_tracks != null)
        {
            return _tracks;
        }
        else
        {
            var response = await spotifyService.GetPlaylistsTracksAsync(this.Id);
            return response.Items.Select(item => new Track(item.Track)).ToList();
        }
    }

    private List<Track> _tracks;

    public Playlist(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public Playlist(PlaylistSimplified obj)
    {
        Id = obj.Id;
        Name = obj.Name;
        Description = obj.Description;
    }

    public Playlist(SpotifyWeb.Playlist obj)
    {
        Id = obj.Id;
        Name = obj.Name;
        Description = obj.Description;

        _tracks = obj.Tracks.Items.Select(item => new Track(item.Track)).ToList();
    }
}
