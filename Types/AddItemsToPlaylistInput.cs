namespace Odyssey.Liftoff;

public class AddItemsToPlaylistInput
{
    [ID]
    [GraphQLDescription("The Spotify ID of the playlist.")]
    public string PlaylistId { get; set; }

    [GraphQLDescription(
        "A comma-separated list of Spotify URIs to add, can be track or episode URIs. A maximum of 100 items can be added in one request."
    )]
    public List<string> Uris { get; set; }

    [GraphQLDescription(
        "The position to insert the items, a zero-based index. For example, to insert the items in the first position: position=0; to insert the items in the third position: position=2. If omitted, the items will be appended to the playlist. Items are added in the order they are listed in the query string or request body."
    )]
    public int? Position { get; set; }

    public AddItemsToPlaylistInput(string playlistId, List<string> uris, int? position)
    {
        PlaylistId = playlistId;
        Uris = uris;
        Position = position;
    }
}
