using ChartDirector;
using MyChartDirector.models.MyChartDirector;
using System;
using System.Windows.Forms;

namespace MyChartDirector
{
    public partial class ChartDirectorWin : Form
    {
        public ChartDirectorWin()
        {
            InitializeComponent();

            _InitialEvent();
            
        }

        private void _InitialEvent()
        {
            button_LineChart.Click += button_LineChart_Click;
            button_ClickableCharts.Click += button_ClickableCharts_Click;
            buttonSymbolLineChart.Click += buttonSymbolLineChart_Click;

            button_custom.Click += button_custom_Click;
        }

        private void button_LineChart_Click(object sender, EventArgs e)
        {
            Samples.CreateChart(winChartViewer1);
        }

        private void button_ClickableCharts_Click(object sender, EventArgs e)
        {
            Samples.ClickableCharts(winChartViewer1);
        }

        private void buttonSymbolLineChart_Click(object sender, EventArgs e)
        {
            Samples.SymbolLineChart(winChartViewer1);
        }

        private void button_custom_Click(object sender, EventArgs e)
        {
            ChartDirectorHelper.Instance.CreateChartInViewer(
                winChartViewer1,
                new double[] { 1, 2, 3 },
                new double[] { 3, 4, 5 },
                new string[] { "1", "2", "3" });

            winChartViewer1.ClickHotSpot += Viewer_ClickHotSpot;
        }

        private void Viewer_ClickHotSpot(object sender, WinHotSpotEventArgs e)
        {
            ClickEventStruct data = new ClickEventStruct(e.AttrValues);

            label_value.Text = "value: " + data.value;
            label_x.Text = "x: " + data.x;
            label_xLabel.Text = "xLabel: " + data.xLabel;
        }
    }
}
