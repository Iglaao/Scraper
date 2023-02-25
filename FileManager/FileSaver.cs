using Scraper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.FileManager
{
    public abstract class FileSaver
    {
        public abstract void SaveFile(string fullPath, List<Link> links);
        public abstract void SaveNewFile(string path, string fileName, List<Link> links);
    }
}
