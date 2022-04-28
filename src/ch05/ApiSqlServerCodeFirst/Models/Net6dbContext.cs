using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiSqlServer.Models
{
    public partial class net6dbContext : DbContext
    {
        public net6dbContext()
        {
        }

        public net6dbContext(DbContextOptions<net6dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WpPost> WpPosts => Set<WpPost>();
        public virtual DbSet<WpUser> WpUsers => Set<WpUser>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=net6db;Trusted_connection=True");
            }
        }
    }
}
