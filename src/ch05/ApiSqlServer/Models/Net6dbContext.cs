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

        public virtual DbSet<WpPost> WpPosts { get; set; } = null!;
        public virtual DbSet<WpUser> WpUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=net6db;Trusted_connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WpPost>(entity =>
            {
                entity.ToTable("wp_posts");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CommentCount).HasColumnName("comment_count");

                entity.Property(e => e.CommentStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("comment_status");

                entity.Property(e => e.Guid)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("guid");

                entity.Property(e => e.MenuOrder).HasColumnName("menu_order");

                entity.Property(e => e.PingStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ping_status");

                entity.Property(e => e.Pinged)
                    .HasColumnType("text")
                    .HasColumnName("pinged");

                entity.Property(e => e.PostAuthor).HasColumnName("post_author");

                entity.Property(e => e.PostContent)
                    .HasColumnType("text")
                    .HasColumnName("post_content");

                entity.Property(e => e.PostContentFiltered)
                    .HasColumnType("text")
                    .HasColumnName("post_content_filtered");

                entity.Property(e => e.PostDate)
                    .HasColumnType("datetime")
                    .HasColumnName("post_date");

                entity.Property(e => e.PostDateGmt)
                    .HasColumnType("datetime")
                    .HasColumnName("post_date_gmt");

                entity.Property(e => e.PostExcerpt)
                    .HasColumnType("text")
                    .HasColumnName("post_excerpt");

                entity.Property(e => e.PostMimeType)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("post_mime_type");

                entity.Property(e => e.PostModified)
                    .HasColumnType("datetime")
                    .HasColumnName("post_modified");

                entity.Property(e => e.PostModifiedGmt)
                    .HasColumnType("datetime")
                    .HasColumnName("post_modified_gmt");

                entity.Property(e => e.PostName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("post_name");

                entity.Property(e => e.PostParent).HasColumnName("post_parent");

                entity.Property(e => e.PostPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("post_password");

                entity.Property(e => e.PostStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("post_status");

                entity.Property(e => e.PostTitle)
                    .HasColumnType("text")
                    .HasColumnName("post_title");

                entity.Property(e => e.PostType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("post_type");

                entity.Property(e => e.ToPing)
                    .HasColumnType("text")
                    .HasColumnName("to_ping");
            });

            modelBuilder.Entity<WpUser>(entity =>
            {
                entity.ToTable("wp_users");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.UserActivationKey)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_activation_key");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_email");

                entity.Property(e => e.UserLogin)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("user_login");

                entity.Property(e => e.UserNicename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_nicename");

                entity.Property(e => e.UserPass)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_pass");

                entity.Property(e => e.UserRegistered)
                    .HasColumnType("datetime")
                    .HasColumnName("user_registered");

                entity.Property(e => e.UserStatus).HasColumnName("user_status");

                entity.Property(e => e.UserUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_url");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
