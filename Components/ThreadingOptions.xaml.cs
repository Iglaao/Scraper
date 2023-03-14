using System;
using System.Windows.Controls;

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
