using System;
using System.Threading;
using Bank.Repositories;

namespace Bank.Utility
{
    public abstract class ProviderService : IProviderService
    {
        public abstract string Name { get; }
        public abstract TimeSpan Interval { get; }
        public ICompetitionRepository Competitions { get; set; }
        public ICompetitionParser Parser { get; set; }
        public IDataCollector Collector { get; set; }

        private Timer _timer;
        public void RunWithInterval()
        {
            _timer = new Timer((e) =>
            {
                Run();
            }, null, 0, (int)Interval.TotalMilliseconds);
        }
        public void Run()
        {
            var data = Collector.CollectData();
            var competitions = Parser.Parse(data);
            Competitions.Create(competitions);
        }

        public void Stop()
        {
            _timer.Dispose();
        }
    }
}