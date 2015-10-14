using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Bank.Utility;

namespace Bank.Providers.Pinnacle
{
    public class PinnacleFeedCollector : IDataCollector
    {
        private const string Url = @"http://xml.pinnaclesports.com/pinnacleFeed.aspx";

        public string CollectData()
        {
            using (var client = new HttpClient())
            {
                return client.GetStringAsync(Url).Result;
            }
        }
    }
}