using MyModelSample.View.GenericWinFormSample;
using System;
using System.Windows.Forms;

namespace MyModelSample.View._styles
{
    public partial class GenericWinFormItems : UserControl
    {
        public GenericWinFormItems()
        {
            InitializeComponent();
        }

        private void btn_FileOrDirectoryBrowser_Click(object sender, EventArgs e)
        {
            new FileOrDirectoryBrowserSample().Show();
        }

        private void btn_GenericDataGridView_Click(object sender, EventArgs e)
        {
            new GenericDataGridViewSample().Show();
        }

        private void btn_GenericSearchTextBox_Click(object sender, EventArgs e)
        {
            new GenericSearchTextBoxSample().Show();
        }

        private void button_GenericListView_Click(object sender, EventArgs e)
        {
            new GenericListViewSample().Show();
        }

        private void btn_GenericTabControl_Click(object sender, EventArgs e)
        {
            new GenericTabControlSample().Show();
        }

        private void button_loadingBar_Click(object sender, EventArgs e)
        {
            LoadingBar.Test();
        }

        private void btn_GenericNumericList_Click(object sender, EventArgs e)
        {
            new GenericNumericListSample().Show();
        }
    }
}