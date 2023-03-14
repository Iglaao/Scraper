using Scraper.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Scraper.Threading
{
    public static class ScraperClass
    {
        private static readonly object linkLock = new object();
        private static Task<string> GetHtml(HttpClient client, string fullUrl)
        {
            var response = client.GetStringAsync(fullUrl);
            return response;
        }
        public static async void RunThread(int i, int j, string fullUrl, List<String> list, List<Link> data, Components.ResultPanel resultPanel, CancellationToken cts)
        {
            var client = new HttpClient();
            string code = "";
            resultPanel.AddItemToLogBox("Thread [" + i + "." + j + "] created.");
            foreach (var x in list)
            {
                try
                {
                    var html = await GetHtml(client, fullUrl + x + ".webp");
                    code = x;
                    break;
                }
                catch (HttpRequestException ex) { }
                if (cts.IsCancellationRequested)
                {
                    resultPanel.AddItemToLogBox("Thread [" + i + "." + j + "] cancelling work.");
                    return;
                }
            }
            if (code == "")
            {
                resultPanel.AddItemToLogBox("Thread [" + i + "." + j + "] hasn't found anything.");
                lock (linkLock)
                {
                    if (data[i - 1].Counter > 0) data[i - 1].Counter -= 1;
                    else return;
                }
            }
            else
            {
                resultPanel.AddItemToListBox(fullUrl + code + ".webp");
                lock (linkLock)
                {
                    data[i - 1].Url = fullUrl + code + ".webp";
                    data[i - 1].Counter = 0;
                    data[i - 1].IsFound = true;
                }
            }
        }
    }
}
