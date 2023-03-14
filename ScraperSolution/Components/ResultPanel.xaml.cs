using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Scraper.Components
{
    /// <summary>
    /// Interaction logic for ResultPanel.xaml
    /// </summary>
    public partial class ResultPanel : UserControl
    {
        public ResultPanel()
        {
            InitializeComponent();
        }
        public void AddItemToListBox(string url)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                TextBlock textBlock = new();
                textBlock.Text = DateTime.Now.ToString("HH:mm:ss ");
                Hyperlink hyperlink = new();
                hyperlink.Inlines.Add(url);
                hyperlink.NavigateUri = new Uri(url);
                textBlock.Inlines.Add(hyperlink);
                ListboxPanel.Items.Add(textBlock);
            });
        }
        public void AddItemToLogBox(string data)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                TextBlock textBlock = new();
                textBlock.Text = DateTime.Now.ToString("HH:mm:ss ") + data;
                ListboxLogPanel.Items.Add(textBlock);
            });
        }
    }
}
