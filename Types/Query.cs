using SpotifyWeb;

namespace Odyssey.Liftoff;

public class Query
{
    [GraphQLDescription(
        "A list of Spotify featured playlists (shown, for example, on a Spotify player's 'Browse' tab)."
    )]
    public async Task<List<Playlist>> FeaturedPlaylists(SpotifyService spotifyService)
    {
        var response = await spotifyService.GetFeaturedPlaylistsAsync();
        return response.Playlists.Items.Select(item => new Playlist(item)).ToList();
    }

    [GraphQLDescription("A playlist owned by a Spotify user.")]
    public async Task<Playlist?> GetPlaylist([ID] string id, SpotifyService spotifyService)
    {
        var response = await spotifyService.GetPlaylistAsync(id);
        var playlist = new Playlist(response);
        return playlist;
    }
}
