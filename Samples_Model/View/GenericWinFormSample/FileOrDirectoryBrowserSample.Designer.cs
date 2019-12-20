namespace MyModelSample.View.GenericWinFormSample
{
    partial class FileOrDirectoryBrowserSample
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
            this.pFileOrDirectoryBrowser = new GenericWinForm.Views.FileOrDirectoryBrowser();
            this.btn_SetPath = new System.Windows.Forms.Button();
            this.btn_GetPath = new System.Windows.Forms.Button();
            this.rtb_Event = new System.Windows.Forms.RichTextBox();
            this.label_Event = new System.Windows.Forms.Label();
            this.rb_Directory = new System.Windows.Forms.RadioButton();
            this.rb_File = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_Path = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pFileOrDirectoryBrowser
            // 
            this.pFileOrDirectoryBrowser.BrowserType = GenericWinForm.Views.BrowserType.Directory;
            this.pFileOrDirectoryBrowser.Location = new System.Drawing.Point(39, 30);
            this.pFileOrDirectoryBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.pFileOrDirectoryBrowser.MaximumSize = new System.Drawing.Size(0, 70);
            this.pFileOrDirectoryBrowser.MinimumSize = new System.Drawing.Size(235, 55);
            this.pFileOrDirectoryBrowser.Name = "pFileOrDirectoryBrowser";
            this.pFileOrDirectoryBrowser.Size = new System.Drawing.Size(257, 55);
            this.pFileOrDirectoryBrowser.TabIndex = 0;
            this.pFileOrDirectoryBrowser.BrowseOK += new System.EventHandler<GenericWinForm.Views.BrowseOKEventHandlerEventArgs>(this.pFileOrDirectoryBrowser_BrowseOK_1);
            // 
            // btn_SetPath
            // 
            this.btn_SetPath.Location = new System.Drawing.Point(194, 125);
            this.btn_SetPath.Name = "btn_SetPath";
            this.btn_SetPath.Size = new System.Drawing.Size(75, 23);
            this.btn_SetPath.TabIndex = 1;
            this.btn_SetPath.Text = "Set Path";
            this.btn_SetPath.UseVisualStyleBackColor = true;
            this.btn_SetPath.Click += new System.EventHandler(this.btn_SetPath_Click);
            // 
            // btn_GetPath
            // 
            this.btn_GetPath.Location = new System.Drawing.Point(194, 154);
            this.btn_GetPath.Name = "btn_GetPath";
            this.btn_GetPath.Size = new System.Drawing.Size(75, 23);
            this.btn_GetPath.TabIndex = 1;
            this.btn_GetPath.Text = "Get Path";
            this.btn_GetPath.UseVisualStyleBackColor = true;
            this.btn_GetPath.Click += new System.EventHandler(this.btn_GetPath_Click);
            // 
            // rtb_Event
            // 
            this.rtb_Event.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_Event.Location = new System.Drawing.Point(88, 212);
            this.rtb_Event.Name = "rtb_Event";
            this.rtb_Event.ReadOnly = true;
            this.rtb_Event.Size = new System.Drawing.Size(134, 88);
            this.rtb_Event.TabIndex = 2;
            this.rtb_Event.Text = "";
            // 
            // label_Event
            // 
            this.label_Event.AutoSize = true;
            this.label_Event.Location = new System.Drawing.Point(86, 197);
            this.label_Event.Name = "label_Event";
            this.label_Event.Size = new System.Drawing.Size(35, 12);
            this.label_Event.TabIndex = 3;
            this.label_Event.Text = "Event:";
            // 
            // rb_Directory
            // 
            this.rb_Directory.AutoSize = true;
            this.rb_Directory.Location = new System.Drawing.Point(7, 10);
            this.rb_Directory.Name = "rb_Directory";
            this.rb_Directory.Size = new System.Drawing.Size(67, 16);
            this.rb_Directory.TabIndex = 4;
            this.rb_Directory.TabStop = true;
            this.rb_Directory.Text = "Directory";
            this.rb_Directory.UseVisualStyleBackColor = true;
            this.rb_Directory.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_File
            // 
            this.rb_File.AutoSize = true;
            this.rb_File.Location = new System.Drawing.Point(7, 29);
            this.rb_File.Name = "rb_File";
            this.rb_File.Size = new System.Drawing.Size(40, 16);
            this.rb_File.TabIndex = 4;
            this.rb_File.TabStop = true;
            this.rb_File.Text = "File";
            this.rb_File.UseVisualStyleBackColor = true;
            this.rb_File.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rb_Directory);
            this.panel1.Controls.Add(this.rb_File);
            this.panel1.Location = new System.Drawing.Point(81, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(82, 51);
            this.panel1.TabIndex = 5;
            // 
            // tb_Path
            // 
            this.tb_Path.Location = new System.Drawing.Point(275, 143);
            this.tb_Path.Name = "tb_Path";
            this.tb_Path.Size = new System.Drawing.Size(155, 22);
            this.tb_Path.TabIndex = 6;
            // 
            // FileOrDirectoryBrowserSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 334);
            this.Controls.Add(this.tb_Path);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_Event);
            this.Controls.Add(this.rtb_Event);
            this.Controls.Add(this.btn_GetPath);
            this.Controls.Add(this.btn_SetPath);
            this.Controls.Add(this.pFileOrDirectoryBrowser);
            this.Name = "FileOrDirectoryBrowserSample";
            this.Text = "FileOrDirectoryBrowserSample";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GenericWinForm.Views.FileOrDirectoryBrowser pFileOrDirectoryBrowser;
        private System.Windows.Forms.Button btn_SetPath;
        private System.Windows.Forms.Button btn_GetPath;
        private System.Windows.Forms.RichTextBox rtb_Event;
        private System.Windows.Forms.Label label_Event;
        private System.Windows.Forms.RadioButton rb_Directory;
        private System.Windows.Forms.RadioButton rb_File;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_Path;
    }
}