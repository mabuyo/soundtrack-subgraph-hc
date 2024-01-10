using ApolloGraphQL.HotChocolate.Federation;
using SpotifyWeb;

namespace Odyssey.Liftoff;

[Key("id")]
public class Recipe
{
    [ID]
    public string Id { get; }

    [External]
    public string? Name { get; }

    [GraphQLDescription(
        "A list of recommended playlists for this particular recipe. Returns 1 to 3 playlists."
    )]
    [Requires("name")]
    public async Task<List<Playlist>> RecommendedPlaylists(SpotifyService spotifyService)
    {
        var response = await spotifyService.SearchAsync(
            this.Name,
            new List<SearchType> { SearchType.Playlist },
            3,
            0,
            null
        );

        return response.Playlists.Items.Select(item => new Playlist(item)).ToList();
    }

    [ReferenceResolver]
    public static Recipe ReferenceResolver(string id, string name)
    {
        return new Recipe(id, name);
    }

    public Recipe(string id, string? name)
    {
        Id = id;

        if (name != null)
        {
            Name = name;
        }
    }
}
