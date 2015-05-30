using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BLL
{
    interface IWagerBLL
    {
        void Create(Wager bet);
        void Update(Wager bet);
        void Remove(Wager bet);
    }
}
