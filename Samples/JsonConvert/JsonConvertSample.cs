using System.Collections.Generic;
using System.Windows.Forms;
using TestSamples.Rpn;

namespace TestSamples
{
    public partial class JsonConvertSample : Form
    {
        public JsonConvertSample()
        {
            InitializeComponent();

            List<string> postfix = Operation.ReversePolishNotation(Operation.GetSampleString());
            VisualizingRpn.SaveBmp("result.bmp", postfix);

            Dictionary<string, object> result = CusConvert.Start(postfix);
        }
    }
}
