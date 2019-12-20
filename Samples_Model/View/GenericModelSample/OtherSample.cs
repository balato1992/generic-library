using GenericModel.Other;
using System;
using System.Windows.Forms;

namespace MyModelSample.View.GenericModelSample
{
    public partial class OtherSample : Form
    {
        public OtherSample()
        {
            InitializeComponent();
        }

        private void ProgramStackHelper_GetCurrentMethod()
        {
            string tmp = ProgramStackHelper.GetCurrentMethod();
        }

        private void ProgramStackHelper_GetPreviousMethod()
        {
            string tmp = ProgramStackHelper.GetPreviousMethod();
        }

        private void btn_ProgramStackHelper_Click(object sender, EventArgs e)
        {
            ProgramStackHelper_GetCurrentMethod();
            ProgramStackHelper_GetPreviousMethod();
        }
    }
}