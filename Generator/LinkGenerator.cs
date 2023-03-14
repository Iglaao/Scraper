using Scraper.Data;
using System;
using System.Collections.Generic;

namespace Scraper.Generator
{
    public static class LinkGenerator
    {
        public static List<Link> GetLinks(string url, int amount)
        {
            var links = new List<Link>();
            string[] decomposedLink = url.Split('_');
            int linkId = Convert.ToInt32(decomposedLink[decomposedLink.Length - 1]);
            var baseUrl = url.Remove(url.Length - decomposedLink[decomposedLink.Length - 1].Length);

            for (int i = 0; i < amount; ++i)
            {
                links.Add(new Link()
                {
                    Id = i + 1,
                    Url = baseUrl.Replace("#", ((linkId + i) % 10).ToString()) + (linkId + i).ToString()
                });
            }

            return links;
        }
    }
}
