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
    /// Interaction logic for ThreadingOptions.xaml
    /// </summary>
    public partial class ThreadingOptions : UserControl
    {
        private System.Windows.Forms.NumericUpDown _nudThreads;
        private int _numberOfThreads;
        public ThreadingOptions()
        {
            InitializeComponent();
            InitializeThreadsNumericUpDown();
            //TODO REMOVE
            _nudThreads.Value = 4;
        }
        private void InitializeThreadsNumericUpDown()
        {
            System.Windows.Forms.Integration.WindowsFormsHost hostThreads = new();
            _nudThreads = new();
            _nudThreads.Minimum = 1;
            _nudThreads.Maximum = 32;
            _numberOfThreads = 1;
            _nudThreads.ValueChanged += NudThreads_ValueChanged;
            hostThreads.Child = _nudThreads;
            this.ThreadPanel.Children.Add(hostThreads);
        }
        private void NudThreads_ValueChanged(object? sender, EventArgs e)
        {
            _numberOfThreads = (int)_nudThreads.Value;
        }
        public int GetNumberOfThreads()
        {
            return _numberOfThreads;
        }
    }
}
