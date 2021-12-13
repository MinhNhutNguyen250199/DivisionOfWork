using DivisionOfWorkWebAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivisionOfWorkWebAPI.Database
{
    public static class DivisionOfWorkSeedata
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "nmna7911@gmail.com",
                NormalizedEmail = "nmna7911@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "minhnhut123"),
                SecurityStamp = string.Empty,
                FirstName = "Nhut",
                LastName = "Nguyen",
            

            });

           
        }


    }
}
