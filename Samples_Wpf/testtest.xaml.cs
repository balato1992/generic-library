using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Samples_Wpf
{
    /// <summary>
    /// Interaction logic for testtest.xaml
    /// </summary>
    public partial class testtest : UserControl
    {
        public CollectionViewSource DisplayData { get; set; }
        private List<tttMultiplePageItem> _Data { get; set; }
        public testtest()
        {
            InitializeComponent();

            DataGridTextColumn dgtc = new DataGridTextColumn();
            dgtc.Header = "TTTTT";
            dgtc.Binding = new Binding("Id");
            dgtc.HeaderTemplate = _CreateTemplate();

            dataGrid22.Columns.Add(dgtc);

            _Data = new List<tttMultiplePageItem>() {
                new tttMultiplePageItem("id1"),
                new tttMultiplePageItem("id2"),
                new tttMultiplePageItem("id3")
            };
            DisplayData = new CollectionViewSource();
            DisplayData.Source = _Data;
            DisplayData.View.Refresh();

            dataGrid22.ItemsSource = DisplayData.View;
        }
        private DataTemplate _CreateTemplate()
        {
            Binding bindingConent = new Binding("Content") { RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent) };

            FrameworkElementFactory fefLabel = new FrameworkElementFactory(typeof(TextBlock));
            fefLabel.SetBinding(TextBlock.TextProperty, bindingConent);
            fefLabel.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);

            FrameworkElementFactory image = new FrameworkElementFactory(typeof(Image));
            image.SetValue(Image.SourceProperty, new BitmapImage(
                new Uri(@"C:\Users\chadhong\Documents\Visual Studio 2015\Projects\SVN_Project\WinControlCenter_Thai\WinControlCenter\Images\material_icon\baseline_list_black_18dp.png")));
            image.SetValue(Image.HeightProperty, 21.0);
            image.SetValue(Image.WidthProperty, 18.0);

            FrameworkElementFactory fefGrid = new FrameworkElementFactory(typeof(WrapPanel));
            //FrameworkElementFactory fefGrid = new FrameworkElementFactory(typeof(Grid));

            //var fefColumn1 = new FrameworkElementFactory(typeof(ColumnDefinition));
            //fefColumn1.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
            //var fefColumn2 = new FrameworkElementFactory(typeof(ColumnDefinition));
            //fefColumn2.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
            //fefGrid.AppendChild(fefColumn1);
            //fefGrid.AppendChild(fefColumn2);

            fefGrid.AppendChild(fefLabel);
            fefGrid.AppendChild(image);

            DataTemplate dataTemplate = new DataTemplate();
            dataTemplate.VisualTree = fefGrid;
            return dataTemplate;
        }

    }
}
