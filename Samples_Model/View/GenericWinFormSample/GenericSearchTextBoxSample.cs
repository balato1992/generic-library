using System;
using System.Windows.Forms;

namespace MyModelSample.View.GenericWinFormSample
{
    public partial class GenericSearchTextBoxSample : Form
    {
        public GenericSearchTextBoxSample()
        {
            InitializeComponent();
        }

        private void btn_ClearText_Click(object sender, EventArgs e)
        {
            pGenericSearchTextBox.ClearText();
        }
    }
}