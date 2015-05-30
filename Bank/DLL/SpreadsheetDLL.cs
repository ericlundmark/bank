using Bank.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bank.DLL
{
    public class SpreadsheetDLL : ISpreadsheetDLL
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Spreadsheet Create(Spreadsheet spreadsheet)
        {
            spreadsheet = db.Spreadsheets.Add(spreadsheet);
            db.SaveChanges();
            return spreadsheet;
        }

        public Spreadsheet Find(int id)
        {
            return db.Spreadsheets.Find(id);
        }

        public void Save(Spreadsheet spreadsheet)
        {
            db.Entry(spreadsheet).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Remove(Spreadsheet spreadsheet)
        {
            db.Spreadsheets.Remove(spreadsheet);
            db.SaveChanges();
        }



        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }


        public IQueryable<Spreadsheet> List()
        {
            return db.Spreadsheets;
        }


        public bool SpreadsheetExists(int id)
        {
            return db.Spreadsheets.Count(spreadsheet => spreadsheet.Id == id) > 0;
        }
    }
}