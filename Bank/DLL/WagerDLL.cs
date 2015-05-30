using Bank.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bank.DLL
{
    public class WagerDLL : IWagerDLL
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Create(Wager bet)
        {
            db.Bets.Add(bet);
            db.SaveChanges();
        }

        public void Save(Wager bet)
        {
            db.Entry(bet).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Remove(Wager bet)
        {
            db.Bets.Remove(bet);
            db.SaveChanges();
        }
    }
}