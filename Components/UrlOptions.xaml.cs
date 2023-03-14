using System;
using System.Windows;
using System.Windows.Controls;

namespace Scraper.Components
{
    /// <summary>
    /// Interaction logic for UrlControl.xaml
    /// </summary>
    public partial class UrlOptions : UserControl
    {
        private System.Windows.Forms.NumericUpDown _nudUrlsToFind;
        private int _urlsToFind;
        private string _urlAddress;
        private string _pattern;
        public UrlOptions()
        {
            InitializeComponent();
            InitializeNumericUpDown();
        }
        private void InitializeNumericUpDown()
        {
            System.Windows.Forms.Integration.WindowsFormsHost hostURLs = new();
            _nudUrlsToFind = new();
            _nudUrlsToFind.Minimum = 1;
            _nudUrlsToFind.Maximum = 100;
            _nudUrlsToFind.ValueChanged += _nudUrlsToFind_ValueChanged;
            hostURLs.Child = _nudUrlsToFind;
            this.UrlPanel.Children.Add(hostURLs);
        }
        private void _nudUrlsToFind_ValueChanged(object? sender, EventArgs e)
        {
            _urlsToFind = (int)_nudUrlsToFind.Value;
        }
        private void UrlAddress_SelectionChanged(object sender, RoutedEventArgs e)
        {
            _urlAddress = UrlAddress.Text;
        }
        private void Pattern_SelectionChanged(object sender, RoutedEventArgs e)
        {
            _pattern = Pattern.Text;
        }
        public string GetUrlAddress()
        {
            return _urlAddress;
        }
        public string GetPattern()
        {
            return _pattern;
        }
        public int GetNumberOfLinksToFind()
        {
            return _urlsToFind;
        }
    }
}
