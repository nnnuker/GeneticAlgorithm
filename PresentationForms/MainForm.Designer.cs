namespace PresentationForms
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tBoxX1Left = new System.Windows.Forms.TextBox();
            this.tBoxX1Right = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tBoxX2Left = new System.Windows.Forms.TextBox();
            this.tBoxX2Right = new System.Windows.Forms.TextBox();
            this.tBoxN = new System.Windows.Forms.TextBox();
            this.tBoxExeEnd = new System.Windows.Forms.TextBox();
            this.tBoxPercent = new System.Windows.Forms.TextBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tBoxX1Left
            // 
            this.tBoxX1Left.Location = new System.Drawing.Point(305, 12);
            this.tBoxX1Left.Name = "tBoxX1Left";
            this.tBoxX1Left.Size = new System.Drawing.Size(100, 20);
            this.tBoxX1Left.TabIndex = 0;
            // 
            // tBoxX1Right
            // 
            this.tBoxX1Right.Location = new System.Drawing.Point(475, 12);
            this.tBoxX1Right.Name = "tBoxX1Right";
            this.tBoxX1Right.Size = new System.Drawing.Size(100, 20);
            this.tBoxX1Right.TabIndex = 1;
            // 
            // tBoxX2Left
            // 
            this.tBoxX2Left.Location = new System.Drawing.Point(305, 39);
            this.tBoxX2Left.Name = "tBoxX2Left";
            this.tBoxX2Left.Size = new System.Drawing.Size(100, 20);
            this.tBoxX2Left.TabIndex = 3;
            // 
            // tBoxX2Right
            // 
            this.tBoxX2Right.Location = new System.Drawing.Point(475, 38);
            this.tBoxX2Right.Name = "tBoxX2Right";
            this.tBoxX2Right.Size = new System.Drawing.Size(100, 20);
            this.tBoxX2Right.TabIndex = 4;
            // 
            // tBoxN
            // 
            this.tBoxN.Location = new System.Drawing.Point(475, 64);
            this.tBoxN.Name = "tBoxN";
            this.tBoxN.Size = new System.Drawing.Size(100, 20);
            this.tBoxN.TabIndex = 5;
            // 
            // tBoxExeEnd
            // 
            this.tBoxExeEnd.Location = new System.Drawing.Point(475, 91);
            this.tBoxExeEnd.Name = "tBoxExeEnd";
            this.tBoxExeEnd.Size = new System.Drawing.Size(100, 20);
            this.tBoxExeEnd.TabIndex = 6;
            // 
            // tBoxPercent
            // 
            this.tBoxPercent.Location = new System.Drawing.Point(475, 118);
            this.tBoxPercent.Name = "tBoxPercent";
            this.tBoxPercent.Size = new System.Drawing.Size(100, 20);
            this.tBoxPercent.TabIndex = 7;
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(13, 13);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(286, 367);
            this.chart.TabIndex = 8;
            this.chart.Text = "chart1";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(305, 144);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(270, 236);
            this.dataGridView.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 392);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.tBoxPercent);
            this.Controls.Add(this.tBoxExeEnd);
            this.Controls.Add(this.tBoxN);
            this.Controls.Add(this.tBoxX2Right);
            this.Controls.Add(this.tBoxX2Left);
            this.Controls.Add(this.tBoxX1Right);
            this.Controls.Add(this.tBoxX1Left);
            this.Name = "MainForm";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBoxX1Left;
        private System.Windows.Forms.TextBox tBoxX1Right;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox tBoxX2Left;
        private System.Windows.Forms.TextBox tBoxX2Right;
        private System.Windows.Forms.TextBox tBoxN;
        private System.Windows.Forms.TextBox tBoxExeEnd;
        private System.Windows.Forms.TextBox tBoxPercent;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}

