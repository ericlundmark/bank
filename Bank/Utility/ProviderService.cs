using Bank.Repositories;

namespace Bank.Utility
{
    public abstract class ProviderService : IProviderService
    {
        public abstract string Name { get; }
        public ICompetitionRepository Competitions { get; set; }
        public ICompetitionParser Parser { get; set; }
        public IDataCollector Collector { get; set; }
        public string Url { get; set; }


        public void Run()
        {
            var data = Collector.CollectData();
            var competitions = Parser.Parse(data);
            Competitions.Add(competitions);
        }
    }
}