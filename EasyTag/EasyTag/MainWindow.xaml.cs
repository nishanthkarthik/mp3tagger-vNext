using System.IO;
using System.Windows;
using EasyTag.MVVM;
using Microsoft.Win32;

namespace EasyTag
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private string _mp3FilePath;
        private bool _fileSelected;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FileButton_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "MP3 Files|*.mp3",
                DefaultExt = ".mp3"
            };
            switch (openFile.ShowDialog())
            {
                case true:
                    _mp3FilePath = openFile.FileName;
                    _fileSelected = true;
                    FileBlock.Text = Path.GetFileNameWithoutExtension(_mp3FilePath);
                    break;
            }
        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            if (!_fileSelected)
            {
                MessageBox.Show("Select a file first");
                return;
            }
            if (string.IsNullOrWhiteSpace(NameBox.Text))
            {
                MessageBox.Show("The song name cannot be empty");
                return;
            }
            TrackItemViewModel trackModel = await TrackItemViewModel.LoadTrackViewModel(NameBox.Text);
        }
    }
}
