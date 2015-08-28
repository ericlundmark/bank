using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DLL
{
    interface IWagerRepository
    {
        void Create(Wager bet);
        void Save(Wager bet);
        void Remove(Wager bet);
    }
}
