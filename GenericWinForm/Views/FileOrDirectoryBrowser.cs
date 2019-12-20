using System;
using System.IO;
using System.Windows.Forms;

namespace GenericWinForm.Views
{
    public partial class FileOrDirectoryBrowser : UserControl
    {
        public BrowserType BrowserType { get; set; }
        public bool EnableKeyIn { set { tb_path_text.ReadOnly = !value; } }
        public event EventHandler<BrowseOKEventHandlerEventArgs> BrowseOK;

        public FileOrDirectoryBrowser()
        {
            InitializeComponent();

            BrowserType = BrowserType.Directory;

            tb_path_text.Text = AppDomain.CurrentDomain.BaseDirectory;
        }

        public void SetPath(string path)
        {
            // todo: check if path is vaild
            tb_path_text.Text = path;
        }

        public string GetPath()
        {
            return tb_path_text.Text;
        }

        private void btn_folderPath_open_Click(object sender, EventArgs e)
        {
            string fullPath = tb_path_text.Text;
            string folderPath = Path.GetDirectoryName(fullPath);

            if (System.IO.Directory.Exists(folderPath))
            {
                System.Diagnostics.Process.Start(folderPath);
            }
            else
            {
                MessageBox.Show("Directory not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_folderPath_browse_Click(object sender, EventArgs e)
        {
            string fullPath = tb_path_text.Text;
            string folderPath = Path.GetDirectoryName(fullPath);

            if (!System.IO.Directory.Exists(folderPath))
            {
                folderPath = AppDomain.CurrentDomain.BaseDirectory;
            }

            bool isSuccess = false;
            string pathBySuccess = string.Empty;
            if (BrowserType == BrowserType.File)
            {
                openFileDialog_filePath.InitialDirectory = folderPath;

                if (openFileDialog_filePath.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(openFileDialog_filePath.FileName))
                {
                    pathBySuccess = openFileDialog_filePath.FileName;
                    isSuccess = true;
                }
            }
            else if ((BrowserType == BrowserType.Directory))
            {
                fbd_folderPath.SelectedPath = folderPath;

                if (fbd_folderPath.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(fbd_folderPath.SelectedPath))
                {
                    pathBySuccess = fbd_folderPath.SelectedPath + @"\";
                    isSuccess = true;
                }
            }


            if (isSuccess)
            {
                tb_path_text.Text = pathBySuccess;
                BrowseOKEventHandlerEventArgs args = new BrowseOKEventHandlerEventArgs() { Path = pathBySuccess };

                if (this.BrowseOK != null)
                {
                    this.BrowseOK(this, args);
                }
            }

        }
    }


    public enum BrowserType
    {
        File, Directory
    }

    public class BrowseOKEventHandlerEventArgs : EventArgs
    {
        public string Path { get; set; }
    }

}
