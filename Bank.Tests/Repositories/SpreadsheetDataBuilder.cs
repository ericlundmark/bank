using System.Runtime.InteropServices;
using Bank.Models;

namespace Bank.Tests.Repositories
{
    public class SpreadsheetDataBuilder
    {
        private string _name;
        private ApplicationUser _creator;
        private double? _investment;
        private double? _balance;

        public SpreadsheetDataBuilder WithRequiredValues()
        {
            _name = "Name";
            _creator = new ApplicationUser();
            _investment = 1000;
            _balance = 100;
            return this;
        }
        public Spreadsheet Build()
        {
            return new Spreadsheet(_name, _creator, _investment, _balance);
        }

        public SpreadsheetDataBuilder WithCreator(ApplicationUser creator)
        {
            _creator = creator;
            return this;
        }

        public SpreadsheetDataBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public SpreadsheetDataBuilder WithInvestement(double? investment)
        {
            _investment = investment;
            return this;
        }
    }
}