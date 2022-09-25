using System.Diagnostics;

namespace AngryFileManager
{
    public partial class MainForm : Form
    {
        private string? _selectedItemFilePath;
        private string? _selectedFileName;

        public MainForm()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            detailsView.ListViewItemSorter = lvwColumnSorter;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeTreeView();
        }

        private void InitializeTreeView()
        {
            var drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                var node = new TreeNode(drive.Name)
                {
                    SelectedImageIndex = 2
                };

                catalogsView.Nodes.Add(node);
            }

            var path = drives
                .Select(x => x.Name)
                .FirstOrDefault();

            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }

            navigationTextBox.Text = path;
            _selectedItemFilePath = path;
            LoadFolder();
        }

        private void LoadFolder()
        {
            try
            {
                var selectedDirectoryInfo = new DirectoryInfo(_selectedItemFilePath);
                var selectedDirectoryFiles = selectedDirectoryInfo.GetFiles();
                var selectedDirectoryDirectories = selectedDirectoryInfo.GetDirectories();

                detailsView.Items.Clear();

                foreach (var selectedDirectoryDirectory in selectedDirectoryDirectories)
                {
                    var item = new ListViewItem(selectedDirectoryDirectory.Name);

                    item.SubItems.Add("");
                    item.SubItems.Add("Папка");
                    item.SubItems.Add(Directory.GetLastWriteTime(selectedDirectoryDirectory.FullName).ToString("g"));
                    item.ImageIndex = 0;

                    detailsView.Items.Add(item);
                }

                foreach (var selectedDirectoryFile in selectedDirectoryFiles)
                {
                    var fileInfo = new FileInfo(selectedDirectoryFile.FullName);
                    var item = new ListViewItem(selectedDirectoryFile.Name);

                    var fileSize = Convert.ToDecimal(fileInfo.Length);
                    var size = GetFileSize(fileSize, 0);

                    item.SubItems.Add(size);
                    item.SubItems.Add(fileInfo.Extension.ToLowerInvariant());
                    item.SubItems.Add(fileInfo.LastWriteTime.ToString("g"));
                    var imageIndex = GetImageIndex(fileInfo.Extension.ToLowerInvariant());
                    item.ImageIndex = imageIndex;

                    detailsView.Items.Add(item);
                }
            }
            catch (Exception exception)
            {
                if (exception is AccessViolationException or UnauthorizedAccessException)
                {
                    ExceptionHandler.ShowUserException("Нет доступа", GoUp, LoadButtonAction);
                }
            }
        }

        private int GetImageIndex(string fileExtension)
        {
            switch (fileExtension)
            {
                default:
                {
                    return 1;
                }

                case ".jpg":
                case ".heic":
                case ".gif":
                case ".jfif":
                case ".webp":
                case ".png":
                case ".ico":
                {
                    return 3;
                }

                case ".mp4":
                case ".avi":
                case ".mpeg4":
                case ".mkv":
                {
                    return 4;
                }

                case ".torrent":
                {
                    return 5;
                }

                case ".pdf":
                {
                    return 6;
                }

                case ".zip":
                case ".rar":
                case ".7z":
                {
                    return 7;
                }

                case ".mp3":
                case ".wav":
                case ".mp2":
                {
                    return 8;
                }
            }
        }

        private string GetFileSize(decimal fileSize, int iterator)
        {
            while (true)
            {
                if (fileSize < 1024)
                {
                    var postfix = string.Empty;

                    switch (iterator)
                    {
                        case 0:
                            postfix = "B";
                            break;

                        case 1:
                            postfix = "KB";
                            break;

                        case 2:
                            postfix = "MB";
                            break;

                        case 3:
                            postfix = "GB";
                            break;

                        case 4:
                            postfix = "TB";
                            break;
                    }

                    return $"{fileSize:F2} {postfix}";
                }

                fileSize /= 1024;
                iterator++;
            }
        }

        private void LoadFile()
        {
            var tempFilePath = Path.Combine(_selectedItemFilePath, _selectedFileName);
            var process = new Process();
            process.StartInfo = new ProcessStartInfo(tempFilePath)
            {
                UseShellExecute = true
            };
            process.Start();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
            {
                return;
            }

            _selectedItemFilePath = e.Node.Text;

            var selectedDirectoryInfo = new DirectoryInfo(_selectedItemFilePath);
            var selectedDirectoryDirectories = selectedDirectoryInfo.GetDirectories();

            foreach (var selectedDirectoryDirectory in selectedDirectoryDirectories)
            {
                catalogsView.Nodes.Add(selectedDirectoryDirectory.Name);
            }

            LoadFolder();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            try
            {
                var isDirectory = IsDirectory(navigationTextBox.Text);
                LoadButtonAction(isDirectory);
            }
            catch (Exception exception)
            {
                ExceptionHandler.ShowUserException(exception.Message, GoUp, LoadButtonAction);
            }
        }

        private void LoadButtonAction(bool isDirectory)
        {
            _selectedItemFilePath = navigationTextBox.Text;

            if (isDirectory)
            {
                LoadFolder();
            }
            else
            {
                LoadFile();
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            _selectedFileName = e.Item.Text;

            var selectedFileFullPath = Path.Combine(_selectedItemFilePath!, _selectedFileName);
            var selectedFileAttributes = File.GetAttributes(selectedFileFullPath);

            if (selectedFileAttributes is FileAttributes.Directory or FileAttributes.ReadOnly)
            {
                navigationTextBox.Text = selectedFileFullPath;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                _selectedFileName = detailsView.SelectedItems[0].SubItems[0].Text;

                var selectedFileFullPath = Path.Combine(_selectedItemFilePath!, _selectedFileName);
                var isDirectory = IsDirectory(selectedFileFullPath);

                if (isDirectory)
                {
                    navigationTextBox.Text = selectedFileFullPath;
                }

                LoadButtonAction(isDirectory);
            }
            catch (Exception exception)
            {
                ExceptionHandler.ShowUserException(exception.Message, GoUp, LoadButtonAction);
            }
        }

        private void GoUp()
        {
            try
            {
                var parentDirectory = Directory.GetParent(navigationTextBox.Text);

                if (parentDirectory == null)
                {
                    return;
                }

                navigationTextBox.Text = parentDirectory.FullName;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void backButton_Click(object sender, EventArgs e)
        {
            GoUp();
            LoadButtonAction(true);
        }

        private void filePathTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != (char)Keys.Return)
            {
                return;
            }

            var isDirectory = IsDirectory(navigationTextBox.Text);
            LoadButtonAction(isDirectory);
        }

        private bool IsDirectory(string path)
        {
            var selectedFileAttributes = File.GetAttributes(path);
            return (selectedFileAttributes & FileAttributes.Directory) == FileAttributes.Directory;
        }

        // msdn
        private void detailsView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                lvwColumnSorter.Order = lvwColumnSorter.Order == SortOrder.Ascending 
                    ? SortOrder.Descending 
                    : SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            detailsView.Sort();
        }
    }
}