namespace MyChartDirector
{
    partial class ChartDirectorWin
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
            this.winChartViewer1 = new ChartDirector.WinChartViewer();
            this.tableLayoutPanel_main = new System.Windows.Forms.TableLayoutPanel();
            this.panel_sample_btns = new System.Windows.Forms.Panel();
            this.buttonSymbolLineChart = new System.Windows.Forms.Button();
            this.button_ClickableCharts = new System.Windows.Forms.Button();
            this.button_LineChart = new System.Windows.Forms.Button();
            this.panel_custom_btns = new System.Windows.Forms.Panel();
            this.label_xLabel = new System.Windows.Forms.Label();
            this.label_x = new System.Windows.Forms.Label();
            this.label_value = new System.Windows.Forms.Label();
            this.button_custom = new System.Windows.Forms.Button();
            this.label_Infos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewer1)).BeginInit();
            this.tableLayoutPanel_main.SuspendLayout();
            this.panel_sample_btns.SuspendLayout();
            this.panel_custom_btns.SuspendLayout();
            this.SuspendLayout();
            // 
            // winChartViewer1
            // 
            this.winChartViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winChartViewer1.Location = new System.Drawing.Point(196, 3);
            this.winChartViewer1.Name = "winChartViewer1";
            this.tableLayoutPanel_main.SetRowSpan(this.winChartViewer1, 2);
            this.winChartViewer1.Size = new System.Drawing.Size(680, 450);
            this.winChartViewer1.TabIndex = 0;
            this.winChartViewer1.TabStop = false;
            // 
            // tableLayoutPanel_main
            // 
            this.tableLayoutPanel_main.ColumnCount = 2;
            this.tableLayoutPanel_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tableLayoutPanel_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_main.Controls.Add(this.winChartViewer1, 1, 0);
            this.tableLayoutPanel_main.Controls.Add(this.panel_sample_btns, 0, 0);
            this.tableLayoutPanel_main.Controls.Add(this.panel_custom_btns, 0, 1);
            this.tableLayoutPanel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_main.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_main.Name = "tableLayoutPanel_main";
            this.tableLayoutPanel_main.RowCount = 2;
            this.tableLayoutPanel_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_main.Size = new System.Drawing.Size(879, 456);
            this.tableLayoutPanel_main.TabIndex = 1;
            // 
            // panel_sample_btns
            // 
            this.panel_sample_btns.BackColor = System.Drawing.SystemColors.Control;
            this.panel_sample_btns.Controls.Add(this.buttonSymbolLineChart);
            this.panel_sample_btns.Controls.Add(this.button_ClickableCharts);
            this.panel_sample_btns.Controls.Add(this.button_LineChart);
            this.panel_sample_btns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_sample_btns.Location = new System.Drawing.Point(3, 3);
            this.panel_sample_btns.Name = "panel_sample_btns";
            this.panel_sample_btns.Size = new System.Drawing.Size(187, 222);
            this.panel_sample_btns.TabIndex = 1;
            // 
            // buttonSymbolLineChart
            // 
            this.buttonSymbolLineChart.Location = new System.Drawing.Point(24, 82);
            this.buttonSymbolLineChart.Name = "buttonSymbolLineChart";
            this.buttonSymbolLineChart.Size = new System.Drawing.Size(138, 23);
            this.buttonSymbolLineChart.TabIndex = 0;
            this.buttonSymbolLineChart.Text = "Symbol Line Chart";
            this.buttonSymbolLineChart.UseVisualStyleBackColor = true;
            // 
            // button_ClickableCharts
            // 
            this.button_ClickableCharts.Location = new System.Drawing.Point(24, 53);
            this.button_ClickableCharts.Name = "button_ClickableCharts";
            this.button_ClickableCharts.Size = new System.Drawing.Size(138, 23);
            this.button_ClickableCharts.TabIndex = 0;
            this.button_ClickableCharts.Text = "Clickable Charts";
            this.button_ClickableCharts.UseVisualStyleBackColor = true;
            // 
            // button_LineChart
            // 
            this.button_LineChart.Location = new System.Drawing.Point(24, 24);
            this.button_LineChart.Name = "button_LineChart";
            this.button_LineChart.Size = new System.Drawing.Size(138, 23);
            this.button_LineChart.TabIndex = 0;
            this.button_LineChart.Text = "Line Chart";
            this.button_LineChart.UseVisualStyleBackColor = true;
            // 
            // panel_custom_btns
            // 
            this.panel_custom_btns.BackColor = System.Drawing.SystemColors.Control;
            this.panel_custom_btns.Controls.Add(this.label_xLabel);
            this.panel_custom_btns.Controls.Add(this.label_x);
            this.panel_custom_btns.Controls.Add(this.label_Infos);
            this.panel_custom_btns.Controls.Add(this.label_value);
            this.panel_custom_btns.Controls.Add(this.button_custom);
            this.panel_custom_btns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_custom_btns.Location = new System.Drawing.Point(3, 231);
            this.panel_custom_btns.Name = "panel_custom_btns";
            this.panel_custom_btns.Size = new System.Drawing.Size(187, 222);
            this.panel_custom_btns.TabIndex = 3;
            // 
            // label_xLabel
            // 
            this.label_xLabel.AutoSize = true;
            this.label_xLabel.Location = new System.Drawing.Point(51, 109);
            this.label_xLabel.Name = "label_xLabel";
            this.label_xLabel.Size = new System.Drawing.Size(40, 12);
            this.label_xLabel.TabIndex = 3;
            this.label_xLabel.Text = "xLabel:";
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.Location = new System.Drawing.Point(51, 97);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(14, 12);
            this.label_x.TabIndex = 3;
            this.label_x.Text = "x:";
            // 
            // label_value
            // 
            this.label_value.AutoSize = true;
            this.label_value.Location = new System.Drawing.Point(51, 85);
            this.label_value.Name = "label_value";
            this.label_value.Size = new System.Drawing.Size(33, 12);
            this.label_value.TabIndex = 3;
            this.label_value.Text = "value:";
            // 
            // button_custom
            // 
            this.button_custom.Location = new System.Drawing.Point(24, 23);
            this.button_custom.Name = "button_custom";
            this.button_custom.Size = new System.Drawing.Size(75, 23);
            this.button_custom.TabIndex = 2;
            this.button_custom.Text = "Custom Chart";
            this.button_custom.UseVisualStyleBackColor = true;
            // 
            // label_Infos
            // 
            this.label_Infos.AutoSize = true;
            this.label_Infos.Location = new System.Drawing.Point(33, 71);
            this.label_Infos.Name = "label_Infos";
            this.label_Infos.Size = new System.Drawing.Size(87, 12);
            this.label_Infos.TabIndex = 3;
            this.label_Infos.Text = "Click Event Infos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 456);
            this.Controls.Add(this.tableLayoutPanel_main);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewer1)).EndInit();
            this.tableLayoutPanel_main.ResumeLayout(false);
            this.panel_sample_btns.ResumeLayout(false);
            this.panel_custom_btns.ResumeLayout(false);
            this.panel_custom_btns.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ChartDirector.WinChartViewer winChartViewer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_main;
        private System.Windows.Forms.Panel panel_sample_btns;
        private System.Windows.Forms.Button button_ClickableCharts;
        private System.Windows.Forms.Button button_LineChart;
        private System.Windows.Forms.Button buttonSymbolLineChart;
        private System.Windows.Forms.Panel panel_custom_btns;
        private System.Windows.Forms.Button button_custom;
        private System.Windows.Forms.Label label_xLabel;
        private System.Windows.Forms.Label label_x;
        private System.Windows.Forms.Label label_value;
        private System.Windows.Forms.Label label_Infos;
    }
}

