using System.Data.Entity;
using System.Linq;
using Bank.Models;

namespace Bank.DLL
{
    public class SpreadsheetDll : ISpreadsheetDLL
    {
        private readonly ApplicationDbContext _db;

        public SpreadsheetDll()
        {
            _db = new ApplicationDbContext();
        }

        public SpreadsheetDll(ApplicationDbContext db)
        {
            _db = db;
        }

        public Spreadsheet Create(Spreadsheet spreadsheet)
        {
            spreadsheet = _db.Spreadsheets.Add(spreadsheet);
            _db.SaveChanges();
            return spreadsheet;
        }

        public Spreadsheet Find(int id)
        {
            return _db.Spreadsheets.Find(id);
        }

        public void Save(Spreadsheet spreadsheet)
        {
            _db.Entry(spreadsheet).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Remove(Spreadsheet spreadsheet)
        {
            _db.Spreadsheets.Remove(spreadsheet);
            _db.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }

        public IQueryable<Spreadsheet> List()
        {
            return _db.Spreadsheets;
        }

        public bool SpreadsheetExists(int id)
        {
            return _db.Spreadsheets.Count(spreadsheet => spreadsheet.Id == id) > 0;
        }
    }
}