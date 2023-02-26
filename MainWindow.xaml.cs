using Scraper.Events;
using Scraper.FileManager;
using Scraper.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            var partitions = CodeGenerator.Split(CodeGenerator.GetCodes(_pattern), _numberOfThreads).ToList();
            var links = LinkGenerator.GetLinks(_url, _numberOfLinksToFind);
        }
        public void Cancel()
        {
            
        }
        public void StopAndSave()
        {

        }
        public void SaveResults()
        {

        }
        private void SetAttributes()
        {
            _fileSaverManager.SetFileSaver(SaveOptions.GetSelectedExtension());
            _url = UrlOptions.GetUrlAddress();
            _pattern = UrlOptions.GetPattern();
            _numberOfLinksToFind = UrlOptions.GetNumberOfLinksToFind();
            _numberOfThreads = ThreadingOptions.GetNumberOfThreads();
        }
    }
}
