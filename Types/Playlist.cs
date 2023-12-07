using SpotifyWeb;

namespace Odyssey.Liftoff;

[GraphQLDescription("Information about a playlist owned by a Spotify user")]
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
}
