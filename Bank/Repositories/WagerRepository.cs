using System.Data.Entity;
using Bank.DLL;
using Bank.Models;

namespace Bank.Repositories
{
    public class WagerRepository : IWagerRepository
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public void Create(Wager bet)
        {
            db.Wagers.Add(bet);
            db.SaveChanges();
        }

        public void Save(Wager bet)
        {
            db.Entry(bet).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Remove(Wager bet)
        {
            db.Wagers.Remove(bet);
            db.SaveChanges();
        }
    }
}