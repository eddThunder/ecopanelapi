using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.DataModel
{
    public partial class ecopanelDBContext : DbContext
    {
        public ecopanelDBContext()
        {
        }

        public ecopanelDBContext(DbContextOptions<ecopanelDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UsersRoles> UsersRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ecopanelDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Username).HasMaxLength(20);
            });

            modelBuilder.Entity<UsersRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UsersRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UsersRole__RoleI__276EDEB3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UsersRole__UserI__286302EC");
            });
        }
    }
}
