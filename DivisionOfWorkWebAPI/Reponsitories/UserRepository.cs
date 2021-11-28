using DivisionOfWorkWebAPI.Database;
using DivisionOfWorkWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivisionOfWorkWebAPI.Reponsitories
{
    public class UserRepository : IUserRepository
    {
        private readonly DivisionOfWorkDbContext _context;

        public UserRepository(DivisionOfWorkDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUserList()
        {
            return await _context.Users.ToListAsync();
        }

    }
}
    

