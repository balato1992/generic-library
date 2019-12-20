using System;
using System.Windows.Forms;
using TestSamples.LanguageChanging;

namespace TestSamples
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLanguageChanging_Click(object sender, EventArgs e)
        {
            new LanguageChangingSample().Show();
        }

        private void btnRpn_Click(object sender, EventArgs e)
        {
            new JsonConvertSample().Show();
        }
    }
}
