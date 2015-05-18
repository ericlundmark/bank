using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DLL
{
    interface IBetDLL
    {
        public void Create(Bet bet);
        public void Save(Bet bet);
        public void Delete(Bet bet);
    }
}
