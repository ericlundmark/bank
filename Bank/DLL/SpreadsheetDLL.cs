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

        public void Create(Spreadsheet spreadsheet)
        {
            db.Spreadsheets.Add(spreadsheet);
            db.SaveChanges();
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

        public void Delete(Spreadsheet spreadsheet)
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
            return db.Set<Spreadsheet>();
        }
    }
}