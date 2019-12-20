using System.Windows.Forms;

namespace MyModelSample.View._styles
{
    public partial class SampleTestClassControl : UserControl
    {
        public SampleTestClassControl()
        {
            InitializeComponent();
        }

        public SampleTestClass Data
        {
            get
            {
                SampleTestClass rtnData = new SampleTestClass();

                rtnData.IsChecked = cb_Checked.Checked;
                rtnData.String1 = tb_String1.Text;
                rtnData.String2 = tb_String2.Text;
                rtnData.String3 = tb_String3.Text;

                return rtnData;
            }
            set
            {
                if (value == null)
                {
                    return;
                }

                cb_Checked.Checked = value.IsChecked;
                tb_String1.Text = value.String1;
                tb_String2.Text = value.String2;
                tb_String3.Text = value.String3;
            }
        }
    }
}