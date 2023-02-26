using Scraper.Events;
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

namespace Scraper.Components
{
    /// <summary>
    /// Interaction logic for MenuPanel.xaml
    /// </summary>
    public partial class MenuPanel : UserControl
    {
        public event EventHandler<FireScraperEvent> _controlParentMethod;
        public MenuPanel()
        {
            InitializeComponent();
        }

        private void Run(object sender, RoutedEventArgs e)
        {
            if (_controlParentMethod.GetInvocationList().Length == 0)
            {
                return;
            }
            else
            {
                _controlParentMethod(sender, new FireScraperEvent(FireScraperEvent.Options.Run));
            }
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            if (_controlParentMethod.GetInvocationList().Length == 0)
            {
                return;
            }
            else
            {
                _controlParentMethod(sender, new FireScraperEvent(FireScraperEvent.Options.Cancel));
            }
        }
        private void StopAndSave(object sender, RoutedEventArgs e)
        {
            if (_controlParentMethod.GetInvocationList().Length == 0)
            {
                return;
            }
            else
            {
                _controlParentMethod(sender, new FireScraperEvent(FireScraperEvent.Options.StopAndSave));
            }
        }
        private void SaveResults(object sender, RoutedEventArgs e)
        {
            if (_controlParentMethod.GetInvocationList().Length == 0)
            {
                return;
            }
            else
            {
                _controlParentMethod(sender, new FireScraperEvent(FireScraperEvent.Options.SaveResults));
            }
        }
    }
}
