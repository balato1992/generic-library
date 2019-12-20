namespace MyModelSample.View
{
    partial class EncryptSample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_decrypt = new System.Windows.Forms.Button();
            this.btn_encrypt = new System.Windows.Forms.Button();
            this.textBox_encrypt = new System.Windows.Forms.TextBox();
            this.textBox_decrypt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(34, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(359, 22);
            this.textBox1.TabIndex = 7;
            // 
            // btn_decrypt
            // 
            this.btn_decrypt.Location = new System.Drawing.Point(44, 113);
            this.btn_decrypt.Name = "btn_decrypt";
            this.btn_decrypt.Size = new System.Drawing.Size(75, 23);
            this.btn_decrypt.TabIndex = 3;
            this.btn_decrypt.Text = "Decrypt";
            this.btn_decrypt.UseVisualStyleBackColor = true;
            this.btn_decrypt.Click += new System.EventHandler(this.btn_decrypt_Click);
            // 
            // btn_encrypt
            // 
            this.btn_encrypt.Location = new System.Drawing.Point(44, 74);
            this.btn_encrypt.Name = "btn_encrypt";
            this.btn_encrypt.Size = new System.Drawing.Size(75, 23);
            this.btn_encrypt.TabIndex = 4;
            this.btn_encrypt.Text = "Encrypt";
            this.btn_encrypt.UseVisualStyleBackColor = true;
            this.btn_encrypt.Click += new System.EventHandler(this.btn_encrypt_Click);
            // 
            // textBox_encrypt
            // 
            this.textBox_encrypt.Location = new System.Drawing.Point(125, 74);
            this.textBox_encrypt.Name = "textBox_encrypt";
            this.textBox_encrypt.Size = new System.Drawing.Size(268, 22);
            this.textBox_encrypt.TabIndex = 7;
            this.textBox_encrypt.Text = "encrypt here";
            // 
            // textBox_decrypt
            // 
            this.textBox_decrypt.Location = new System.Drawing.Point(125, 113);
            this.textBox_decrypt.Name = "textBox_decrypt";
            this.textBox_decrypt.Size = new System.Drawing.Size(268, 22);
            this.textBox_decrypt.TabIndex = 7;
            this.textBox_decrypt.Text = "decrypt here";
            // 
            // EncryptSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 167);
            this.Controls.Add(this.textBox_decrypt);
            this.Controls.Add(this.textBox_encrypt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_decrypt);
            this.Controls.Add(this.btn_encrypt);
            this.Name = "EncryptSample";
            this.Text = "EncryptSample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_decrypt;
        private System.Windows.Forms.Button btn_encrypt;
        private System.Windows.Forms.TextBox textBox_encrypt;
        private System.Windows.Forms.TextBox textBox_decrypt;
    }
}