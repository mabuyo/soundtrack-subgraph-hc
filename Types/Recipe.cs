using ApolloGraphQL.HotChocolate.Federation;

namespace Odyssey.Liftoff;

[Key("id")]
public class Recipe
{
    [ID]
    public string Id { get; }

    [GraphQLDescription(
        "A list of recommended playlists for this particular recipe. Returns 1 to 3 playlists."
    )]
    public List<Playlist> RecommendedPlaylists()
    {
        return new List<Playlist>
        {
            new Playlist("1", "GraphQL Groovin'"),
            new Playlist("2", "Graph Explorer Jams"),
            new Playlist("3", "Interpretive GraphQL Dance")
        };
    }

    [ReferenceResolver]
    public static Recipe ReferenceResolver(string id)
    {
        return new Recipe(id);
    }

    public Recipe(string id)
    {
        Id = id;
    }
}
