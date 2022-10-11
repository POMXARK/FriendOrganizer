using FriendOrganizer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data.Repositories
{
    public interface IFriendRepository
    {
        IEnumerable<Friend> GetAll();
        Task<List<Friend>> GetAllAsync();
        Task<Friend> GetByIdAsync(int friendId);
        Task SaveAsync();
    }
}