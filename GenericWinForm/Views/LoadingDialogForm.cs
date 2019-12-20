using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GenericWinForm.Views
{
    public partial class LoadingDialogForm : Form
    {
        public delegate void SomeAction();

        public Exception ExceptionDuringLoading = null;
        SomeAction m_action=null;

        public LoadingDialogForm(string displayWord, SomeAction action)
        {
            InitializeComponent();

            // Remove the control box so the form will only display client area.
            this.ControlBox = false;

            // set member data
            this.label_displayWord.Text = displayWord;
            this.m_action = action;

            // do something when showing or showing dialog
            this.Shown += mShownEvent;
        }

        public LoadingDialogForm(string title, string displayWord, SomeAction action): this(displayWord, action)
        {
            // set member data
            this.Text = title;
        }


        // sometime the form will not show on top of all windows, use this reduce some situation
        private void FocusTop()
        {
            Application.OpenForms[this.Name].Focus();
            this.BringToFront();
            this.Focus();
            this.TopMost = true;
            System.Threading.Thread.Sleep(100);
            this.TopMost = false;
            Application.OpenForms[this.Name].Focus();
        }

        private void mShownEvent(object sender, EventArgs e)
        {
            FocusTop();

            BackgroundWorker backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += backgroundWorker_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.RunWorkerAsync();

            FocusTop();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(500);
                this.m_action();
            }
            catch (Exception ex)
            {
                this.ExceptionDuringLoading = ex;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

    }
}
