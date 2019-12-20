using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GenericWpf.Components
{
    /// <summary>
    /// Interaction logic for Line.xaml
    /// </summary>
    public partial class Line : UserControl
    {
        public static readonly DependencyProperty LineWidthProperty =
            DependencyProperty.Register(nameof(LineWidth), typeof(double), typeof(Line), new PropertyMetadata(double.NaN));
        public double LineWidth
        {
            get { return (double)GetValue(LineWidthProperty); }
            set { SetValue(LineWidthProperty, value); }
        }

        public static readonly DependencyProperty LineHeightProperty =
            DependencyProperty.Register(nameof(LineHeight), typeof(double), typeof(Line), new PropertyMetadata(double.NaN));
        public double LineHeight
        {
            get { return (double)GetValue(LineHeightProperty); }
            set { SetValue(LineHeightProperty, value); }
        }

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(nameof(Color), typeof(Brush), typeof(Line), new UIPropertyMetadata(Brushes.Black));
        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public Line()
        {
            double k = this.Width;
            InitializeComponent();
            double k2 = this.Width;
        }
    }
}
