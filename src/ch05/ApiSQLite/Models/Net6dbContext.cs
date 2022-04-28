using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Sqlite;


#nullable disable

namespace ApiSQLite.Models
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

        public virtual DbSet<WpPost> WpPosts { get; set; }
        public virtual DbSet<WpUser> WpUsers { get; set; }
    }
}
