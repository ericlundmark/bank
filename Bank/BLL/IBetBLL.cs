using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BLL
{
    interface IBetBLL
    {
        public void Create(Bet bet);
        public void Update(Bet bet);
        public void Delete(Bet bet);
    }
}
