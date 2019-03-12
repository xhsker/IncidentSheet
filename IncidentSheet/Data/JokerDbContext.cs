using System;
using System.Collections.Generic;
using System.Text;
using IncidentSheet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IncidentSheet.Data
{
        public class JokerDbContext : DbContext
        {
            public DbSet<Joker> Jokers { get; set; }
            public DbSet<User> Users { get; set; }

            public JokerDbContext(DbContextOptions<JokerDbContext> options)
                : base(options)
            { }

        }
    }
