namespace MyModelSample.View.GenericWinFormSample
{
    partial class GenericDataGridViewSample
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
            MyModelSample.View._styles.SampleTestClass sampleTestClass1 = new MyModelSample.View._styles.SampleTestClass();
            this.btn_ClearColumns = new System.Windows.Forms.Button();
            this.btn_SetColumn = new System.Windows.Forms.Button();
            this.btn_MakeSerialData = new System.Windows.Forms.Button();
            this.btn_GetRowObject = new System.Windows.Forms.Button();
            this.btn_MakeRandomData = new System.Windows.Forms.Button();
            this.nud_RowIndex = new System.Windows.Forms.NumericUpDown();
            this.btn_UnitTest = new System.Windows.Forms.Button();
            this.rtb_UnitTestMessage = new System.Windows.Forms.RichTextBox();
            this.pGenericDataGridView = new GenericWinForm.Views.GenericDataGridViews.GenericDataGridView();
            this.btn_GetAllItems = new System.Windows.Forms.Button();
            this.rtb_GetInfo = new System.Windows.Forms.RichTextBox();
            this.btn_GetCheckedItems = new System.Windows.Forms.Button();
            this.pSampleTestClassControl = new MyModelSample.View._styles.SampleTestClassControl();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RowIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ClearColumns
            // 
            this.btn_ClearColumns.Location = new System.Drawing.Point(262, 71);
            this.btn_ClearColumns.Name = "btn_ClearColumns";
            this.btn_ClearColumns.Size = new System.Drawing.Size(139, 23);
            this.btn_ClearColumns.TabIndex = 1;
            this.btn_ClearColumns.Text = "Clear Columns";
            this.btn_ClearColumns.UseVisualStyleBackColor = true;
            this.btn_ClearColumns.Click += new System.EventHandler(this.btn_ClearColumns_Click);
            // 
            // btn_SetColumn
            // 
            this.btn_SetColumn.Location = new System.Drawing.Point(262, 42);
            this.btn_SetColumn.Name = "btn_SetColumn";
            this.btn_SetColumn.Size = new System.Drawing.Size(139, 23);
            this.btn_SetColumn.TabIndex = 1;
            this.btn_SetColumn.Text = "Set Column";
            this.btn_SetColumn.UseVisualStyleBackColor = true;
            this.btn_SetColumn.Click += new System.EventHandler(this.btn_SetColumn_Click);
            // 
            // btn_MakeSerialData
            // 
            this.btn_MakeSerialData.Location = new System.Drawing.Point(25, 71);
            this.btn_MakeSerialData.Name = "btn_MakeSerialData";
            this.btn_MakeSerialData.Size = new System.Drawing.Size(139, 23);
            this.btn_MakeSerialData.TabIndex = 1;
            this.btn_MakeSerialData.Text = "Make Serial Data";
            this.btn_MakeSerialData.UseVisualStyleBackColor = true;
            this.btn_MakeSerialData.Click += new System.EventHandler(this.btn_MakeSerialData_Click);
            // 
            // btn_GetRowObject
            // 
            this.btn_GetRowObject.Location = new System.Drawing.Point(25, 100);
            this.btn_GetRowObject.Name = "btn_GetRowObject";
            this.btn_GetRowObject.Size = new System.Drawing.Size(139, 23);
            this.btn_GetRowObject.TabIndex = 1;
            this.btn_GetRowObject.Text = "Get Row Object";
            this.btn_GetRowObject.UseVisualStyleBackColor = true;
            this.btn_GetRowObject.Click += new System.EventHandler(this.btn_GetRowObject_Click);
            // 
            // btn_MakeRandomData
            // 
            this.btn_MakeRandomData.Location = new System.Drawing.Point(25, 42);
            this.btn_MakeRandomData.Name = "btn_MakeRandomData";
            this.btn_MakeRandomData.Size = new System.Drawing.Size(139, 23);
            this.btn_MakeRandomData.TabIndex = 1;
            this.btn_MakeRandomData.Text = "Make Random Data";
            this.btn_MakeRandomData.UseVisualStyleBackColor = true;
            this.btn_MakeRandomData.Click += new System.EventHandler(this.btn_MakeRandomData_Click);
            // 
            // nud_RowIndex
            // 
            this.nud_RowIndex.Location = new System.Drawing.Point(171, 100);
            this.nud_RowIndex.Name = "nud_RowIndex";
            this.nud_RowIndex.Size = new System.Drawing.Size(65, 22);
            this.nud_RowIndex.TabIndex = 2;
            // 
            // btn_UnitTest
            // 
            this.btn_UnitTest.Location = new System.Drawing.Point(15, 411);
            this.btn_UnitTest.Name = "btn_UnitTest";
            this.btn_UnitTest.Size = new System.Drawing.Size(105, 23);
            this.btn_UnitTest.TabIndex = 1;
            this.btn_UnitTest.Text = "Unit Test";
            this.btn_UnitTest.UseVisualStyleBackColor = true;
            this.btn_UnitTest.Click += new System.EventHandler(this.btn_UnitTest_Click);
            // 
            // rtb_UnitTestMessage
            // 
            this.rtb_UnitTestMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_UnitTestMessage.Location = new System.Drawing.Point(126, 411);
            this.rtb_UnitTestMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb_UnitTestMessage.Name = "rtb_UnitTestMessage";
            this.rtb_UnitTestMessage.ReadOnly = true;
            this.rtb_UnitTestMessage.Size = new System.Drawing.Size(172, 141);
            this.rtb_UnitTestMessage.TabIndex = 4;
            this.rtb_UnitTestMessage.Text = "";
            // 
            // pGenericDataGridView
            // 
            this.pGenericDataGridView.Location = new System.Drawing.Point(469, 30);
            this.pGenericDataGridView.Name = "pGenericDataGridView";
            this.pGenericDataGridView.Size = new System.Drawing.Size(359, 309);
            this.pGenericDataGridView.TabIndex = 0;
            // 
            // btn_GetAllItems
            // 
            this.btn_GetAllItems.Location = new System.Drawing.Point(291, 150);
            this.btn_GetAllItems.Name = "btn_GetAllItems";
            this.btn_GetAllItems.Size = new System.Drawing.Size(139, 23);
            this.btn_GetAllItems.TabIndex = 1;
            this.btn_GetAllItems.Text = "Get All Items";
            this.btn_GetAllItems.UseVisualStyleBackColor = true;
            this.btn_GetAllItems.Click += new System.EventHandler(this.btn_GetAllItems_Click);
            // 
            // rtb_GetInfo
            // 
            this.rtb_GetInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_GetInfo.Location = new System.Drawing.Point(291, 209);
            this.rtb_GetInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb_GetInfo.Name = "rtb_GetInfo";
            this.rtb_GetInfo.ReadOnly = true;
            this.rtb_GetInfo.Size = new System.Drawing.Size(172, 141);
            this.rtb_GetInfo.TabIndex = 4;
            this.rtb_GetInfo.Text = "";
            this.rtb_GetInfo.WordWrap = false;
            // 
            // btn_GetCheckedItems
            // 
            this.btn_GetCheckedItems.Location = new System.Drawing.Point(291, 179);
            this.btn_GetCheckedItems.Name = "btn_GetCheckedItems";
            this.btn_GetCheckedItems.Size = new System.Drawing.Size(139, 23);
            this.btn_GetCheckedItems.TabIndex = 1;
            this.btn_GetCheckedItems.Text = "Get Checked Items";
            this.btn_GetCheckedItems.UseVisualStyleBackColor = true;
            this.btn_GetCheckedItems.Click += new System.EventHandler(this.btn_GetCheckedItems_Click);
            // 
            // pSampleTestClassControl
            // 
            this.pSampleTestClassControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            sampleTestClass1.IsChecked = false;
            sampleTestClass1.Key = "";
            sampleTestClass1.String1 = "";
            sampleTestClass1.String2 = "";
            sampleTestClass1.String3 = "";
            this.pSampleTestClassControl.Data = sampleTestClass1;
            this.pSampleTestClassControl.Location = new System.Drawing.Point(54, 129);
            this.pSampleTestClassControl.Name = "pSampleTestClassControl";
            this.pSampleTestClassControl.Size = new System.Drawing.Size(207, 143);
            this.pSampleTestClassControl.TabIndex = 3;
            // 
            // GenericDataGridViewSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 568);
            this.Controls.Add(this.rtb_GetInfo);
            this.Controls.Add(this.rtb_UnitTestMessage);
            this.Controls.Add(this.pSampleTestClassControl);
            this.Controls.Add(this.nud_RowIndex);
            this.Controls.Add(this.btn_GetRowObject);
            this.Controls.Add(this.btn_MakeRandomData);
            this.Controls.Add(this.btn_MakeSerialData);
            this.Controls.Add(this.btn_UnitTest);
            this.Controls.Add(this.btn_SetColumn);
            this.Controls.Add(this.btn_GetCheckedItems);
            this.Controls.Add(this.btn_GetAllItems);
            this.Controls.Add(this.btn_ClearColumns);
            this.Controls.Add(this.pGenericDataGridView);
            this.Name = "GenericDataGridViewSample";
            this.Text = "GenericDataGridViewSample";
            ((System.ComponentModel.ISupportInitialize)(this.nud_RowIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GenericWinForm.Views.GenericDataGridViews.GenericDataGridView pGenericDataGridView;
        private System.Windows.Forms.Button btn_ClearColumns;
        private System.Windows.Forms.Button btn_SetColumn;
        private System.Windows.Forms.Button btn_MakeSerialData;
        private System.Windows.Forms.Button btn_GetRowObject;
        private System.Windows.Forms.Button btn_MakeRandomData;
        private System.Windows.Forms.NumericUpDown nud_RowIndex;
        private _styles.SampleTestClassControl pSampleTestClassControl;
        private System.Windows.Forms.Button btn_UnitTest;
        private System.Windows.Forms.RichTextBox rtb_UnitTestMessage;
        private System.Windows.Forms.Button btn_GetAllItems;
        private System.Windows.Forms.RichTextBox rtb_GetInfo;
        private System.Windows.Forms.Button btn_GetCheckedItems;
    }
}