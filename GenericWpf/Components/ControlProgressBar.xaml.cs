using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace GenericWpf.Components
{
    /// <summary>
    /// Interaction logic for ProgressBar.xaml
    /// </summary>
    public partial class ControlProgressBar : UserControl
    {
        private List<Thread> _Threads { get; set; }

        public ControlProgressBar()
        {
            InitializeComponent();
            Visibility = Visibility.Hidden;

            _Threads = new List<Thread>();
        }
        public bool CheckAllFinished()
        {
            foreach (Thread t in _Threads)
            {
                if (t != null && t.IsAlive == true)
                {
                    return false;
                }
            }
            return true;
        }
        public void Start(Control c, Action action)
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    Dispatcher.Invoke(() =>
                    {
                        c.IsEnabled = false;
                        Visibility = Visibility.Visible;
                    });
                    action();
                }
                finally
                {
                    Dispatcher.Invoke(() =>
                    {
                        c.IsEnabled = true;
                        Visibility = Visibility.Hidden;
                    });
                }
            });
            thread.IsBackground = true;
            _Threads.Add(thread);
            thread.Start();
        }
    }
}
