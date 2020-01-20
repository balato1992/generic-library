using GenericModel.Other;
using MyModelSample.View;
using MyModelSample.View.GenericModelSample;
using System;
using System.Windows.Forms;

namespace Sample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            string t = CryptographyHelper.DecryptAES256(@"eUBvgXM5OVC3PzP07XuCezb5GZReHcS9yJf0CTBI8ihVZglRIeTB0aS642BnJ8J3tOrH3dEFp/uZL2JlPO23/0+lXRJL+Aet9OOz2Jg+aZL4zaNTirFN63CiBoZG1BEYwsihOKdGjYhWocNFh/1ElBOKjwKP+QprEGIJdHuTObrbjkW0khILXecaa94U2UT64RUwJk+zJ7rQSuuw+Bh+n0xB8HUYWYToKpufVg0xfzZP+xGodi0uqV8Qnk+iJkIJPZ1o0VzzKRbF9PYiOqNBEA==", "12345678901234567890123456789012", "1234567890abcdef");
        }

        private void button_encrypt_Click(object sender, EventArgs e)
        {
            new EncryptSample().Show();
        }
        private void button_XmlHelper_Click(object sender, EventArgs e)
        {
            new XmlHelperSample().Show();
        }
        private void btn_Other_Click(object sender, EventArgs e)
        {
            new OtherSample().Show();
        }

        private void btn_PollingTimer_Click(object sender, EventArgs e)
        {
            new PollingTimerSample().Show();
        }
        private void button_loadingBar45_Click(object sender, EventArgs e)
        {
            LoadingBar4_5.Test(this);
        }
    }

}
