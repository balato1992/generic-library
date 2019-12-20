using System;
using System.Windows.Forms;

namespace MyModelSample.View.GenericWinFormSample
{
    public partial class FileOrDirectoryBrowserSample : Form
    {
        public FileOrDirectoryBrowserSample()
        {
            InitializeComponent();

            if (pFileOrDirectoryBrowser.BrowserType == GenericWinForm.Views.BrowserType.Directory)
            {
                rb_Directory.Checked = true;
            }
            else //if (pFileOrDirectoryBrowser.BrowserType == GenericWinForm.Views.BrowserType.File)
            {
                rb_File.Checked = true;
            }
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Directory.Checked)
            {
                pFileOrDirectoryBrowser.BrowserType = GenericWinForm.Views.BrowserType.Directory;
            }
            else //if (rb_File.Checked)
            {
                pFileOrDirectoryBrowser.BrowserType = GenericWinForm.Views.BrowserType.File;
            }
        }

        private void btn_SetPath_Click(object sender, EventArgs e)
        {
            pFileOrDirectoryBrowser.SetPath(tb_Path.Text);
        }

        private void btn_GetPath_Click(object sender, EventArgs e)
        {
            tb_Path.Text = pFileOrDirectoryBrowser.GetPath();
        }

        private void pFileOrDirectoryBrowser_BrowseOK_1(object sender, GenericWinForm.Views.BrowseOKEventHandlerEventArgs e)
        {
            rtb_Event.Text += "BrowseOK event\r\n";
        }
    }
}