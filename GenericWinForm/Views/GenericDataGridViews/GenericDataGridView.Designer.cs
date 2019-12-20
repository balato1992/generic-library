namespace GenericWinForm.Views.GenericDataGridViews
{
    partial class GenericDataGridView
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
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.gstb_Search = new GenericWinForm.Views.GenericSearchTextBox(this.components);
            this.cb_SelectAll = new System.Windows.Forms.CheckBox();
            this.n_dgv_Main = new GenericWinForm.Views.GenericDataGridViews.n_DataGridView(this.components);
            this.tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_dgv_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.gstb_Search, 0, 0);
            this.tlp_Main.Controls.Add(this.cb_SelectAll, 0, 2);
            this.tlp_Main.Controls.Add(this.n_dgv_Main, 0, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(340, 282);
            this.tlp_Main.TabIndex = 77;
            // 
            // gstb_Search
            // 
            this.gstb_Search.ForeColor = System.Drawing.Color.Gray;
            this.gstb_Search.LastSearchText = "";
            this.gstb_Search.Location = new System.Drawing.Point(3, 3);
            this.gstb_Search.Name = "gstb_Search";
            this.gstb_Search.Size = new System.Drawing.Size(207, 22);
            this.gstb_Search.TabIndex = 77;
            this.gstb_Search.Text = "Enter text here...";
            this.gstb_Search.TextChanged += new System.EventHandler(this.gstb_Search_TextChanged);
            // 
            // cb_SelectAll
            // 
            this.cb_SelectAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cb_SelectAll.AutoSize = true;
            this.cb_SelectAll.Location = new System.Drawing.Point(3, 264);
            this.cb_SelectAll.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.cb_SelectAll.Name = "cb_SelectAll";
            this.cb_SelectAll.Size = new System.Drawing.Size(68, 16);
            this.cb_SelectAll.TabIndex = 76;
            this.cb_SelectAll.Text = "Select All";
            this.cb_SelectAll.UseVisualStyleBackColor = true;
            this.cb_SelectAll.CheckedChanged += new System.EventHandler(this.cb_SelectAll_CheckedChanged);
            // 
            // n_dgv_Main
            // 
            this.n_dgv_Main.AllowUserToAddRows = false;
            this.n_dgv_Main.AllowUserToDeleteRows = false;
            this.n_dgv_Main.BackgroundColor = System.Drawing.SystemColors.Window;
            this.n_dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.n_dgv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.n_dgv_Main.Location = new System.Drawing.Point(3, 31);
            this.n_dgv_Main.Name = "n_dgv_Main";
            this.n_dgv_Main.RowHeadersVisible = false;
            this.n_dgv_Main.RowTemplate.Height = 24;
            this.n_dgv_Main.Size = new System.Drawing.Size(334, 228);
            this.n_dgv_Main.TabIndex = 78;
            this.n_dgv_Main.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Main_CommitEdit);
            this.n_dgv_Main.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Main_CommitEdit);
            this.n_dgv_Main.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Main_CellValueChanged);
            // 
            // GenericDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "GenericDataGridView";
            this.Size = new System.Drawing.Size(340, 282);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_dgv_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private GenericSearchTextBox gstb_Search;
        public System.Windows.Forms.CheckBox cb_SelectAll;
        private n_DataGridView n_dgv_Main;
    }
}
