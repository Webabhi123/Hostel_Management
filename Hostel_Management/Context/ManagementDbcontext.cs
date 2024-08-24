using Hostel_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Hostel_Management.Context
{
    public class ManagementDbcontext:DbContext
    {
        public ManagementDbcontext(DbContextOptions<ManagementDbcontext> options)
        : base(options)
        {
        }
        public DbSet<Meeting> meetings { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=DESKTOP-7I1DFBE\\SQLEXPRESS01; database=Hostel_Management;Trusted_Connection=True;Encrypt=False");

        }

    }
}
