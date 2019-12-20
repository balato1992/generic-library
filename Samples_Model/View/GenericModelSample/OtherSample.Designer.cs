namespace MyModelSample.View.GenericModelSample
{
    partial class OtherSample
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
            this.btn_ProgramStackHelper = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ProgramStackHelper
            // 
            this.btn_ProgramStackHelper.Location = new System.Drawing.Point(53, 60);
            this.btn_ProgramStackHelper.Name = "btn_ProgramStackHelper";
            this.btn_ProgramStackHelper.Size = new System.Drawing.Size(135, 23);
            this.btn_ProgramStackHelper.TabIndex = 0;
            this.btn_ProgramStackHelper.Text = "ProgramStackHelper";
            this.btn_ProgramStackHelper.UseVisualStyleBackColor = true;
            this.btn_ProgramStackHelper.Click += new System.EventHandler(this.btn_ProgramStackHelper_Click);
            // 
            // OtherSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 310);
            this.Controls.Add(this.btn_ProgramStackHelper);
            this.Name = "OtherSample";
            this.Text = "Other";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ProgramStackHelper;
    }
}