namespace TestSamples
{
    partial class MainForm
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
            this.btnLanguageChanging = new System.Windows.Forms.Button();
            this.btnRpn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLanguageChanging
            // 
            this.btnLanguageChanging.Location = new System.Drawing.Point(12, 12);
            this.btnLanguageChanging.Name = "btnLanguageChanging";
            this.btnLanguageChanging.Size = new System.Drawing.Size(239, 27);
            this.btnLanguageChanging.TabIndex = 0;
            this.btnLanguageChanging.Text = "Test Language Changing";
            this.btnLanguageChanging.UseVisualStyleBackColor = true;
            this.btnLanguageChanging.Click += new System.EventHandler(this.btnLanguageChanging_Click);
            // 
            // btnRpn
            // 
            this.btnRpn.Location = new System.Drawing.Point(12, 45);
            this.btnRpn.Name = "btnRpn";
            this.btnRpn.Size = new System.Drawing.Size(239, 27);
            this.btnRpn.TabIndex = 0;
            this.btnRpn.Text = "Test Reverse Polish NotationSample";
            this.btnRpn.UseVisualStyleBackColor = true;
            this.btnRpn.Click += new System.EventHandler(this.btnRpn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRpn);
            this.Controls.Add(this.btnLanguageChanging);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLanguageChanging;
        private System.Windows.Forms.Button btnRpn;
    }
}