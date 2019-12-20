namespace GenericWinForm.Views
{
    partial class LoadingDialogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingDialogForm));
            this.progressBar_main = new System.Windows.Forms.ProgressBar();
            this.label_displayWord = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar_main
            // 
            resources.ApplyResources(this.progressBar_main, "progressBar_main");
            this.progressBar_main.MarqueeAnimationSpeed = 30;
            this.progressBar_main.Name = "progressBar_main";
            this.progressBar_main.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // label_displayWord
            // 
            resources.ApplyResources(this.label_displayWord, "label_displayWord");
            this.label_displayWord.Name = "label_displayWord";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label_displayWord, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.progressBar_main, 1, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // LoadingDialogForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadingDialogForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar_main;
        private System.Windows.Forms.Label label_displayWord;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}