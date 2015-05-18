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
        ISpreadsheetDLL dataLayer;
        public SpreadsheetBLL(ISpreadsheetDLL dataLayer)
        {
            this.dataLayer = dataLayer;
        }


        public void Create(Spreadsheet spreadsheet)
        {
            dataLayer.Create(spreadsheet);
        }

        public Spreadsheet Find(int id)
        {
            return dataLayer.Find(id);
        }

        public void Save(Spreadsheet spreadsheet)
        {
            dataLayer.Save(spreadsheet);
        }

        public void Delete(Spreadsheet spreadsheet)
        {
            dataLayer.Delete(spreadsheet);
        }

        public void AddBet(Spreadsheet spreadsheet, Models.Bet bet)
        {
            spreadsheet.bets.Add(bet);
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
    }
}