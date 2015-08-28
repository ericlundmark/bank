using Bank.DLL;
using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank.BLL
{
    public class SpreadsheetBLL : ISpreadsheetBLL
    {
        private ISpreadsheetRepository dataLayer;

        public SpreadsheetBLL(ISpreadsheetRepository dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        public Spreadsheet Create(Spreadsheet spreadsheet)
        {
            return dataLayer.Create(spreadsheet);
        }

        public Spreadsheet Find(int id)
        {
            return dataLayer.Find(id);
        }

        public void Save(Spreadsheet spreadsheet)
        {
            dataLayer.Save(spreadsheet);
        }

        public void Remove(Spreadsheet spreadsheet)
        {
            dataLayer.Remove(spreadsheet);
        }

        public void AddBet(Spreadsheet spreadsheet, Models.Wager bet)
        {
            spreadsheet.Wagers.Add(bet);
            dataLayer.Save(spreadsheet);
        }


        public void Dispose(bool disposing)
        {
            dataLayer.Dispose(disposing);
        }


        public IQueryable<Spreadsheet> List()
        {
            return dataLayer.List();
        }


        public bool SpreadsheetExists(int id)
        {
            return dataLayer.SpreadsheetExists(id);
        }
    }
}