namespace Odyssey.Liftoff;

public class AddItemsToPlaylistPayload
{
    [GraphQLDescription("Similar to HTTP status code, represents the status of the mutation.")]
    public int Code { get; set; }

    [GraphQLDescription("Indicates whether the mutation was successful.")]
    public bool Success { get; set; }

    [GraphQLDescription("Human-readable message for the UI.")]
    public string Message { get; set; }

    [GraphQLDescription("The playlist that contains the newly added items.")]
    public Playlist? Playlist { get; set; }

    public AddItemsToPlaylistPayload(int code, bool success, string message)
    {
        Code = code;
        Success = success;
        Message = message;
    }

    public AddItemsToPlaylistPayload(int code, bool success, string message, Playlist playlist)
    {
        Code = code;
        Success = success;
        Message = message;
        Playlist = playlist;
    }
}
