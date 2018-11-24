using System;
using Microsoft.EntityFrameworkCore;

namespace projectChallenge.Models
{
    public class ContextChallenge :DbContext
    {
        public ContextChallenge(DbContextOptions<ContextChallenge> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Agent> Agents { get; set; }
    }
}
