using Scraper.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.FileManager
{
    public class FileTxtSaver : FileSaver
    {
        private FileTxtSaver() { }
        private static FileTxtSaver _instance;
        public static FileTxtSaver GetInstance()
        {
            if(_instance == null ) { _instance = new FileTxtSaver(); }
            return _instance;
        }
        public override void SaveFile(string fullPath, List<Link> links)
        {
            using (StreamWriter sw = File.AppendText(fullPath))
            {
                foreach (Link link in links)
                {
                    sw.WriteLine(link.Url);
                }
            }
        }
        public override void SaveNewFile(string path, string fileName, List<Link> links)
        {
            using (StreamWriter sw = File.CreateText(path + @"\" + fileName + ".txt"))
            {
                foreach (Link link in links)
                {
                    sw.WriteLine(link.Url);
                }
            }
        }
    }
}
