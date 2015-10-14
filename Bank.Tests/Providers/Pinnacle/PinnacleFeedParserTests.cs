using System;
using System.IO;
using System.Linq;
using System.Xml;
using Bank.Providers.Pinnacle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bank.Tests.Providers.Pinnacle
{
    [TestClass]
    public class PinnacleFeedParserTests
    {
        [TestMethod]
        [DeploymentItem(@"Providers\Pinnacle\TestFiles\xmlFeed.xml", "TestFiles")]
        public void PinnacleFeedParser_ShouldExtract_AllEvents()
        {
            var text = File.ReadAllText(@"TestFiles\xmlFeed.xml");
            var sut = new PinnacleFeedParser();
            var competitions = sut.Parse(text).ToList();
            Assert.AreEqual(1489, competitions.Count());
        }

        [TestMethod]
        [DeploymentItem(@"Providers\Pinnacle\TestFiles\xmlFeed.xml", "TestFiles")]
        public void PinnacleFeedParser_ShouldExtractAllEvents_AndAllParticipants()
        {
            var text = File.ReadAllText(@"TestFiles\xmlFeed.xml");
            var sut = new PinnacleFeedParser();
            var competitions = sut.Parse(text).ToList();
            Assert.AreEqual(1489, competitions.Count());
            var comp = competitions.First();
            Assert.AreEqual(2, comp.Participants.Count());
        }

        [TestMethod]
        [DeploymentItem(@"Providers\Pinnacle\TestFiles\xmlFeed.xml", "TestFiles")]
        public void PinnacleFeedParser_ShouldExtractAllEvents_AndDateTime()
        {
            var text = File.ReadAllText(@"TestFiles\xmlFeed.xml");
            var sut = new PinnacleFeedParser();
            var competitions = sut.Parse(text).ToList();
            Assert.AreEqual(1489, competitions.Count());
            var comp = competitions.First();
            Assert.AreEqual("2015-10-24 04:00", comp.DateTime.ToString("g"));
        }

        [TestMethod]
        [DeploymentItem(@"Providers\Pinnacle\TestFiles\xmlFeed.xml", "TestFiles")]
        public void PinnacleFeedParser_ShouldExtractAllEvents_AndExternalId()
        {
            var text = File.ReadAllText(@"TestFiles\xmlFeed.xml");
            var sut = new PinnacleFeedParser();
            var competitions = sut.Parse(text).ToList();
            Assert.AreEqual(1489, competitions.Count());
            var comp = competitions.First();
            Assert.AreEqual("506732306", comp.ExternalId);
        }
    }
}
