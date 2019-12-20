using ChartDirector;
using System.Collections;

namespace MyChartDirector.models.MyChartDirector
{
    public class ChartDirectorHelper
    {

        private static readonly ChartDirectorHelper _instance = new ChartDirectorHelper();

        public static ChartDirectorHelper Instance
        {
            get
            {
                return _instance;
            }
        }

        private ChartDirectorHelper()
        {
            this.SetLicenseCode();
        }

        public void SetLicenseCode()
        {
            ChartDirector.Chart.setLicenseCode("RDST-25KD-5294-JDK4-5732-2EA7");

            // for fst
            // there are two LicenseCodes
            // from (Redistribute)
            //  RDST-25KD-5294-JDK4-5732-2EA7 
            // from normal
            //  DEVP-2JAU-9NMU-P9S2-0EF6-4B0F
        }

        public void CreateChartInViewer(WinChartViewer viewer, double[] data1, double[] data2, string[] labels)
        {
            viewer.HotSpotCursor = System.Windows.Forms.Cursors.Hand;
            XYChart c = CreateChart(viewer.Width, viewer.Height, data1, data2, labels);

            viewer.Chart = c;
            viewer.ImageMap = c.getHTMLImageMap("clickable", "", "title='{xLabel}: {dataSetName} {value}%'");

            viewer.HotSpotCursor = System.Windows.Forms.Cursors.Hand;
        }

        public XYChart CreateChart(int width, int height, double[] data1, double[] data2, string[] labels)
        {
            XYChart c = new XYChart(width, height);
            c.setBackground(c.linearGradientColor(0, 0, 0, height, 0xfffff6, 0xffffea));

            PlotArea plotarea = c.setPlotArea(width / 10, height / 10, width * 8 / 10, height * 8 / 10);

            //plotarea.setBackground(c.linearGradientColor(60, 40, 60, 280, 0xeeeeff, 0x0000cc));

            c.xAxis().setLabels(labels);


            LineLayer layer = c.addLineLayer();
            layer.addDataSet(data1, 0xcf4040, "data1").setDataSymbol(Chart.SquareSymbol, 7);
            layer.addDataSet(data2, 0x40cf40, "data2").setDataSymbol(Chart.DiamondSymbol, 11);
            layer.setDataLabelFormat("{value|0}%");


            return c;
        }


    }

    public class ClickEventStruct
    {
        public string value { get; }
        public string x { get; }
        public string path { get; }
        public string xLabel { get; }
        public string title { get; }
        public string dataSet { get; }
        public string coords { get; }
        public string dataSetName { get; }

        public ClickEventStruct(Hashtable attrValues)
        {
            this.value = (string)attrValues["value"];
            this.x = (string)attrValues["x"];
            this.path = (string)attrValues["path"];
            this.xLabel = (string)attrValues["xLabel"];
            this.title = (string)attrValues["title"];
            this.dataSet = (string)attrValues["dataSet"];
            this.coords = (string)attrValues["coords"];
            this.dataSetName = (string)attrValues["dataSetName"];
        }
    }

    public class Samples
    {
        // http://www.advsofteng.com/doc/cdnetdoc/simpleline.htm
        //Main code for creating chart.
        //Note: the argument chartIndex is unused because this demo only has 1 chart.
        public static void CreateChart(WinChartViewer viewer)
        {
            // The data for the line chart
            double[] data = {30, 28, 40, 55, 75, 68, 54, 60, 50, 62, 75, 65, 75, 91, 60, 55, 53, 35,
                50, 66, 56, 48, 52, 65, 62};

            // The labels for the line chart
            string[] labels = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12",
                "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"};

            // Create a XYChart object of size 250 x 250 pixels
            XYChart c = new XYChart(250, 250);

            // Set the plotarea at (30, 20) and of size 200 x 200 pixels
            c.setPlotArea(30, 20, 200, 200);

            // Add a line chart layer using the given data
            c.addLineLayer(data);

            // Set the labels on the x axis.
            c.xAxis().setLabels(labels);

            // Display 1 out of 3 labels on the x-axis.
            c.xAxis().setLabelStep(3);

            // Output the chart
            viewer.Chart = c;

            // for web page
            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "", "title='Hour {xLabel}: Traffic {value} GBytes'");
        }


        // http://www.advsofteng.com/doc/cdnetdoc/simpleclickable.htm
        public static void ClickableCharts(WinChartViewer viewer)
        {

            // The data for the bar chart
            double[] data = { 450, 560, 630, 800, 1100, 1350, 1600, 1950, 2300, 2700 };

            // The labels for the bar chart
            string[] labels = { "1996", "1997", "1998", "1999", "2000", "2001", "2002", "2003", "2004", "2005" };

            // Create a XYChart object of size 600 x 360 pixels
            XYChart c = new XYChart(600, 360);

            // Add a title to the chart using 18pt Times Bold Italic font
            c.addTitle("Annual Revenue for Star Tech", "Times New Roman Bold Italic", 18);

            // Set the plotarea at (60, 40) and of size 500 x 280 pixels. Use a vertical gradient color from
            // light blue (eeeeff) to deep blue (0000cc) as background. Set border and grid lines to white
            // (ffffff).
            c.setPlotArea(60, 40, 500, 280, c.linearGradientColor(60, 40, 60, 280, 0xeeeeff, 0x0000cc), -1, 0xffffff, 0xffffff);

            // Add a multi-color bar chart layer using the supplied data. Use soft lighting effect with
            // light direction from top.
            c.addBarLayer3(data).setBorderColor(Chart.Transparent, Chart.softLighting(Chart.Top));

            // Set x axis labels using the given labels
            c.xAxis().setLabels(labels);

            // Draw the ticks between label positions (instead of at label positions)
            c.xAxis().setTickOffset(0.5);

            // When auto-scaling, use tick spacing of 40 pixels as a guideline
            c.yAxis().setTickDensity(40);

            // Add a title to the y axis with 12pt Times Bold Italic font
            c.yAxis().setTitle("USD (millions)", "Times New Roman Bold Italic", 12);

            // Set axis label style to 8pt Arial Bold
            c.xAxis().setLabelStyle("Arial Bold", 8);
            c.yAxis().setLabelStyle("Arial Bold", 8);

            // Set axis line width to 2 pixels
            c.xAxis().setWidth(2);
            c.yAxis().setWidth(2);

            // Create the image and save it in a temporary location
            viewer.Image = c.makeImage();

            // Create an image map for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickline.aspx", "", "title='{xLabel}: US$ {value|0}M'");
        }

        // http://www.advsofteng.com/doc/cdnet.htm#symbolline.htm
        public static void SymbolLineChart(WinChartViewer viewer)
        {
            // The data for the line chart
            double[] data0 = { 60.2, 51.7, 81.3, 48.6, 56.2, 68.9, 52.8 };
            double[] data1 = { 30.0, 32.7, 33.9, 29.5, 32.2, 28.4, 29.8 };
            string[] labels = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            // Create a XYChart object of size 300 x 180 pixels, with a pale yellow (0xffffc0) background, a
            // black border, and 1 pixel 3D border effect.
            XYChart c = new XYChart(300, 180, 0xffffc0, 0x000000, 1);

            // Set the plotarea at (45, 35) and of size 240 x 120 pixels, with white background. Turn on
            // both horizontal and vertical grid lines with light grey color (0xc0c0c0)
            c.setPlotArea(45, 35, 240, 120, 0xffffff, -1, -1, 0xc0c0c0, -1);

            // Add a legend box at (45, 12) (top of the chart) using horizontal layout and 8pt Arial font
            // Set the background and border color to Transparent.
            c.addLegend(45, 12, false, "", 8).setBackground(Chart.Transparent);

            // Add a title to the chart using 9pt Arial Bold/white font. Use a 1 x 2 bitmap pattern as the
            // background.
            c.addTitle("Server Load (Jun 01 - Jun 07)", "Arial Bold", 9, 0xffffff).setBackground(
                c.patternColor(new int[] { 0x004000, 0x008000 }, 2));

            // Set the y axis label format to nn%
            c.yAxis().setLabelFormat("{value}%");

            // Set the labels on the x axis
            c.xAxis().setLabels(labels);

            // Add a line layer to the chart
            LineLayer layer = c.addLineLayer();

            // Add the first line. Plot the points with a 7 pixel square symbol
            layer.addDataSet(data0, 0xcf4040, "Peak").setDataSymbol(Chart.SquareSymbol, 7);

            // Add the second line. Plot the points with a 9 pixel dismond symbol
            layer.addDataSet(data1, 0x40cf40, "Average").setDataSymbol(Chart.DiamondSymbol, 9);

            // Enable data label on the data points. Set the label format to nn%.
            layer.setDataLabelFormat("{value|0}%");

            // Output the chart
            viewer.Image = c.makeImage();

            // Include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("", "", "title='{xLabel}: {dataSetName} {value}%'");
        }

    }
}
