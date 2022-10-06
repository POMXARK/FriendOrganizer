using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private Func<FriendOrganizerDbContext> _contextCreator;

        public FriendDataService(Func<FriendOrganizerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public IEnumerable<Friend> GetAll()
        {
            using (var ctx = _contextCreator())
            {
                return ctx.Friends.AsNoTracking().ToList();
            }

            // TODO: Load data from real database
            //yield return new Friend { FirstName = "Kanye", LastName = "Erickson" };
            //yield return new Friend { FirstName = "Millie-Rose", LastName = "Diaz" };
            //yield return new Friend { FirstName = "Ellie", LastName = "Roach" };
            //yield return new Friend { FirstName = "Francesco", LastName = "Walter" };
        }

        public async Task<List<Friend>> GetAllAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Friends.AsNoTracking().ToListAsync();
            }
        }

        public async Task<Friend> GetByIdAsync(int friendId)
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Friends.AsNoTracking().SingleAsync(f => f.Id == friendId);
            }
        }
    }
}
