namespace TestSamples.LanguageChanging
{
    partial class LanguageChangingSample
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
            this.btn_getString = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_default = new System.Windows.Forms.Button();
            this.btn_zhTW = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_getString
            // 
            this.btn_getString.Location = new System.Drawing.Point(171, 125);
            this.btn_getString.Name = "btn_getString";
            this.btn_getString.Size = new System.Drawing.Size(75, 23);
            this.btn_getString.TabIndex = 0;
            this.btn_getString.Text = "Get String";
            this.btn_getString.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "label4";
            // 
            // btn_default
            // 
            this.btn_default.Location = new System.Drawing.Point(26, 48);
            this.btn_default.Name = "btn_default";
            this.btn_default.Size = new System.Drawing.Size(121, 23);
            this.btn_default.TabIndex = 0;
            this.btn_default.Text = "Change to default";
            this.btn_default.UseVisualStyleBackColor = true;
            // 
            // btn_zhTW
            // 
            this.btn_zhTW.Location = new System.Drawing.Point(26, 77);
            this.btn_zhTW.Name = "btn_zhTW";
            this.btn_zhTW.Size = new System.Drawing.Size(121, 23);
            this.btn_zhTW.TabIndex = 0;
            this.btn_zhTW.Text = "Change to zh-TW";
            this.btn_zhTW.UseVisualStyleBackColor = true;
            // 
            // LanguageChangingSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 341);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_zhTW);
            this.Controls.Add(this.btn_default);
            this.Controls.Add(this.btn_getString);
            this.Name = "LanguageChangingSample";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_getString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_default;
        private System.Windows.Forms.Button btn_zhTW;
    }
}

