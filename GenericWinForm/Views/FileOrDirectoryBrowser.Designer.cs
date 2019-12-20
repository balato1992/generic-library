namespace GenericWinForm.Views
{
    partial class FileOrDirectoryBrowser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlp_folder = new System.Windows.Forms.TableLayoutPanel();
            this.btn_folderPath_open = new System.Windows.Forms.Button();
            this.tb_path_text = new System.Windows.Forms.TextBox();
            this.label_path = new System.Windows.Forms.Label();
            this.btn_folderPath_browse = new System.Windows.Forms.Button();
            this.fbd_folderPath = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog_filePath = new System.Windows.Forms.OpenFileDialog();
            this.tlp_folder.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_folder
            // 
            this.tlp_folder.ColumnCount = 3;
            this.tlp_folder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_folder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlp_folder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlp_folder.Controls.Add(this.btn_folderPath_open, 0, 1);
            this.tlp_folder.Controls.Add(this.tb_path_text, 1, 0);
            this.tlp_folder.Controls.Add(this.label_path, 0, 0);
            this.tlp_folder.Controls.Add(this.btn_folderPath_browse, 2, 1);
            this.tlp_folder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_folder.Location = new System.Drawing.Point(0, 0);
            this.tlp_folder.Margin = new System.Windows.Forms.Padding(15);
            this.tlp_folder.Name = "tlp_folder";
            this.tlp_folder.RowCount = 2;
            this.tlp_folder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_folder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_folder.Size = new System.Drawing.Size(235, 55);
            this.tlp_folder.TabIndex = 5;
            // 
            // btn_folderPath_open
            // 
            this.btn_folderPath_open.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tlp_folder.SetColumnSpan(this.btn_folderPath_open, 2);
            this.btn_folderPath_open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_folderPath_open.Location = new System.Drawing.Point(10, 30);
            this.btn_folderPath_open.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btn_folderPath_open.Name = "btn_folderPath_open";
            this.btn_folderPath_open.Size = new System.Drawing.Size(75, 22);
            this.btn_folderPath_open.TabIndex = 1;
            this.btn_folderPath_open.Text = "Open Folder";
            this.btn_folderPath_open.UseVisualStyleBackColor = true;
            this.btn_folderPath_open.Click += new System.EventHandler(this.btn_folderPath_open_Click);
            // 
            // tb_path_text
            // 
            this.tb_path_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlp_folder.SetColumnSpan(this.tb_path_text, 2);
            this.tb_path_text.Location = new System.Drawing.Point(57, 3);
            this.tb_path_text.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.tb_path_text.Name = "tb_path_text";
            this.tb_path_text.ReadOnly = true;
            this.tb_path_text.Size = new System.Drawing.Size(168, 22);
            this.tb_path_text.TabIndex = 0;
            // 
            // label_path
            // 
            this.label_path.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_path.AutoSize = true;
            this.label_path.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_path.Location = new System.Drawing.Point(10, 7);
            this.label_path.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(33, 12);
            this.label_path.TabIndex = 2;
            this.label_path.Text = "Path:";
            // 
            // btn_folderPath_browse
            // 
            this.btn_folderPath_browse.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_folderPath_browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_folderPath_browse.Location = new System.Drawing.Point(150, 30);
            this.btn_folderPath_browse.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btn_folderPath_browse.Name = "btn_folderPath_browse";
            this.btn_folderPath_browse.Size = new System.Drawing.Size(75, 22);
            this.btn_folderPath_browse.TabIndex = 1;
            this.btn_folderPath_browse.Text = "Browse";
            this.btn_folderPath_browse.UseVisualStyleBackColor = true;
            this.btn_folderPath_browse.Click += new System.EventHandler(this.btn_folderPath_browse_Click);
            // 
            // openFileDialog_filePath
            // 
            this.openFileDialog_filePath.RestoreDirectory = true;
            // 
            // FileOrDirectoryBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_folder);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(0, 70);
            this.MinimumSize = new System.Drawing.Size(235, 55);
            this.Name = "FileOrDirectoryBrowser";
            this.Size = new System.Drawing.Size(235, 55);
            this.tlp_folder.ResumeLayout(false);
            this.tlp_folder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_folder;
        private System.Windows.Forms.Button btn_folderPath_open;
        private System.Windows.Forms.TextBox tb_path_text;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.Button btn_folderPath_browse;
        private System.Windows.Forms.FolderBrowserDialog fbd_folderPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog_filePath;
    }
}
