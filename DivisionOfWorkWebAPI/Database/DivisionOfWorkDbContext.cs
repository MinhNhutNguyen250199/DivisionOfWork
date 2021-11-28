using DivisionOfWorkWebAPI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DivisionOfWorkWebAPI.Database
{
    public class DivisionOfWorkDbContext : IdentityDbContext<User, Role, int>
    {
        public DivisionOfWorkDbContext(DbContextOptions<DivisionOfWorkDbContext> options) : base(options)
        {

        }
        public DbSet<Entities.Task> Tasks { get; set; }

        
    }
}

