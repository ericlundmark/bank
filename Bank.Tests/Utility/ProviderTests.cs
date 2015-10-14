using System.Collections.Generic;
using Bank.Models;
using Bank.Repositories;
using Bank.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Provider = Bank.Utility.ProviderService;

namespace Bank.Tests.Utility
{
    [TestClass]
    public class ProviderTests
    {
        [TestMethod]
        public void Run()
        {
            var mockCollector = new Mock<IDataCollector>();
            mockCollector.Setup(c => c.CollectData()).Returns("data");

            var mockParser = new Mock<ICompetitionParser>();
            mockParser.Setup(p => p.Parse("data")).Returns(new List<Competition>());

            var mockRepository = new Mock<ICompetitionRepository>();

            var provider = new Mock<Provider> { CallBase = true };
            provider.Object.Collector = mockCollector.Object;
            provider.Object.Competitions = mockRepository.Object;
            provider.Object.Parser = mockParser.Object;

            provider.Object.Run();

            mockRepository.Verify(r => r.Create(new List<Competition>()));
        }
    }
}