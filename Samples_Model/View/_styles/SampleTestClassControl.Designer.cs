namespace MyModelSample.View._styles
{
    partial class SampleTestClassControl
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
            this.cb_Checked = new System.Windows.Forms.CheckBox();
            this.tb_String1 = new System.Windows.Forms.TextBox();
            this.tb_String2 = new System.Windows.Forms.TextBox();
            this.tb_String3 = new System.Windows.Forms.TextBox();
            this.label_Checked = new System.Windows.Forms.Label();
            this.label_String1 = new System.Windows.Forms.Label();
            this.label_String2 = new System.Windows.Forms.Label();
            this.label_String3 = new System.Windows.Forms.Label();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_Checked
            // 
            this.cb_Checked.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cb_Checked.AutoSize = true;
            this.cb_Checked.Location = new System.Drawing.Point(91, 25);
            this.cb_Checked.Name = "cb_Checked";
            this.cb_Checked.Size = new System.Drawing.Size(15, 14);
            this.cb_Checked.TabIndex = 0;
            this.cb_Checked.UseVisualStyleBackColor = true;
            // 
            // tb_String1
            // 
            this.tb_String1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tb_String1.Location = new System.Drawing.Point(91, 85);
            this.tb_String1.Name = "tb_String1";
            this.tb_String1.Size = new System.Drawing.Size(100, 22);
            this.tb_String1.TabIndex = 1;
            // 
            // tb_String2
            // 
            this.tb_String2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tb_String2.Location = new System.Drawing.Point(91, 149);
            this.tb_String2.Name = "tb_String2";
            this.tb_String2.Size = new System.Drawing.Size(100, 22);
            this.tb_String2.TabIndex = 1;
            // 
            // tb_String3
            // 
            this.tb_String3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tb_String3.Location = new System.Drawing.Point(91, 213);
            this.tb_String3.Name = "tb_String3";
            this.tb_String3.Size = new System.Drawing.Size(100, 22);
            this.tb_String3.TabIndex = 1;
            // 
            // label_Checked
            // 
            this.label_Checked.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Checked.AutoSize = true;
            this.label_Checked.Location = new System.Drawing.Point(19, 26);
            this.label_Checked.Name = "label_Checked";
            this.label_Checked.Size = new System.Drawing.Size(46, 12);
            this.label_Checked.TabIndex = 2;
            this.label_Checked.Text = "Checked";
            // 
            // label_String1
            // 
            this.label_String1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_String1.AutoSize = true;
            this.label_String1.Location = new System.Drawing.Point(26, 90);
            this.label_String1.Name = "label_String1";
            this.label_String1.Size = new System.Drawing.Size(39, 12);
            this.label_String1.TabIndex = 2;
            this.label_String1.Text = "String1";
            // 
            // label_String2
            // 
            this.label_String2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_String2.AutoSize = true;
            this.label_String2.Location = new System.Drawing.Point(26, 154);
            this.label_String2.Name = "label_String2";
            this.label_String2.Size = new System.Drawing.Size(39, 12);
            this.label_String2.TabIndex = 2;
            this.label_String2.Text = "String2";
            // 
            // label_String3
            // 
            this.label_String3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_String3.AutoSize = true;
            this.label_String3.Location = new System.Drawing.Point(26, 218);
            this.label_String3.Name = "label_String3";
            this.label_String3.Size = new System.Drawing.Size(39, 12);
            this.label_String3.TabIndex = 2;
            this.label_String3.Text = "String3";
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 3;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tlp_Main.Controls.Add(this.cb_Checked, 2, 0);
            this.tlp_Main.Controls.Add(this.label_String3, 0, 3);
            this.tlp_Main.Controls.Add(this.tb_String1, 2, 1);
            this.tlp_Main.Controls.Add(this.label_String2, 0, 2);
            this.tlp_Main.Controls.Add(this.tb_String2, 2, 2);
            this.tlp_Main.Controls.Add(this.label_String1, 0, 1);
            this.tlp_Main.Controls.Add(this.tb_String3, 2, 3);
            this.tlp_Main.Controls.Add(this.label_Checked, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 4;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_Main.Size = new System.Drawing.Size(227, 257);
            this.tlp_Main.TabIndex = 3;
            // 
            // SampleTestClassControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "SampleTestClassControl";
            this.Size = new System.Drawing.Size(227, 257);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_Checked;
        private System.Windows.Forms.TextBox tb_String1;
        private System.Windows.Forms.TextBox tb_String2;
        private System.Windows.Forms.TextBox tb_String3;
        private System.Windows.Forms.Label label_Checked;
        private System.Windows.Forms.Label label_String1;
        private System.Windows.Forms.Label label_String2;
        private System.Windows.Forms.Label label_String3;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;
    }
}
