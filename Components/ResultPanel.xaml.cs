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
            TextBlock textBlock = new();
            textBlock.Text = DateTime.Now.ToString("HH:mm:ss ");
            Hyperlink hyperlink = new();
            hyperlink.Inlines.Add(url);
            hyperlink.NavigateUri = new Uri(url);
            textBlock.Inlines.Add(hyperlink);
            ListboxPanel.Items.Add(textBlock);
        }
        public void AddItemToLogBox(string data)
        {
            TextBlock textBlock = new();
            textBlock.Text = DateTime.Now.ToString("HH:mm:ss ") + data;
            ListboxLogPanel.Items.Add(textBlock);
        }
    }
}
