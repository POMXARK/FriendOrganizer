using FriendOrganizer.Model;

namespace FriendOrganizer.DataAccess
{
    public interface IFriendLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetFriendLookupAsync();
    }
}