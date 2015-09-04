using System.Data.Entity;
using System.Linq;
using Bank.Models;

namespace Bank.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly ApplicationDbContext _context;

        public ProviderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Provider Create(Provider provider)
        {
            provider = _context.Providers.Add(provider);
            _context.SaveChanges();
            return provider;
        }

        public Provider Find(int id)
        {
            return _context.Providers.Find(id);
        }

        public IQueryable<Provider> List()
        {
            return _context.Providers;
        }

        public void Save(Provider provider)
        {
            _context.Entry(provider).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}