using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Events
{
    public class FireScraperEvent : EventArgs
    {
        //True = run
        //False = cancel
        private bool _run;
        public bool Run { get { return _run; } }
        public FireScraperEvent(bool run) : base()
        {
            _run = run;
        }
    }
}
