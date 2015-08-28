using System.Linq;
using Bank.Models;
using Bank.Repositories;

namespace Bank.BLL
{
    public class SpreadsheetBLL : ISpreadsheetBLL
    {
        private readonly ISpreadsheetRepository _dataLayer;

        public SpreadsheetBLL(ISpreadsheetRepository dataLayer)
        {
            this._dataLayer = dataLayer;
        }

        public Spreadsheet Create(Spreadsheet spreadsheet)
        {
            return _dataLayer.Create(spreadsheet);
        }

        public Spreadsheet Find(int id)
        {
            return _dataLayer.Find(id);
        }

        public void Save(Spreadsheet spreadsheet)
        {
            _dataLayer.Save(spreadsheet);
        }

        public void Remove(Spreadsheet spreadsheet)
        {
            _dataLayer.Remove(spreadsheet);
        }

        public void AddBet(Spreadsheet spreadsheet, Wager bet)
        {
            spreadsheet.Wagers.Add(bet);
            _dataLayer.Save(spreadsheet);
        }

        public void Dispose(bool disposing)
        {
            _dataLayer.Dispose(disposing);
        }

        public IQueryable<Spreadsheet> List()
        {
            return _dataLayer.List();
        }

        public bool SpreadsheetExists(int id)
        {
            return _dataLayer.SpreadsheetExists(id);
        }
    }
}