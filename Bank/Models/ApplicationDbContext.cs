﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bank.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        public virtual DbSet<Spreadsheet> Spreadsheets { get; set; }
        public virtual DbSet<Wager> Wagers { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Bank.Models.Provider> Providers { get; set; }
    }
}