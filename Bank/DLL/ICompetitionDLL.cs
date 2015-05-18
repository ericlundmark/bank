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
        public void Create(Competition competition);
        public void Save(Competition competition);
        public void Delete(Competition competition);
    }
}
