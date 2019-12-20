namespace MyModelSample.View.GenericWinFormSample
{
    partial class GenericListViewSample
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
            this.btn_InitialList = new System.Windows.Forms.Button();
            this.rtb_List1 = new System.Windows.Forms.RichTextBox();
            this.btn_CheckItems = new System.Windows.Forms.Button();
            this.btn_UncheckItems = new System.Windows.Forms.Button();
            this.panel_outer = new System.Windows.Forms.Panel();
            this.pGenericListView = new GenericWinForm.Views.GenericListViews.GenericListView();
            this.btn_ViewItems = new System.Windows.Forms.Button();
            this.btn_ViewCheckedItems = new System.Windows.Forms.Button();
            this.rtb_List3 = new System.Windows.Forms.RichTextBox();
            this.rtb_List2 = new System.Windows.Forms.RichTextBox();
            this.btn_InitialColumns = new System.Windows.Forms.Button();
            this.btn_AutoResizeColumns = new System.Windows.Forms.Button();
            this.rtb_eventMessage = new System.Windows.Forms.RichTextBox();
            this.label_Event = new System.Windows.Forms.Label();
            this.btn_SetItems = new System.Windows.Forms.Button();
            this.label_Property = new System.Windows.Forms.Label();
            this.cb_CheckBoxes = new System.Windows.Forms.CheckBox();
            this.btn_SelectedItems = new System.Windows.Forms.Button();
            this.btn_ChangeItemValue = new System.Windows.Forms.Button();
            this.cb_HideUncheckedItems = new System.Windows.Forms.CheckBox();
            this.panel_outer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_InitialList
            // 
            this.btn_InitialList.Location = new System.Drawing.Point(160, 184);
            this.btn_InitialList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_InitialList.Name = "btn_InitialList";
            this.btn_InitialList.Size = new System.Drawing.Size(140, 29);
            this.btn_InitialList.TabIndex = 1;
            this.btn_InitialList.Text = "Initial Items";
            this.btn_InitialList.UseVisualStyleBackColor = true;
            this.btn_InitialList.Click += new System.EventHandler(this.btn_InitialList_Click);
            // 
            // rtb_List1
            // 
            this.rtb_List1.Location = new System.Drawing.Point(160, 16);
            this.rtb_List1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb_List1.Name = "rtb_List1";
            this.rtb_List1.Size = new System.Drawing.Size(140, 160);
            this.rtb_List1.TabIndex = 2;
            this.rtb_List1.Text = "0, 0\n1, 1\n1, 11\n1, 111\n1, 1111\n1, 11111\n2, 22\n3, 33\n4, 44\n5, 55\n6, 66\n7, 77\n8, 88" +
    "\n9, 99\n10, 1010";
            // 
            // btn_CheckItems
            // 
            this.btn_CheckItems.Location = new System.Drawing.Point(160, 295);
            this.btn_CheckItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_CheckItems.Name = "btn_CheckItems";
            this.btn_CheckItems.Size = new System.Drawing.Size(140, 29);
            this.btn_CheckItems.TabIndex = 1;
            this.btn_CheckItems.Text = "Check Items";
            this.btn_CheckItems.UseVisualStyleBackColor = true;
            this.btn_CheckItems.Click += new System.EventHandler(this.btn_CheckItems_Click);
            // 
            // btn_UncheckItems
            // 
            this.btn_UncheckItems.Location = new System.Drawing.Point(160, 331);
            this.btn_UncheckItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_UncheckItems.Name = "btn_UncheckItems";
            this.btn_UncheckItems.Size = new System.Drawing.Size(140, 29);
            this.btn_UncheckItems.TabIndex = 1;
            this.btn_UncheckItems.Text = "Uncheck Items";
            this.btn_UncheckItems.UseVisualStyleBackColor = true;
            this.btn_UncheckItems.Click += new System.EventHandler(this.btn_UncheckItems_Click);
            // 
            // panel_outer
            // 
            this.panel_outer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_outer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_outer.Controls.Add(this.pGenericListView);
            this.panel_outer.Location = new System.Drawing.Point(481, 13);
            this.panel_outer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel_outer.Name = "panel_outer";
            this.panel_outer.Size = new System.Drawing.Size(372, 485);
            this.panel_outer.TabIndex = 5;
            // 
            // pGenericListView
            // 
            this.pGenericListView.CheckBoxes = true;
            this.pGenericListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGenericListView.HideUncheckedItems = false;
            this.pGenericListView.Location = new System.Drawing.Point(0, 0);
            this.pGenericListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pGenericListView.Name = "pGenericListView";
            this.pGenericListView.SelectAllText = "Select All";
            this.pGenericListView.Size = new System.Drawing.Size(370, 483);
            this.pGenericListView.TabIndex = 0;
            // 
            // btn_ViewItems
            // 
            this.btn_ViewItems.Location = new System.Drawing.Point(306, 183);
            this.btn_ViewItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ViewItems.Name = "btn_ViewItems";
            this.btn_ViewItems.Size = new System.Drawing.Size(140, 29);
            this.btn_ViewItems.TabIndex = 1;
            this.btn_ViewItems.Text = "View Items";
            this.btn_ViewItems.UseVisualStyleBackColor = true;
            this.btn_ViewItems.Click += new System.EventHandler(this.btn_ViewItems_Click);
            // 
            // btn_ViewCheckedItems
            // 
            this.btn_ViewCheckedItems.Location = new System.Drawing.Point(306, 220);
            this.btn_ViewCheckedItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ViewCheckedItems.Name = "btn_ViewCheckedItems";
            this.btn_ViewCheckedItems.Size = new System.Drawing.Size(140, 29);
            this.btn_ViewCheckedItems.TabIndex = 1;
            this.btn_ViewCheckedItems.Text = "View Checked Items";
            this.btn_ViewCheckedItems.UseVisualStyleBackColor = true;
            this.btn_ViewCheckedItems.Click += new System.EventHandler(this.btn_ViewCheckedItems_Click);
            // 
            // rtb_List3
            // 
            this.rtb_List3.Location = new System.Drawing.Point(306, 15);
            this.rtb_List3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb_List3.Name = "rtb_List3";
            this.rtb_List3.Size = new System.Drawing.Size(140, 160);
            this.rtb_List3.TabIndex = 2;
            this.rtb_List3.Text = "";
            // 
            // rtb_List2
            // 
            this.rtb_List2.Location = new System.Drawing.Point(14, 16);
            this.rtb_List2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb_List2.Name = "rtb_List2";
            this.rtb_List2.Size = new System.Drawing.Size(140, 160);
            this.rtb_List2.TabIndex = 2;
            this.rtb_List2.Text = "C1\nC2\nC3";
            // 
            // btn_InitialColumns
            // 
            this.btn_InitialColumns.Location = new System.Drawing.Point(14, 184);
            this.btn_InitialColumns.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_InitialColumns.Name = "btn_InitialColumns";
            this.btn_InitialColumns.Size = new System.Drawing.Size(140, 29);
            this.btn_InitialColumns.TabIndex = 1;
            this.btn_InitialColumns.Text = "Initial Columns";
            this.btn_InitialColumns.UseVisualStyleBackColor = true;
            this.btn_InitialColumns.Click += new System.EventHandler(this.btn_SetColumns_Click);
            // 
            // btn_AutoResizeColumns
            // 
            this.btn_AutoResizeColumns.Location = new System.Drawing.Point(12, 468);
            this.btn_AutoResizeColumns.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_AutoResizeColumns.Name = "btn_AutoResizeColumns";
            this.btn_AutoResizeColumns.Size = new System.Drawing.Size(140, 29);
            this.btn_AutoResizeColumns.TabIndex = 1;
            this.btn_AutoResizeColumns.Text = "Auto Resize Columns";
            this.btn_AutoResizeColumns.UseVisualStyleBackColor = true;
            this.btn_AutoResizeColumns.Click += new System.EventHandler(this.btn_AutoResizeColumns_Click);
            // 
            // rtb_eventMessage
            // 
            this.rtb_eventMessage.Location = new System.Drawing.Point(307, 398);
            this.rtb_eventMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtb_eventMessage.Name = "rtb_eventMessage";
            this.rtb_eventMessage.ReadOnly = true;
            this.rtb_eventMessage.Size = new System.Drawing.Size(169, 99);
            this.rtb_eventMessage.TabIndex = 2;
            this.rtb_eventMessage.Text = "";
            // 
            // label_Event
            // 
            this.label_Event.AutoSize = true;
            this.label_Event.Location = new System.Drawing.Point(304, 379);
            this.label_Event.Name = "label_Event";
            this.label_Event.Size = new System.Drawing.Size(40, 15);
            this.label_Event.TabIndex = 6;
            this.label_Event.Text = "Event:";
            // 
            // btn_SetItems
            // 
            this.btn_SetItems.Location = new System.Drawing.Point(160, 221);
            this.btn_SetItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_SetItems.Name = "btn_SetItems";
            this.btn_SetItems.Size = new System.Drawing.Size(140, 29);
            this.btn_SetItems.TabIndex = 1;
            this.btn_SetItems.Text = "Set Items";
            this.btn_SetItems.UseVisualStyleBackColor = true;
            this.btn_SetItems.Click += new System.EventHandler(this.btn_SetItems_Click);
            // 
            // label_Property
            // 
            this.label_Property.AutoSize = true;
            this.label_Property.Location = new System.Drawing.Point(12, 405);
            this.label_Property.Name = "label_Property";
            this.label_Property.Size = new System.Drawing.Size(55, 15);
            this.label_Property.TabIndex = 6;
            this.label_Property.Text = "Property:";
            // 
            // cb_CheckBoxes
            // 
            this.cb_CheckBoxes.AutoSize = true;
            this.cb_CheckBoxes.Location = new System.Drawing.Point(73, 404);
            this.cb_CheckBoxes.Name = "cb_CheckBoxes";
            this.cb_CheckBoxes.Size = new System.Drawing.Size(95, 19);
            this.cb_CheckBoxes.TabIndex = 7;
            this.cb_CheckBoxes.Text = "CheckBoxes";
            this.cb_CheckBoxes.UseVisualStyleBackColor = true;
            this.cb_CheckBoxes.CheckedChanged += new System.EventHandler(this.cb_CheckBoxes_CheckedChanged);
            // 
            // btn_SelectedItems
            // 
            this.btn_SelectedItems.Location = new System.Drawing.Point(306, 257);
            this.btn_SelectedItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_SelectedItems.Name = "btn_SelectedItems";
            this.btn_SelectedItems.Size = new System.Drawing.Size(140, 29);
            this.btn_SelectedItems.TabIndex = 1;
            this.btn_SelectedItems.Text = "View Selected Items";
            this.btn_SelectedItems.UseVisualStyleBackColor = true;
            this.btn_SelectedItems.Click += new System.EventHandler(this.btn_SelectedItems_Click);
            // 
            // btn_ChangeItemValue
            // 
            this.btn_ChangeItemValue.Location = new System.Drawing.Point(160, 258);
            this.btn_ChangeItemValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ChangeItemValue.Name = "btn_ChangeItemValue";
            this.btn_ChangeItemValue.Size = new System.Drawing.Size(140, 29);
            this.btn_ChangeItemValue.TabIndex = 1;
            this.btn_ChangeItemValue.Text = "Change Item Value";
            this.btn_ChangeItemValue.UseVisualStyleBackColor = true;
            this.btn_ChangeItemValue.Click += new System.EventHandler(this.btn_ChangeItemValue_Click);
            // 
            // cb_HideUncheckedItems
            // 
            this.cb_HideUncheckedItems.AutoSize = true;
            this.cb_HideUncheckedItems.Location = new System.Drawing.Point(73, 429);
            this.cb_HideUncheckedItems.Name = "cb_HideUncheckedItems";
            this.cb_HideUncheckedItems.Size = new System.Drawing.Size(145, 19);
            this.cb_HideUncheckedItems.TabIndex = 7;
            this.cb_HideUncheckedItems.Text = "HideUncheckedItems";
            this.cb_HideUncheckedItems.UseVisualStyleBackColor = true;
            this.cb_HideUncheckedItems.CheckedChanged += new System.EventHandler(this.cb_HideUncheckedItems_CheckedChanged);
            // 
            // GenericListViewSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 511);
            this.Controls.Add(this.cb_HideUncheckedItems);
            this.Controls.Add(this.cb_CheckBoxes);
            this.Controls.Add(this.label_Property);
            this.Controls.Add(this.label_Event);
            this.Controls.Add(this.panel_outer);
            this.Controls.Add(this.rtb_List2);
            this.Controls.Add(this.rtb_eventMessage);
            this.Controls.Add(this.rtb_List3);
            this.Controls.Add(this.rtb_List1);
            this.Controls.Add(this.btn_UncheckItems);
            this.Controls.Add(this.btn_ChangeItemValue);
            this.Controls.Add(this.btn_CheckItems);
            this.Controls.Add(this.btn_SelectedItems);
            this.Controls.Add(this.btn_ViewCheckedItems);
            this.Controls.Add(this.btn_AutoResizeColumns);
            this.Controls.Add(this.btn_InitialColumns);
            this.Controls.Add(this.btn_ViewItems);
            this.Controls.Add(this.btn_SetItems);
            this.Controls.Add(this.btn_InitialList);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GenericListViewSample";
            this.Text = "MyWinFormSample";
            this.panel_outer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GenericWinForm.Views.GenericListViews.GenericListView pGenericListView;
        private System.Windows.Forms.Button btn_InitialList;
        private System.Windows.Forms.RichTextBox rtb_List1;
        private System.Windows.Forms.Button btn_CheckItems;
        private System.Windows.Forms.Button btn_UncheckItems;
        private System.Windows.Forms.Panel panel_outer;
        private System.Windows.Forms.Button btn_ViewItems;
        private System.Windows.Forms.Button btn_ViewCheckedItems;
        private System.Windows.Forms.RichTextBox rtb_List3;
        private System.Windows.Forms.RichTextBox rtb_List2;
        private System.Windows.Forms.Button btn_InitialColumns;
        private System.Windows.Forms.Button btn_AutoResizeColumns;
        private System.Windows.Forms.RichTextBox rtb_eventMessage;
        private System.Windows.Forms.Label label_Event;
        private System.Windows.Forms.Button btn_SetItems;
        private System.Windows.Forms.Label label_Property;
        private System.Windows.Forms.CheckBox cb_CheckBoxes;
        private System.Windows.Forms.Button btn_SelectedItems;
        private System.Windows.Forms.Button btn_ChangeItemValue;
        private System.Windows.Forms.CheckBox cb_HideUncheckedItems;
    }
}