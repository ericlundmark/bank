using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BLL
{
    interface ISpreadsheetBLL
    {
        public void Create(Spreadsheet spreadsheet);
        public Spreadsheet Find(int id);
        public void Save(Spreadsheet spreadsheet);
        public void Delete(Spreadsheet spreadsheet);
        public void AddBet(Spreadsheet spreadsheet, Bet bet);

        void Dispose(bool disposing);

        IQueryable<Spreadsheet> List();

        bool SpreadsheetExists(int id);
    }
}
