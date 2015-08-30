using System.Collections.Generic;
using Bank.Models;

namespace Bank.Utility
{
    public interface ICompetitionParser
    {
        IEnumerable<Competition> Parse(string data);
    }
}