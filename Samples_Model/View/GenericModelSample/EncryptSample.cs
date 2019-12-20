using GenericModel.Other;
using System;
using System.Windows.Forms;

namespace MyModelSample.View
{
    public partial class EncryptSample : Form
    {
        public EncryptSample()
        {
            InitializeComponent();
        }

        // 32 個英文或數字
        private string key = "1234567890" +
                     "1234567890" +
                     "123456789012";

        // 16 個英文或數字
        private string iv = "1234567890" +
                    "abcdef";

        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            var input = textBox1.Text;

            var encryptResult = CryptographyHelper.EncryptAES256(input, key, iv);
            textBox_encrypt.Text = encryptResult;
        }

        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            try
            {
                var input = textBox1.Text;

                var encryptResult = CryptographyHelper.DecryptAES256(input, key, iv);
                textBox_decrypt.Text = encryptResult;
            }
            catch
            {
                MessageBox.Show("Some decrypt error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}