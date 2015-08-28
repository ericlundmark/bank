using Bank.Models;

namespace Bank.Repositories
{
    interface IWagerRepository
    {
        void Create(Wager bet);
        void Save(Wager bet);
        void Remove(Wager bet);
    }
}
