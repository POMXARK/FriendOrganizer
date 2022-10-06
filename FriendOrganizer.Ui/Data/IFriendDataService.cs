using FriendOrganizer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public interface IFriendDataService
    {
        IEnumerable<Friend> GetAll();
        Task<List<Friend>> GetAllAsync();
        Task<Friend> GetByIdAsync(int friendId);
    }
}