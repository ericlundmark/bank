using Bank.Models;

namespace Bank.Repositories
{
    public interface ICompetitionRepository
    {
        void Create(Competition competition);
        void Save(Competition competition);
        void Remove(Competition competition);
    }
}
