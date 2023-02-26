using Scraper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scraper.Threading
{
    public static class ScraperClass
    {
        private static Task<string> GetHtml(HttpClient client, string fullUrl)
        {
            var response = client.GetStringAsync(fullUrl);
            return response;
        }
        public static async void RunThread(int i, int j, string fullUrl, List<String> list, List<Link> data, Components.ResultPanel resultPanel)
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

            }
            if(code == "")
            {
                resultPanel.AddItemToLogBox("Thread [" + i + "." + j + "] hasn't found anything.");
            }
            else
            {
                resultPanel.AddItemToListBox(fullUrl + code + ".webp");
                data[i - 1].Url = fullUrl + code + ".webp";
                data[i - 1].IsFound = true;
            }
        }
    }
}
