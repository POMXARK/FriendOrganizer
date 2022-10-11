﻿using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private FriendOrganizerDbContext _context;

        public FriendRepository(FriendOrganizerDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Friend> GetAll()
        {
            return _context.Friends.ToList();

            // TODO: Load data from real database
            //yield return new Friend { FirstName = "Kanye", LastName = "Erickson" };
            //yield return new Friend { FirstName = "Millie-Rose", LastName = "Diaz" };
            //yield return new Friend { FirstName = "Ellie", LastName = "Roach" };
            //yield return new Friend { FirstName = "Francesco", LastName = "Walter" };
        }

        public async Task<List<Friend>> GetAllAsync()
        {
            return await _context.Friends.ToListAsync();
        }

        public async Task<Friend> GetByIdAsync(int friendId)
        {
            return await _context.Friends.SingleAsync(f => f.Id == friendId);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}