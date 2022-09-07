namespace AngryFileManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeTreeView()
        {
            var drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                treeView1.Nodes.Add(drive.Name);
            }
        }
    }
}