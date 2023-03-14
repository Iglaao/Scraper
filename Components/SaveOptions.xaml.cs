using Microsoft.Win32;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Scraper.Components
{
    /// <summary>
    /// Interaction logic for SaveOptions.xaml
    /// </summary>
    public partial class SaveOptions : UserControl
    {
        private OpenFileDialog _openFileDialog;
        private string _selectedExtension;
        private string _selectedFolder;
        private string _selectedFile;
        private string _fileName;
        public bool _isNewFileSelected;
        public SaveOptions()
        {
            InitializeComponent();
            LoadExtensions();
            LoadFileDialog();
            rbNewFile.IsChecked = true;
            _isNewFileSelected = true;
            _selectedExtension = comboBoxExtension.SelectedItem.ToString();
        }

        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            if (rbNewFile.IsChecked == true)
            {
                comboBoxExtension.IsEnabled = true;
                pathToFolder.IsEnabled = true;
                selectFolder.IsEnabled = true;
                fileName.IsEnabled = true;
                pathToFile.IsEnabled = false;
                selectFile.IsEnabled = false;
                _isNewFileSelected = true;
            }
            else if (rbExistingFile.IsChecked == true)
            {
                comboBoxExtension.IsEnabled = false;
                pathToFolder.IsEnabled = false;
                selectFolder.IsEnabled = false;
                fileName.IsEnabled = false;
                pathToFile.IsEnabled = true;
                selectFile.IsEnabled = true;
                _isNewFileSelected = false;
            }
        }
        private void LoadExtensions()
        {
            comboBoxExtension.Items.Add(".txt");
            comboBoxExtension.Items.Add(".xlsx");

            comboBoxExtension.SelectedItem = comboBoxExtension.Items[0];
        }
        public void LoadFileDialog()
        {
            _openFileDialog = new OpenFileDialog();
            //Loading file filters
            StringBuilder extensions = new();
            for (int i = 0; i < comboBoxExtension.Items.Count; i++)
            {
                extensions.Append("*" + comboBoxExtension.Items[i].ToString());
                if (i + 1 < comboBoxExtension.Items.Count) extensions.Append(';');
            }
            String extensionsFilter = "Files (" + extensions.ToString() + ")|" + extensions.ToString();
            _openFileDialog.Filter = extensionsFilter;
        }
        private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedExtension = comboBoxExtension.SelectedItem.ToString();
        }
        private void SelectFolder_Click(object sender, RoutedEventArgs e)
        {
            using (System.Windows.Forms.FolderBrowserDialog fbd = new())
            {
                var result = fbd.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    pathToFolder.Text = fbd.SelectedPath;
                    _selectedFolder = fbd.SelectedPath;
                }
            }
        }
        private void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            var result = _openFileDialog.ShowDialog();
            if ((bool)result)
            {
                pathToFile.Text = _openFileDialog.FileName;
                _selectedFile = _openFileDialog.FileName;
            }
        }
        private void FolderPathChange(object sender, RoutedEventArgs e)
        {
            _selectedFolder = pathToFolder.Text;
        }
        private void FileNameChange(object sender, RoutedEventArgs e)
        {
            _fileName = fileName.Text;
        }
        private void FilePathChange(object sender, RoutedEventArgs e)
        {
            _selectedFile = pathToFile.Text;
        }
        public string GetSelectedFile()
        {
            return _selectedFile;
        }
        public string GetSelectedFolder()
        {
            return _selectedFolder;
        }
        public string GetSelectedExtension()
        {
            return _selectedExtension;
        }
        public string GetFileName()
        {
            return _fileName;
        }
    }
}
