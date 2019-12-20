namespace GenericWinForm.Views
{
    partial class GenericNumericList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pDataGridView = new System.Windows.Forms.DataGridView();
            this.dgvtbc_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pDataGridView
            // 
            this.pDataGridView.AllowUserToAddRows = false;
            this.pDataGridView.AllowUserToDeleteRows = false;
            this.pDataGridView.AllowUserToResizeRows = false;
            this.pDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pDataGridView.ColumnHeadersVisible = false;
            this.pDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtbc_Value});
            this.pDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.pDataGridView.EnableHeadersVisualStyles = false;
            this.pDataGridView.Location = new System.Drawing.Point(3, 3);
            this.pDataGridView.MultiSelect = false;
            this.pDataGridView.Name = "pDataGridView";
            this.pDataGridView.RowTemplate.Height = 24;
            this.pDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pDataGridView.Size = new System.Drawing.Size(97, 97);
            this.pDataGridView.TabIndex = 2;
            this.pDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.pDataGridView_CellValidating);
            this.pDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.pDataGridView_CellValueChanged);
            this.pDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.pDataGridView_RowsAdded);
            // 
            // dgvtbc_Value
            // 
            this.dgvtbc_Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Format = "N0";
            this.dgvtbc_Value.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvtbc_Value.HeaderText = "Value";
            this.dgvtbc_Value.Name = "dgvtbc_Value";
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Add.FlatAppearance.BorderSize = 0;
            this.btn_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Add.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Add.Location = new System.Drawing.Point(81, 103);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(22, 22);
            this.btn_Add.TabIndex = 3;
            this.btn_Add.Text = "＋";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Remove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Remove.FlatAppearance.BorderSize = 0;
            this.btn_Remove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Remove.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Remove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Remove.Location = new System.Drawing.Point(59, 103);
            this.btn_Remove.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(22, 22);
            this.btn_Remove.TabIndex = 4;
            this.btn_Remove.Text = "–";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // GenericNumericList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pDataGridView);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_Remove);
            this.Name = "GenericNumericList";
            this.Size = new System.Drawing.Size(103, 125);
            ((System.ComponentModel.ISupportInitialize)(this.pDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView pDataGridView;
        public System.Windows.Forms.DataGridViewTextBoxColumn dgvtbc_Value;
        public System.Windows.Forms.Button btn_Add;
        public System.Windows.Forms.Button btn_Remove;
    }
}
