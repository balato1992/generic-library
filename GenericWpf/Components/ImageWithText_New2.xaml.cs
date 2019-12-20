using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GenericWpf.Components
{
    /// <summary>
    /// Interaction logic for ImageWithText_New2.xaml
    /// </summary>
    public partial class ImageWithText_New2 : UserControl
    {
        private static readonly double _DefaultFontSize = 12;
        private static readonly double _DefaultImageHeight = 20;

        #region properties

        #region image
        public static readonly DependencyProperty ImageRowProperty =
            DependencyProperty.Register(nameof(ImageRow), typeof(int), typeof(ImageWithText_New2), new UIPropertyMetadata(0));
        public int ImageRow
        {
            get { return (int)GetValue(ImageRowProperty); }
            set { SetValue(ImageRowProperty, value); }
        }
        public static readonly DependencyProperty ImageColumnProperty =
            DependencyProperty.Register(nameof(ImageColumn), typeof(int), typeof(ImageWithText_New2), new UIPropertyMetadata(0));
        public int ImageColumn
        {
            get { return (int)GetValue(ImageColumnProperty); }
            set { SetValue(ImageColumnProperty, value); }
        }

        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register(nameof(ImageHeight), typeof(double), typeof(ImageWithText_New2), new UIPropertyMetadata(_DefaultImageHeight));
        public double ImageHeight
        {
            get { return (double)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register(nameof(ImageSource), typeof(ImageSource), typeof(ImageWithText_New2), new PropertyMetadata());
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        public static readonly DependencyProperty ImageMarginProperty =
            DependencyProperty.Register(nameof(ImageMargin), typeof(Thickness), typeof(ImageWithText_New2), new PropertyMetadata());
        public Thickness ImageMargin
        {
            get { return (Thickness)GetValue(ImageMarginProperty); }
            set { SetValue(ImageMarginProperty, value); }
        }
        #endregion image

        #region Label
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register(nameof(LabelText), typeof(string), typeof(ImageWithText_New2), new PropertyMetadata());
        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }
        public static readonly DependencyProperty LabelFontSizeProperty =
            DependencyProperty.Register(nameof(LabelFontSize), typeof(double), typeof(ImageWithText_New2), new UIPropertyMetadata(_DefaultFontSize));
        public double LabelFontSize
        {
            get { return (double)GetValue(LabelFontSizeProperty); }
            set { SetValue(LabelFontSizeProperty, value); }
        }
        public static readonly DependencyProperty LabelRowProperty =
            DependencyProperty.Register(nameof(LabelRow), typeof(int), typeof(ImageWithText_New2), new UIPropertyMetadata(0));
        public int LabelRow
        {
            get { return (int)GetValue(LabelRowProperty); }
            set { SetValue(LabelRowProperty, value); }
        }
        public static readonly DependencyProperty LabelColumnProperty =
            DependencyProperty.Register(nameof(LabelColumn), typeof(int), typeof(ImageWithText_New2), new UIPropertyMetadata(0));
        public int LabelColumn
        {
            get { return (int)GetValue(LabelColumnProperty); }
            set { SetValue(LabelColumnProperty, value); }
        }
        #endregion Label

        public static readonly DependencyProperty BackgroundHoverProperty =
            DependencyProperty.Register(nameof(BackgroundHover), typeof(Brush), typeof(ImageWithText_New2), new UIPropertyMetadata(Brushes.Transparent));
        public Brush BackgroundHover
        {
            get { return (Brush)GetValue(BackgroundHoverProperty); }
            set { SetValue(BackgroundHoverProperty, value); }
        }


        public static readonly DependencyProperty PaddingOfInnerProperty =
            DependencyProperty.Register(nameof(PaddingOfInner), typeof(Thickness), typeof(ImageWithText_New2), new UIPropertyMetadata(new Thickness(8, 4, 8, 4)));
        public Thickness PaddingOfInner
        {
            get { return (Thickness)GetValue(PaddingOfInnerProperty); }
            set { SetValue(PaddingOfInnerProperty, value); }
        }

        public static readonly RoutedEvent ClickEvent =
            EventManager.RegisterRoutedEvent(nameof(Click), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ImageWithText_New2));
        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }
        #endregion properties

        public ImageWithText_New2()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ClickEvent));
        }
    }
}
