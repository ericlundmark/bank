using System;
using Bank.Models;
using Bank.Providers.Pinnacle;
using Bank.Repositories;
using Bank.Utility;

namespace Bank.Providers
{
    public class PinnacleProvider : ProviderService
    {
        public override string Name => "Pinnacle";
        public override TimeSpan Interval => new TimeSpan(0, 0, 15, 00);

        public PinnacleProvider()
        {
            Collector = new PinnacleFeedCollector();
            Parser = new PinnacleFeedParser();
            Competitions = new CompetitionRepository(new ApplicationDbContext());
        }
    }
}