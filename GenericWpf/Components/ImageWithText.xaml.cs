using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GenericWpf.Components
{
    /// <summary>
    /// Interaction logic for ImageWithText.xaml
    /// </summary>
    public partial class ImageWithText : UserControl
    {
        private static readonly double _DefaultFontSize = 12;
        private static readonly double _DefaultImageHeight = 20;

        #region properties

        #region image
        public static readonly DependencyProperty ImageRowProperty =
            DependencyProperty.Register(nameof(ImageRow), typeof(int), typeof(ImageWithText), new UIPropertyMetadata(0));
        public int ImageRow
        {
            get { return (int)GetValue(ImageRowProperty); }
            set { SetValue(ImageRowProperty, value); }
        }
        public static readonly DependencyProperty ImageColumnProperty =
            DependencyProperty.Register(nameof(ImageColumn), typeof(int), typeof(ImageWithText), new UIPropertyMetadata(0));
        public int ImageColumn
        {
            get { return (int)GetValue(ImageColumnProperty); }
            set { SetValue(ImageColumnProperty, value); }
        }

        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register(nameof(ImageHeight), typeof(double), typeof(ImageWithText), new UIPropertyMetadata(_DefaultImageHeight));
        public double ImageHeight
        {
            get { return (double)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register(nameof(ImageSource), typeof(ImageSource), typeof(ImageWithText), new PropertyMetadata());
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        public static readonly DependencyProperty ImageMarginProperty =
            DependencyProperty.Register(nameof(ImageMargin), typeof(Thickness), typeof(ImageWithText), new PropertyMetadata());
        public Thickness ImageMargin
        {
            get { return (Thickness)GetValue(ImageMarginProperty); }
            set { SetValue(ImageMarginProperty, value); }
        }
        #endregion image
        

        #region Label
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register(nameof(LabelText), typeof(string), typeof(ImageWithText), new PropertyMetadata());
        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }
        public static readonly DependencyProperty LabelFontSizeProperty =
            DependencyProperty.Register(nameof(LabelFontSize), typeof(double), typeof(ImageWithText), new UIPropertyMetadata(_DefaultFontSize));
        public double LabelFontSize
        {
            get { return (double)GetValue(LabelFontSizeProperty); }
            set { SetValue(LabelFontSizeProperty, value); }
        }
        public static readonly DependencyProperty LabelRowProperty =
            DependencyProperty.Register(nameof(LabelRow), typeof(int), typeof(ImageWithText), new UIPropertyMetadata(0));
        public int LabelRow
        {
            get { return (int)GetValue(LabelRowProperty); }
            set { SetValue(LabelRowProperty, value); }
        }
        public static readonly DependencyProperty LabelColumnProperty =
            DependencyProperty.Register(nameof(LabelColumn), typeof(int), typeof(ImageWithText), new UIPropertyMetadata(0));
        public int LabelColumn
        {
            get { return (int)GetValue(LabelColumnProperty); }
            set { SetValue(LabelColumnProperty, value); }
        }
        #endregion Label

        public static readonly RoutedEvent ClickEvent = 
            EventManager.RegisterRoutedEvent(nameof(Click), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ImageWithText));
        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }
        #endregion properties

        public ImageWithText()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ImageWithText.ClickEvent));
        }
    }
}
