namespace PresentationFormsPart2
{
    partial class Results
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bPrevPoints = new System.Windows.Forms.Button();
            this.bNextPoints = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tBoxX1Left = new System.Windows.Forms.TextBox();
            this.tBoxX1Right = new System.Windows.Forms.TextBox();
            this.tBoxX2Left = new System.Windows.Forms.TextBox();
            this.tBoxX2Right = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tBoxFormula = new System.Windows.Forms.TextBox();
            this.tBoxAccuracyTruncation = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tBoxAccuracySearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBoxTestStep = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tBoxWorkStep = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(521, 303);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(569, 51);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(342, 264);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // bPrevPoints
            // 
            this.bPrevPoints.Location = new System.Drawing.Point(569, 17);
            this.bPrevPoints.Name = "bPrevPoints";
            this.bPrevPoints.Size = new System.Drawing.Size(75, 23);
            this.bPrevPoints.TabIndex = 47;
            this.bPrevPoints.Text = "<=";
            this.bPrevPoints.UseVisualStyleBackColor = true;
            this.bPrevPoints.Click += new System.EventHandler(this.bPrevPoints_Click);
            // 
            // bNextPoints
            // 
            this.bNextPoints.Location = new System.Drawing.Point(836, 17);
            this.bNextPoints.Name = "bNextPoints";
            this.bNextPoints.Size = new System.Drawing.Size(75, 23);
            this.bNextPoints.TabIndex = 46;
            this.bNextPoints.Text = "=>";
            this.bNextPoints.UseVisualStyleBackColor = true;
            this.bNextPoints.Click += new System.EventHandler(this.bNextPoints_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(713, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 13);
            this.label11.TabIndex = 48;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(917, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 64;
            this.label10.Text = "Expression";
            // 
            // tBoxX1Left
            // 
            this.tBoxX1Left.Location = new System.Drawing.Point(920, 33);
            this.tBoxX1Left.Name = "tBoxX1Left";
            this.tBoxX1Left.Size = new System.Drawing.Size(32, 20);
            this.tBoxX1Left.TabIndex = 49;
            this.tBoxX1Left.Text = "-10";
            // 
            // tBoxX1Right
            // 
            this.tBoxX1Right.Location = new System.Drawing.Point(1005, 33);
            this.tBoxX1Right.Name = "tBoxX1Right";
            this.tBoxX1Right.Size = new System.Drawing.Size(32, 20);
            this.tBoxX1Right.TabIndex = 50;
            this.tBoxX1Right.Text = "10";
            // 
            // tBoxX2Left
            // 
            this.tBoxX2Left.Location = new System.Drawing.Point(920, 60);
            this.tBoxX2Left.Name = "tBoxX2Left";
            this.tBoxX2Left.Size = new System.Drawing.Size(32, 20);
            this.tBoxX2Left.TabIndex = 51;
            this.tBoxX2Left.Text = "-5";
            // 
            // tBoxX2Right
            // 
            this.tBoxX2Right.Location = new System.Drawing.Point(1005, 60);
            this.tBoxX2Right.Name = "tBoxX2Right";
            this.tBoxX2Right.Size = new System.Drawing.Size(32, 20);
            this.tBoxX2Right.TabIndex = 52;
            this.tBoxX2Right.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(955, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "<= X <=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(954, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "<= Y <=";
            // 
            // tBoxFormula
            // 
            this.tBoxFormula.Location = new System.Drawing.Point(981, 10);
            this.tBoxFormula.Name = "tBoxFormula";
            this.tBoxFormula.Size = new System.Drawing.Size(204, 20);
            this.tBoxFormula.TabIndex = 55;
            this.tBoxFormula.Text = "2*(Y-X^2)^2+100*(1-X)^2";
            // 
            // tBoxAccuracyTruncation
            // 
            this.tBoxAccuracyTruncation.Location = new System.Drawing.Point(1032, 86);
            this.tBoxAccuracyTruncation.Name = "tBoxAccuracyTruncation";
            this.tBoxAccuracyTruncation.Size = new System.Drawing.Size(32, 20);
            this.tBoxAccuracyTruncation.TabIndex = 56;
            this.tBoxAccuracyTruncation.Text = "0.01";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(921, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Truncation accuracy";
            // 
            // tBoxAccuracySearch
            // 
            this.tBoxAccuracySearch.Location = new System.Drawing.Point(1080, 112);
            this.tBoxAccuracySearch.Name = "tBoxAccuracySearch";
            this.tBoxAccuracySearch.Size = new System.Drawing.Size(32, 20);
            this.tBoxAccuracySearch.TabIndex = 58;
            this.tBoxAccuracySearch.Text = "0.01";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(921, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Search accuracy of the method";
            // 
            // tBoxTestStep
            // 
            this.tBoxTestStep.Location = new System.Drawing.Point(978, 138);
            this.tBoxTestStep.Name = "tBoxTestStep";
            this.tBoxTestStep.Size = new System.Drawing.Size(25, 20);
            this.tBoxTestStep.TabIndex = 60;
            this.tBoxTestStep.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(921, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Work step";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(921, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 61;
            this.label4.Text = "Test step";
            // 
            // tBoxWorkStep
            // 
            this.tBoxWorkStep.Location = new System.Drawing.Point(978, 164);
            this.tBoxWorkStep.Name = "tBoxWorkStep";
            this.tBoxWorkStep.Size = new System.Drawing.Size(25, 20);
            this.tBoxWorkStep.TabIndex = 62;
            this.tBoxWorkStep.Text = "2";
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 333);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tBoxX1Left);
            this.Controls.Add(this.tBoxX1Right);
            this.Controls.Add(this.tBoxX2Left);
            this.Controls.Add(this.tBoxX2Right);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBoxFormula);
            this.Controls.Add(this.tBoxAccuracyTruncation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tBoxAccuracySearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tBoxTestStep);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tBoxWorkStep);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.bPrevPoints);
            this.Controls.Add(this.bNextPoints);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Results";
            this.Text = "Results";
            this.Load += new System.EventHandler(this.Results_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button bPrevPoints;
        private System.Windows.Forms.Button bNextPoints;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tBoxX1Left;
        private System.Windows.Forms.TextBox tBoxX1Right;
        private System.Windows.Forms.TextBox tBoxX2Left;
        private System.Windows.Forms.TextBox tBoxX2Right;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBoxFormula;
        private System.Windows.Forms.TextBox tBoxAccuracyTruncation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBoxAccuracySearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBoxTestStep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBoxWorkStep;
    }
}