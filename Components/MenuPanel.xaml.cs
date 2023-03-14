using Scraper.Events;
using System;
using System.Windows;
using System.Windows.Controls;

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
