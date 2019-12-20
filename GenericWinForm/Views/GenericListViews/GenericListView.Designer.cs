namespace GenericWinForm.Views.GenericListViews
{
    partial class GenericListView
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
            this.components = new System.ComponentModel.Container();
            this.gstb_Search = new GenericSearchTextBox();
            this.cb_SelectAll = new System.Windows.Forms.CheckBox();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.lv_Main = new GenericWinForm.Views.GenericListViews.n_ListView(this.components);
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_Search
            // 
            this.gstb_Search.Location = new System.Drawing.Point(3, 3);
            this.gstb_Search.Name = "tb_Search";
            this.gstb_Search.Size = new System.Drawing.Size(207, 22);
            this.gstb_Search.TabIndex = 77;
            this.gstb_Search.SearchTextChanged += new System.EventHandler(this.gstb_Search_SearchTextChanged);
            // 
            // cb_SelectAll
            // 
            this.cb_SelectAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cb_SelectAll.AutoSize = true;
            this.cb_SelectAll.Location = new System.Drawing.Point(3, 211);
            this.cb_SelectAll.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.cb_SelectAll.Name = "cb_SelectAll";
            this.cb_SelectAll.Size = new System.Drawing.Size(68, 16);
            this.cb_SelectAll.TabIndex = 76;
            this.cb_SelectAll.Text = "Select All";
            this.cb_SelectAll.UseVisualStyleBackColor = true;
            this.cb_SelectAll.CheckedChanged += new System.EventHandler(this.cb_SelectAll_CheckedChanged);
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.gstb_Search, 0, 0);
            this.tlp_Main.Controls.Add(this.lv_Main, 0, 1);
            this.tlp_Main.Controls.Add(this.cb_SelectAll, 0, 2);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(215, 229);
            this.tlp_Main.TabIndex = 76;
            // 
            // lv_Main
            // 
            this.lv_Main.CheckBoxes = true;
            this.lv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_Main.FullRowSelect = true;
            this.lv_Main.HideSelection = false;
            this.lv_Main.Location = new System.Drawing.Point(3, 28);
            this.lv_Main.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lv_Main.Name = "lv_Main";
            this.lv_Main.Size = new System.Drawing.Size(209, 178);
            this.lv_Main.TabIndex = 75;
            this.lv_Main.UseCompatibleStateImageBehavior = false;
            this.lv_Main.View = System.Windows.Forms.View.List;
            this.lv_Main.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_Main_ItemChecked);
            // 
            // GenericListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "GenericListView";
            this.Size = new System.Drawing.Size(215, 229);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.CheckBox cb_SelectAll;
        private n_ListView lv_Main;
        private GenericSearchTextBox gstb_Search;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;
    }
}
