using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BlazorServer.Models
{
    public partial class Net6dbContext : DbContext
    {
        public Net6dbContext()
        {
        }

        public Net6dbContext(DbContextOptions<Net6dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=net6db;Trusted_connection=True");
            }
        }
    }
}
