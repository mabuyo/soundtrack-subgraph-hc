namespace Odyssey.Liftoff;

public class Mutation
{
    [GraphQLDescription("Add one or more items to a user's playlist.")]
    public AddItemsToPlaylistPayload AddItemsToPlaylist()
    {
        return new AddItemsToPlaylistPayload(
            200,
            true,
            "Successfully added  items to playlist.",
            new Playlist("748GuzX7eACeswGoJt6hOw", "Apollo Client (web)")
        );
    }
}
