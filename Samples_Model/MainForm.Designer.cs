using System.Drawing;

namespace Sample
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
            this.button_encrypt = new System.Windows.Forms.Button();
            this.button_loadingBar45 = new System.Windows.Forms.Button();
            this.button_XmlHelper = new System.Windows.Forms.Button();
            this.label_GenericModel = new System.Windows.Forms.Label();
            this.label_GenericWinForm = new System.Windows.Forms.Label();
            this.label_GenericWinForm4_5 = new System.Windows.Forms.Label();
            this.btn_Other = new System.Windows.Forms.Button();
            this.genericWinFormItems1 = new MyModelSample.View._styles.GenericWinFormItems();
            this.btn_PollingTimer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_encrypt
            // 
            this.button_encrypt.AutoSize = true;
            this.button_encrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.button_encrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_encrypt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_encrypt.ForeColor = System.Drawing.Color.White;
            this.button_encrypt.Location = new System.Drawing.Point(66, 141);
            this.button_encrypt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_encrypt.Name = "button_encrypt";
            this.button_encrypt.Size = new System.Drawing.Size(163, 43);
            this.button_encrypt.TabIndex = 0;
            this.button_encrypt.TabStop = false;
            this.button_encrypt.Text = "Encrypt";
            this.button_encrypt.UseVisualStyleBackColor = false;
            this.button_encrypt.Click += new System.EventHandler(this.button_encrypt_Click);
            // 
            // button_loadingBar45
            // 
            this.button_loadingBar45.AutoSize = true;
            this.button_loadingBar45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.button_loadingBar45.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_loadingBar45.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_loadingBar45.ForeColor = System.Drawing.Color.White;
            this.button_loadingBar45.Location = new System.Drawing.Point(548, 90);
            this.button_loadingBar45.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_loadingBar45.Name = "button_loadingBar45";
            this.button_loadingBar45.Size = new System.Drawing.Size(163, 43);
            this.button_loadingBar45.TabIndex = 0;
            this.button_loadingBar45.TabStop = false;
            this.button_loadingBar45.Text = "Loading Bar (4.5)";
            this.button_loadingBar45.UseVisualStyleBackColor = false;
            this.button_loadingBar45.Click += new System.EventHandler(this.button_loadingBar45_Click);
            // 
            // button_XmlHelper
            // 
            this.button_XmlHelper.AutoSize = true;
            this.button_XmlHelper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.button_XmlHelper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_XmlHelper.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_XmlHelper.ForeColor = System.Drawing.Color.White;
            this.button_XmlHelper.Location = new System.Drawing.Point(66, 192);
            this.button_XmlHelper.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_XmlHelper.Name = "button_XmlHelper";
            this.button_XmlHelper.Size = new System.Drawing.Size(163, 43);
            this.button_XmlHelper.TabIndex = 0;
            this.button_XmlHelper.TabStop = false;
            this.button_XmlHelper.Text = "Xml Helper";
            this.button_XmlHelper.UseVisualStyleBackColor = false;
            this.button_XmlHelper.Click += new System.EventHandler(this.button_XmlHelper_Click);
            // 
            // label_GenericModel
            // 
            this.label_GenericModel.AutoSize = true;
            this.label_GenericModel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_GenericModel.ForeColor = System.Drawing.Color.Black;
            this.label_GenericModel.Location = new System.Drawing.Point(61, 37);
            this.label_GenericModel.Name = "label_GenericModel";
            this.label_GenericModel.Size = new System.Drawing.Size(114, 19);
            this.label_GenericModel.TabIndex = 1;
            this.label_GenericModel.Text = "GenericModel";
            // 
            // label_GenericWinForm
            // 
            this.label_GenericWinForm.AutoSize = true;
            this.label_GenericWinForm.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_GenericWinForm.ForeColor = System.Drawing.Color.Black;
            this.label_GenericWinForm.Location = new System.Drawing.Point(273, 37);
            this.label_GenericWinForm.Name = "label_GenericWinForm";
            this.label_GenericWinForm.Size = new System.Drawing.Size(137, 19);
            this.label_GenericWinForm.TabIndex = 1;
            this.label_GenericWinForm.Text = "GenericWinForm";
            // 
            // label_GenericWinForm4_5
            // 
            this.label_GenericWinForm4_5.AutoSize = true;
            this.label_GenericWinForm4_5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_GenericWinForm4_5.ForeColor = System.Drawing.Color.Black;
            this.label_GenericWinForm4_5.Location = new System.Drawing.Point(544, 37);
            this.label_GenericWinForm4_5.Name = "label_GenericWinForm4_5";
            this.label_GenericWinForm4_5.Size = new System.Drawing.Size(164, 19);
            this.label_GenericWinForm4_5.TabIndex = 1;
            this.label_GenericWinForm4_5.Text = "GenericWinForm4_5";
            // 
            // btn_Other
            // 
            this.btn_Other.AutoSize = true;
            this.btn_Other.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btn_Other.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Other.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Other.ForeColor = System.Drawing.Color.White;
            this.btn_Other.Location = new System.Drawing.Point(66, 243);
            this.btn_Other.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Other.Name = "btn_Other";
            this.btn_Other.Size = new System.Drawing.Size(163, 43);
            this.btn_Other.TabIndex = 0;
            this.btn_Other.TabStop = false;
            this.btn_Other.Text = "Other";
            this.btn_Other.UseVisualStyleBackColor = false;
            this.btn_Other.Click += new System.EventHandler(this.btn_Other_Click);
            // 
            // genericWinFormItems1
            // 
            this.genericWinFormItems1.Location = new System.Drawing.Point(277, 90);
            this.genericWinFormItems1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.genericWinFormItems1.Name = "genericWinFormItems1";
            this.genericWinFormItems1.Size = new System.Drawing.Size(196, 285);
            this.genericWinFormItems1.TabIndex = 4;
            // 
            // btn_PollingTimer
            // 
            this.btn_PollingTimer.AutoSize = true;
            this.btn_PollingTimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btn_PollingTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PollingTimer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PollingTimer.ForeColor = System.Drawing.Color.White;
            this.btn_PollingTimer.Location = new System.Drawing.Point(65, 294);
            this.btn_PollingTimer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_PollingTimer.Name = "btn_PollingTimer";
            this.btn_PollingTimer.Size = new System.Drawing.Size(163, 43);
            this.btn_PollingTimer.TabIndex = 0;
            this.btn_PollingTimer.TabStop = false;
            this.btn_PollingTimer.Text = "PollingTimer";
            this.btn_PollingTimer.UseVisualStyleBackColor = false;
            this.btn_PollingTimer.Click += new System.EventHandler(this.btn_PollingTimer_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(1067, 389);
            this.Controls.Add(this.genericWinFormItems1);
            this.Controls.Add(this.label_GenericWinForm4_5);
            this.Controls.Add(this.label_GenericWinForm);
            this.Controls.Add(this.label_GenericModel);
            this.Controls.Add(this.btn_PollingTimer);
            this.Controls.Add(this.btn_Other);
            this.Controls.Add(this.button_XmlHelper);
            this.Controls.Add(this.button_encrypt);
            this.Controls.Add(this.button_loadingBar45);
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Samples";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_encrypt;
        private System.Windows.Forms.Button button_loadingBar45;
        private System.Windows.Forms.Button button_XmlHelper;
        private System.Windows.Forms.Label label_GenericModel;
        private System.Windows.Forms.Label label_GenericWinForm;
        private System.Windows.Forms.Label label_GenericWinForm4_5;
        private MyModelSample.View._styles.GenericWinFormItems genericWinFormItems1;
        private System.Windows.Forms.Button btn_Other;
        private System.Windows.Forms.Button btn_PollingTimer;
    }
}

