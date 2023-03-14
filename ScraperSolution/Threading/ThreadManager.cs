using Scraper.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Scraper.Threading
{
    public static class ThreadManager
    {
        public static void StartScraping(List<Link> links, List<IEnumerable<string>> partitionsData, Components.ResultPanel resultPanel, CancellationToken cts)
        {
            var partitions = partitionsData.Select((data, index) => (data, index));
            foreach(var link in links)
            {
                foreach(var partition in partitions)
                {
                    ThreadPool.QueueUserWorkItem((state) => { 
                        ScraperClass.RunThread(link.Id, partition.index, link.Url, partition.data.ToList(), links, resultPanel, cts); 
                    });
                }
                while (!(link.IsFound || link.Counter == 0)) {
                    if (cts.IsCancellationRequested) return;
                }
            }
        }
    }
}
