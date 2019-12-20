using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace GenericWpf.Components.Windows
{
    public partial class ProgressBarDialog : Window
    {
        private Action _ActionRun { get; set; }
        private Action<Exception> _ActionException { get; set; }
        private Action _ActionClosed { get; set; }

        public ProgressBarDialog(Action actionRun, Action<Exception> actionException)
        {
            InitializeComponent();

            _ActionRun = actionRun;
            _ActionException = actionException;
        }

        public void SetDisplayWord(string displayWord)
        {
            progressBar.SetMessage(displayWord);
        }

        // sometime the form will not show on top of all windows, use this reduce some situation
        private void _FocusTop()
        {
            Focus();
            Topmost = true;
            System.Threading.Thread.Sleep(100);
            Topmost = false;
        }
        private static void _RunBackgroundWorker(Action action, Action<Exception> actionException, Action completed)
        {
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += (object sender1, DoWorkEventArgs e1) =>
            {
                try
                {
                    System.Threading.Thread.Sleep(500);
                    action?.Invoke();
                }
                catch (Exception ex)
                {
                    actionException?.Invoke(ex);
                }
            };
            bgw.RunWorkerCompleted += (object sender2, RunWorkerCompletedEventArgs e2) =>
            {
                completed?.Invoke();
            };
            bgw.RunWorkerAsync();
        }

        #region events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _FocusTop();

            _RunBackgroundWorker(_ActionRun, _ActionException, () => { Close(); });

            _FocusTop();
        }
        
        #endregion events

    }
}
