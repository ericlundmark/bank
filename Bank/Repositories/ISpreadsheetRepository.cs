using System.Linq;
using Bank.Models;

namespace Bank.Repositories
{
    public interface ISpreadsheetRepository
    {
        Spreadsheet Create(Spreadsheet spreadsheet);
        Spreadsheet Find(int id);
        void Save(Spreadsheet spreadsheet);
        void Remove(Spreadsheet spreadsheet);
        void Dispose(bool disposing);
        IQueryable<Spreadsheet> List();
        bool SpreadsheetExists(int id);
    }
}