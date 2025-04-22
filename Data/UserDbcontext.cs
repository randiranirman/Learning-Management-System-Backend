using Microsoft.EntityFrameworkCore;
using UserManagementService.Models;

namespace UserManagementService.Data
{
    public class UserDbcontext(DbContextOptions<UserDbcontext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }    
        public DbSet<Teacher> Teachers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Student>().ToTable("Students");

            modelBuilder.Entity<Admin>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Admin>( a => a.Id )
                .OnDelete(DeleteBehavior.Cascade );

            modelBuilder.Entity<Teacher>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Teacher>(a => a.Id).OnDelete(DeleteBehavior.Cascade);

         modelBuilder.Entity<Student>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Student>(a => a.Id).OnDelete(DeleteBehavior.Cascade);


        }

        



    }
}
