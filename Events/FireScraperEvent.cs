using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Events
{
    public class FireScraperEvent : EventArgs
    {
        public enum Options
        {
            Run,
            Cancel,
            StopAndSave,
            SaveResults
        }
        private Options _option;
        public Options Option { get { return _option; } }
        public FireScraperEvent(Options option) : base()
        {
            _option = option;
        }
    }
}
