namespace Odyssey.Liftoff;

public class Query
{
    [GraphQLDescription(
        "A list of Spotify featured playlists (shown, for example, on a Spotify player's 'Browse' tab)."
    )]
    public List<Playlist> FeaturedPlaylists()
    {
        return new List<Playlist>
        {
            new Playlist("1", "GraphQL Groovin'"),
            new Playlist("2", "Graph Explorer Jams"),
            new Playlist("3", "Interpretive GraphQL Dance")
        };
    }
}
