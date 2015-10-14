using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using Bank.Models;
using Bank.Utility;

namespace Bank.Providers.Pinnacle
{
    public class PinnacleFeedParser : ICompetitionParser
    {
        public IEnumerable<Competition> Parse(string data)
        {
            var doc = new XmlDocument();
            doc.LoadXml(data);
            var competitions = new List<Competition>();
            var events = doc.SelectNodes(@"//event");
            if (events == null) return competitions;

            foreach (XmlNode childNode in events)
            {
                var competition = new Competition();
                competition.ExternalId = ParseExternalId(childNode);
                competition.Participants = ParseParticipants(childNode);
                competition.DateTime = DateTime.Parse(ParseDateTime(childNode)).ToUniversalTime();
                competitions.Add(competition);
            }
            return competitions;
        }

        private string ParseExternalId(XmlNode childNode)
        {
            var id = childNode.SelectNodes(@"./gamenumber")?.Cast<XmlNode>().First();

            return id?.InnerText ?? "";
        }

        private static string ParseDateTime(XmlNode childNode)
        {
            return childNode.SelectNodes(@"./event_datetimeGMT")?.Cast<XmlNode>().First().InnerText ?? "";
        }

        private static IEnumerable<string> ParseParticipants(XmlNode childNode)
        {
            var participants = childNode.SelectNodes(@".//participant/participant_name");
            if (participants == null) return new List<string>();
            return participants.Cast<XmlNode>().Select(e => e.InnerText);
        }
    }
}