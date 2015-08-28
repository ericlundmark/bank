using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bank.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }

        public DbSet<Spreadsheet> Spreadsheets { get; set; }
        public DbSet<Wager> Wagers { get; set; }
        public DbSet<Competition> Competitions { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}