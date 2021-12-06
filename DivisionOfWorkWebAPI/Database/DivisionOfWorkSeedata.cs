using DivisionOfWorkWebAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivisionOfWorkWebAPI.Database
{
    public class DivisionOfWorkSeedata
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public async System.Threading.Tasks.Task SeedAsync(DivisionOfWorkDbContext context, ILogger<DivisionOfWorkSeedata> logger)
        {
            if (!context.Users.Any())
            {
                var user = new User()
                {
                    Id = 1,
                    FirstName = "Mr",
                    LastName = "Nhut",
                    Email = "minhnhut123@gmail.com",
                    NormalizedEmail = "minhnhut123@gmail.com",
                    PhoneNumber = "0797709025",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "minhnhut123");
                context.Users.Add(user);
            }
            await context.SaveChangesAsync();
        }

       
    }
}
