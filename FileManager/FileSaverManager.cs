using Scraper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.FileManager
{
    public class FileSaverManager
    {
        private FileSaver _fileSaver;
        private FileSaverManager() { }
        private static FileSaverManager _instance;
        public static FileSaverManager GetInstance()
        {
            if (_instance == null) { _instance = new FileSaverManager(); }
            return _instance;
        }
        public void SetFileSaver(string extension)
        {
            if (extension == ".txt") _fileSaver = FileTxtSaver.GetInstance();
            else if (extension == ".xlsx") _fileSaver = FileXlsxSaver.GetInstance();
            else throw new ArgumentException();
        }
        public void SaveFile(string fullPath, List<Link> links)
        {
            _fileSaver.SaveFile(fullPath, links);
        }
        public void SaveNewFile(string path, string fileName, List<Link> links)
        {
            _fileSaver.SaveNewFile(path, fileName, links);
        }
    }
}
