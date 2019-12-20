namespace MyModelSample.View.GenericWinFormSample
{
    partial class GenericSearchTextBoxSample
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
            this.components = new System.ComponentModel.Container();
            this.pGenericSearchTextBox = new GenericWinForm.Views.GenericSearchTextBox(this.components);
            this.btn_ClearText = new System.Windows.Forms.Button();
            this.label_Description = new System.Windows.Forms.Label();
            this.pTextBox = new System.Windows.Forms.TextBox();
            this.label_Description2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pGenericSearchTextBox
            // 
            this.pGenericSearchTextBox.LastSearchText = "";
            this.pGenericSearchTextBox.Location = new System.Drawing.Point(40, 81);
            this.pGenericSearchTextBox.Name = "pGenericSearchTextBox";
            this.pGenericSearchTextBox.Size = new System.Drawing.Size(100, 22);
            this.pGenericSearchTextBox.TabIndex = 0;
            // 
            // btn_ClearText
            // 
            this.btn_ClearText.Location = new System.Drawing.Point(40, 109);
            this.btn_ClearText.Name = "btn_ClearText";
            this.btn_ClearText.Size = new System.Drawing.Size(75, 23);
            this.btn_ClearText.TabIndex = 1;
            this.btn_ClearText.Text = "Clear Text";
            this.btn_ClearText.UseVisualStyleBackColor = true;
            this.btn_ClearText.Click += new System.EventHandler(this.btn_ClearText_Click);
            // 
            // label_Description
            // 
            this.label_Description.AutoSize = true;
            this.label_Description.Location = new System.Drawing.Point(28, 60);
            this.label_Description.Name = "label_Description";
            this.label_Description.Size = new System.Drawing.Size(196, 12);
            this.label_Description.TabIndex = 2;
            this.label_Description.Text = "Textbox with placeholder if text is empty";
            // 
            // pTextBox
            // 
            this.pTextBox.Location = new System.Drawing.Point(277, 82);
            this.pTextBox.Name = "pTextBox";
            this.pTextBox.Size = new System.Drawing.Size(100, 22);
            this.pTextBox.TabIndex = 3;
            // 
            // label_Description2
            // 
            this.label_Description2.AutoSize = true;
            this.label_Description2.Location = new System.Drawing.Point(263, 60);
            this.label_Description2.Name = "label_Description2";
            this.label_Description2.Size = new System.Drawing.Size(78, 12);
            this.label_Description2.TabIndex = 2;
            this.label_Description2.Text = "Normal textbox";
            // 
            // GenericSearchTextBoxSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 250);
            this.Controls.Add(this.pTextBox);
            this.Controls.Add(this.label_Description2);
            this.Controls.Add(this.label_Description);
            this.Controls.Add(this.btn_ClearText);
            this.Controls.Add(this.pGenericSearchTextBox);
            this.Name = "GenericSearchTextBoxSample";
            this.Text = "GenericSearchTextBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GenericWinForm.Views.GenericSearchTextBox pGenericSearchTextBox;
        private System.Windows.Forms.Button btn_ClearText;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.TextBox pTextBox;
        private System.Windows.Forms.Label label_Description2;
    }
}