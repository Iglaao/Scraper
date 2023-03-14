using Scraper.Data;
using Scraper.Events;
using Scraper.FileManager;
using Scraper.Generator;
using Scraper.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Scraper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _url;
        private string _pattern;
        private int _numberOfThreads;
        private int _numberOfLinksToFind;
        private CancellationTokenSource _token;
        private List<Link> _links;
        private FileSaverManager _fileSaverManager;
        public MainWindow()
        {
            InitializeComponent();
            InitializeFireScrapperEvent();
            _fileSaverManager = FileSaverManager.GetInstance();
        }
        private void InitializeFireScrapperEvent()
        {
            MenuPanel._controlParentMethod += new EventHandler<FireScraperEvent>(RegisterControlParentMethod);
        }
        private void RegisterControlParentMethod(object sender, FireScraperEvent e)
        {
            try
            {
                switch (e.Option)
                {
                    case FireScraperEvent.Options.Run:
                        Start();
                        break;
                    case FireScraperEvent.Options.Cancel:
                        Cancel();
                        break;
                    case FireScraperEvent.Options.StopAndSave:
                        StopAndSave();
                        break;
                    case FireScraperEvent.Options.SaveResults:
                        SaveResults();
                        break;
                    default: throw new ArgumentOutOfRangeException(nameof(e.Option));
                }
            }catch(ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public void Start()
        {
            SetAttributes();
            _token = new CancellationTokenSource();
            _links = LinkGenerator.GetLinks(_url, _numberOfLinksToFind);
            var partitions = CodeGenerator.Split(CodeGenerator.GetCodes(_pattern), _numberOfThreads).ToList();
            foreach(var link in _links) 
            { 
                link.Counter = _numberOfThreads; 
            }
            var run = Task.Run(() => ThreadManager.StartScraping(_links, partitions, ResultPanel, _token.Token));
        }
        public void Cancel()
        {
            _token.Cancel();
            _token.Dispose();
        }
        public void StopAndSave()
        {
            _token.Cancel();
            _token.Dispose();
            SaveResults();
        }
        public void SaveResults()
        {
            if (SaveOptions._isNewFileSelected) _fileSaverManager.SaveNewFile(SaveOptions.GetSelectedFolder(), SaveOptions.GetFileName(), _links);
            else _fileSaverManager.SaveFile(SaveOptions.GetSelectedFile(), _links);
        }
        private void SetAttributes()
        {
            try
            {
                _fileSaverManager.SetFileSaver(SaveOptions.GetSelectedExtension());
                _url = UrlOptions.GetUrlAddress();
                _pattern = UrlOptions.GetPattern();
                _numberOfLinksToFind = UrlOptions.GetNumberOfLinksToFind();
                _numberOfThreads = ThreadingOptions.GetNumberOfThreads();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
