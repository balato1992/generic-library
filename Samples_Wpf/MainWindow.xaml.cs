using GenericWpf.Components.Windows;
using System;
using System.Threading;
using System.Windows;

namespace Samples_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAlarm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Alarm");
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Yes");
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("No");
        }

        private void iwtYes_Click(object sender, RoutedEventArgs e)
        {
            rbYes.IsChecked = true;
        }
        private void iwtNo_Click(object sender, RoutedEventArgs e)
        {
            rbNo.IsChecked = true;
        }

        private void btnControlSleep5s_Click(object sender, RoutedEventArgs e)
        {
            cpb.Start(this, () =>
            {
                Thread.Sleep(5000);
            });
        }
        private void btnWindowSleep5s_Click(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0.6;

            ProgressBarDialog pbd = new ProgressBarDialog(() =>
            {
                Thread.Sleep(5000);
                MessageBox.Show("FINISH");
                throw new Exception("TEST");
            }, (Exception ex) =>
            {
                MessageBox.Show("ERROR");
                Exception exx = ex;
            });

            pbd.Owner = this;
            pbd.Title = "TITLE";
            pbd.SetDisplayWord("WORD");
            pbd.ShowDialog();

            this.Opacity = 1;
        }

    }
}
