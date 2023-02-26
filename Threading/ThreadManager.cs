using Scraper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scraper.Threading
{
    public static class ThreadManager
    {
        public static void StartScraping(List<Link> links, List<IEnumerable<string>> partitionsData, Components.ResultPanel resultPanel)
        {
            var partitions = partitionsData.Select((data, index) => (data, index));
            foreach(var link in links)
            {
                foreach(var partition in partitions)
                {
                    ThreadPool.QueueUserWorkItem((state) => { 
                        ScraperClass.RunThread(link.Id, partition.index, link.Url, partition.data.ToList(), links, resultPanel); 
                    });
                }
                while (!link.IsFound) { }
            }
        }
    }
}
