using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace GenericWpf.Components.Bases
{
    /// <summary>
    /// Interaction logic for ProgressBar.xaml
    /// </summary>
    public partial class BaseProgressBar : UserControl
    {
        #region DependencyProperty

        public static readonly DependencyProperty ProgressBarWidthProperty =
            DependencyProperty.Register(nameof(ProgressBarWidth), typeof(double), typeof(BaseProgressBar), new PropertyMetadata());
        public double ProgressBarWidth => (double)GetValue(ProgressBarWidthProperty);


        public static readonly DependencyProperty ProgressBarHeightProperty =
            DependencyProperty.Register(nameof(ProgressBarHeight), typeof(double), typeof(BaseProgressBar), new PropertyMetadata());
        public double ProgressBarHeight => (double)GetValue(ProgressBarHeightProperty);

        #endregion DependencyProperty

        public double Proportion { get; set; } = 2.5;
        public double SizeCoefficient { get; set; } = 4.2;

        public BaseProgressBar()
        {
            Visibility = Visibility;
            InitializeComponent();
        }

        public void SetMessage(string message, double fontSize = 18)
        {
            textMessage.Text = message;
            textMessage.FontSize = fontSize;
        }

        private void ucMain_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double unit = Math.Min(ActualWidth / Proportion / SizeCoefficient, ActualHeight / Proportion);
            //unit = Math.Max(unit, 50);

            SetValue(ProgressBarWidthProperty, unit * SizeCoefficient);
            SetValue(ProgressBarHeightProperty, unit);
        }
    }
}
