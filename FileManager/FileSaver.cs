using Scraper.Data;
using System.Collections.Generic;

namespace Scraper.FileManager
{
    public abstract class FileSaver
    {
        public abstract void SaveFile(string fullPath, List<Link> links);
        public abstract void SaveNewFile(string path, string fileName, List<Link> links);
    }
}
