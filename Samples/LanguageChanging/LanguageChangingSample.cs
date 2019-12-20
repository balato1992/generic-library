using System;
using System.Windows.Forms;

namespace TestSamples.LanguageChanging
{
    public partial class LanguageChangingSample : Form
    {
        public LanguageChangingSample()
        {
            InitializeComponent();
             
            InitialieButtonEvent();
            
        }

        private void InitialieButtonEvent()
        {
            btn_getString.Click += btn_getString_Click;
            btn_default.Click += btn_default_Click;
            btn_zhTW.Click += btn_zhTW_Click;
        }

        private void btn_getString_Click(object sender, EventArgs e)
        {
            label1.Text = LanguageHelper.Instance.GetMessage(MessageTags.String1);
            label2.Text = LanguageHelper.Instance.GetMessage(MessageTags.String2);
            label3.Text = LanguageHelper.Instance.GetMessage(MessageTags.String3);
            label4.Text = LanguageHelper.Instance.GetMessage(MessageTags.String4);
        }

        private void btn_default_Click(object sender, EventArgs e)
        {
            LanguageHelper.Instance.SetLanguage(LanguageTypes.defaultLang);
        }

        private void btn_zhTW_Click(object sender, EventArgs e)
        {
            LanguageHelper.Instance.SetLanguage(LanguageTypes.zhTW);
        }
    }
}
