using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DLL
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
