using GenericModel.Other;
using GenericWinForm.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyModelSample.View.GenericWinFormSample
{
    public partial class GenericTabControlSample : Form
    {
        public GenericTabControlSample()
        {
            InitializeComponent();
        }

        private void SetHeaderToDefault(TabControl tb)
        {
            tb.SizeMode = TabSizeMode.Normal;
            tb.Appearance = TabAppearance.Normal;
            tb.ItemSize = new Size(54, 18);
        }

        private void btn_HideHeader_Click(object sender, EventArgs e)
        {
            pGenericTabControl1.HideHeader();
            pGenericTabControl2.HideHeader();
            TabControlHelper.HideHeader(pTabControl1);
            TabControlHelper.HideHeader(pTabControl2);
        }

        private void btn_ShowHeader_Click(object sender, EventArgs e)
        {
            SetHeaderToDefault(pGenericTabControl1);
            SetHeaderToDefault(pGenericTabControl2);
            SetHeaderToDefault(pTabControl1);
            SetHeaderToDefault(pTabControl2);
        }

        private void btn_ChangeBackgroundColor_Click(object sender, EventArgs e)
        {
            this.BackColor = RandomHelper.GetColor();
        }
    }
}