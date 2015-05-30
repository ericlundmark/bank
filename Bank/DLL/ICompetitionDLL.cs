using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DLL
{
    interface ICompetitionDLL
    {
        void Create(Competition competition);
        void Save(Competition competition);
        void Remove(Competition competition);
    }
}
