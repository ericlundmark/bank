using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Bank.Models;

namespace Bank.Repositories
{
    public class CompetitionRepository : ICompetitionRepository
    {
        private readonly ApplicationDbContext _db;

        public CompetitionRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Create(Competition competition)
        {
            _db.Competitions.Add(competition);
            _db.SaveChanges();
        }

        public void Save(Competition competition)
        {
            _db.Entry(competition).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Remove(Competition competition)
        {
            _db.Competitions.Remove(competition);
            _db.SaveChanges();
        }

        public void Create(IEnumerable<Competition> competitions)
        {
            _db.Competitions.AddRange(competitions);
            _db.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}