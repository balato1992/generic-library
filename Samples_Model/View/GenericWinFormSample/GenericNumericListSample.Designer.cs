namespace MyModelSample.View.GenericWinFormSample
{
    partial class GenericNumericListSample
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
            this.btn_GetValue = new System.Windows.Forms.Button();
            this.pRichTextBox = new System.Windows.Forms.RichTextBox();
            this.pGenericNumericList = new GenericWinForm.Views.GenericNumericList();
            this.nud_MaxValue = new System.Windows.Forms.NumericUpDown();
            this.nud_MinValue = new System.Windows.Forms.NumericUpDown();
            this.nud_DefaultValue = new System.Windows.Forms.NumericUpDown();
            this.label_MaxValue = new System.Windows.Forms.Label();
            this.label_MinValue = new System.Windows.Forms.Label();
            this.label_DefaultValue = new System.Windows.Forms.Label();
            this.btn_SetValue = new System.Windows.Forms.Button();
            this.cb_AlwaysDescending = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MinValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DefaultValue)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_GetValue
            // 
            this.btn_GetValue.Location = new System.Drawing.Point(26, 174);
            this.btn_GetValue.Name = "btn_GetValue";
            this.btn_GetValue.Size = new System.Drawing.Size(75, 23);
            this.btn_GetValue.TabIndex = 1;
            this.btn_GetValue.Text = "Get Value";
            this.btn_GetValue.UseVisualStyleBackColor = true;
            this.btn_GetValue.Click += new System.EventHandler(this.btn_GetValue_Click);
            // 
            // pRichTextBox
            // 
            this.pRichTextBox.Location = new System.Drawing.Point(107, 176);
            this.pRichTextBox.Name = "pRichTextBox";
            this.pRichTextBox.Size = new System.Drawing.Size(187, 128);
            this.pRichTextBox.TabIndex = 2;
            this.pRichTextBox.Text = "";
            // 
            // pGenericNumericList
            // 
            this.pGenericNumericList.AlwaysDescending = false;
            this.pGenericNumericList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pGenericNumericList.DefaultValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pGenericNumericList.Location = new System.Drawing.Point(339, 12);
            this.pGenericNumericList.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.pGenericNumericList.MinValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.pGenericNumericList.Name = "pGenericNumericList";
            this.pGenericNumericList.Size = new System.Drawing.Size(142, 141);
            this.pGenericNumericList.TabIndex = 0;
            // 
            // nud_MaxValue
            // 
            this.nud_MaxValue.DecimalPlaces = 3;
            this.nud_MaxValue.Location = new System.Drawing.Point(107, 13);
            this.nud_MaxValue.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nud_MaxValue.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nud_MaxValue.Name = "nud_MaxValue";
            this.nud_MaxValue.Size = new System.Drawing.Size(120, 22);
            this.nud_MaxValue.TabIndex = 3;
            this.nud_MaxValue.ValueChanged += new System.EventHandler(this.nud_MaxValue_ValueChanged);
            // 
            // nud_MinValue
            // 
            this.nud_MinValue.DecimalPlaces = 3;
            this.nud_MinValue.Location = new System.Drawing.Point(107, 40);
            this.nud_MinValue.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nud_MinValue.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nud_MinValue.Name = "nud_MinValue";
            this.nud_MinValue.Size = new System.Drawing.Size(120, 22);
            this.nud_MinValue.TabIndex = 3;
            this.nud_MinValue.ValueChanged += new System.EventHandler(this.nud_MinValue_ValueChanged);
            // 
            // nud_DefaultValue
            // 
            this.nud_DefaultValue.DecimalPlaces = 3;
            this.nud_DefaultValue.Location = new System.Drawing.Point(107, 68);
            this.nud_DefaultValue.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nud_DefaultValue.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nud_DefaultValue.Name = "nud_DefaultValue";
            this.nud_DefaultValue.Size = new System.Drawing.Size(120, 22);
            this.nud_DefaultValue.TabIndex = 3;
            this.nud_DefaultValue.ValueChanged += new System.EventHandler(this.nud_DefaultValue_ValueChanged);
            // 
            // label_MaxValue
            // 
            this.label_MaxValue.AutoSize = true;
            this.label_MaxValue.Location = new System.Drawing.Point(48, 15);
            this.label_MaxValue.Name = "label_MaxValue";
            this.label_MaxValue.Size = new System.Drawing.Size(53, 12);
            this.label_MaxValue.TabIndex = 4;
            this.label_MaxValue.Text = "MaxValue";
            // 
            // label_MinValue
            // 
            this.label_MinValue.AutoSize = true;
            this.label_MinValue.Location = new System.Drawing.Point(48, 42);
            this.label_MinValue.Name = "label_MinValue";
            this.label_MinValue.Size = new System.Drawing.Size(51, 12);
            this.label_MinValue.TabIndex = 4;
            this.label_MinValue.Text = "MinValue";
            // 
            // label_DefaultValue
            // 
            this.label_DefaultValue.AutoSize = true;
            this.label_DefaultValue.Location = new System.Drawing.Point(35, 70);
            this.label_DefaultValue.Name = "label_DefaultValue";
            this.label_DefaultValue.Size = new System.Drawing.Size(66, 12);
            this.label_DefaultValue.TabIndex = 4;
            this.label_DefaultValue.Text = "DefaultValue";
            // 
            // btn_SetValue
            // 
            this.btn_SetValue.Location = new System.Drawing.Point(26, 203);
            this.btn_SetValue.Name = "btn_SetValue";
            this.btn_SetValue.Size = new System.Drawing.Size(75, 23);
            this.btn_SetValue.TabIndex = 1;
            this.btn_SetValue.Text = "Set Value";
            this.btn_SetValue.UseVisualStyleBackColor = true;
            this.btn_SetValue.Click += new System.EventHandler(this.btn_SetValue_Click);
            // 
            // cb_AlwaysDescending
            // 
            this.cb_AlwaysDescending.AutoSize = true;
            this.cb_AlwaysDescending.Location = new System.Drawing.Point(107, 96);
            this.cb_AlwaysDescending.Name = "cb_AlwaysDescending";
            this.cb_AlwaysDescending.Size = new System.Drawing.Size(113, 16);
            this.cb_AlwaysDescending.TabIndex = 5;
            this.cb_AlwaysDescending.Text = "Always descending";
            this.cb_AlwaysDescending.UseVisualStyleBackColor = true;
            this.cb_AlwaysDescending.CheckedChanged += new System.EventHandler(this.cb_AlwaysDescending_CheckedChanged);
            // 
            // GenericNumericListSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 412);
            this.Controls.Add(this.cb_AlwaysDescending);
            this.Controls.Add(this.label_DefaultValue);
            this.Controls.Add(this.label_MinValue);
            this.Controls.Add(this.label_MaxValue);
            this.Controls.Add(this.nud_DefaultValue);
            this.Controls.Add(this.nud_MinValue);
            this.Controls.Add(this.nud_MaxValue);
            this.Controls.Add(this.pRichTextBox);
            this.Controls.Add(this.btn_SetValue);
            this.Controls.Add(this.btn_GetValue);
            this.Controls.Add(this.pGenericNumericList);
            this.Name = "GenericNumericListSample";
            this.Text = "GenericNumericListSample";
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MinValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DefaultValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GenericWinForm.Views.GenericNumericList pGenericNumericList;
        private System.Windows.Forms.Button btn_GetValue;
        private System.Windows.Forms.RichTextBox pRichTextBox;
        private System.Windows.Forms.NumericUpDown nud_MaxValue;
        private System.Windows.Forms.NumericUpDown nud_MinValue;
        private System.Windows.Forms.NumericUpDown nud_DefaultValue;
        private System.Windows.Forms.Label label_MaxValue;
        private System.Windows.Forms.Label label_MinValue;
        private System.Windows.Forms.Label label_DefaultValue;
        private System.Windows.Forms.Button btn_SetValue;
        private System.Windows.Forms.CheckBox cb_AlwaysDescending;
    }
}