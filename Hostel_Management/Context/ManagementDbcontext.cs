using Hostel_Management.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Hostel_Management.Context
{
    public class ManagementDbcontext:DbContext
    {
        public ManagementDbcontext(DbContextOptions<ManagementDbcontext> options)
        : base(options)
        {
        }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=DESKTOP-7I1DFBE\\SQLEXPRESS01; database=Hostel_Management;Trusted_Connection=True;Encrypt=False");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-many relationship between User and Staff
            modelBuilder.Entity<Staff>()
                .HasOne(s => s.User)  // Each Staff belongs to one User
                .WithMany(u => u.Staffmembers) // Each User has many Staff members
                .HasForeignKey(s => s.UserId) // Foreign key in Staff
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete

            // Configure one-to-many relationship between User and Room
            modelBuilder.Entity<Room>()
                .HasOne(r => r.User) // Each Room belongs to one User
                .WithMany(u => u.Rooms) // Each User can have many Rooms
                .HasForeignKey(r => r.UserId) // Foreign key in Room
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete

            base.OnModelCreating(modelBuilder);
        }

    }
}
