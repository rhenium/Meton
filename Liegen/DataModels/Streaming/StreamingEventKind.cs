namespace Meton.Liegen.DataModels.Streaming
{
    public enum StreamingEventKind
    {
        Block,
        Unblock,
        Favorite,
        Unfavorite,
        Follow,
        ListCreated,
        ListDestroyed,
        ListUpdated,
        ListMemberAdded,
        ListMemberRemoved,
        ListUserSubscribed,
        ListUserUnsubscribed,
        UserUpdate,
        Undefined,

        Delete,
        Status,
        DirectMessage,
        Friends
    }
}
